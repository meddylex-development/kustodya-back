#######################################################################
#                                                                     #
#       Script para instalar el modulo de Azure AD en powershell      #
#                                                                     #
#######################################################################

if ($PSVersionTable.PSEdition -eq 'Desktop' -and (Get-Module -Name AzureRM -ListAvailable)) {
    Write-Warning -Message ('Az module not installed. Having both the AzureRM and ' +
      'Az modules installed at the same time is not supported.')
} else {
    Install-Module -Name Az -AllowClobber -Scope CurrentUser
}

###############################################################
#                                                             #
#       Script para registrar una aplicacion en Azure AD      #
#                                                             #
###############################################################

# The app ID - $app.appid
# The service principal object ID - $sp.objectId
# The app key - $key.value

# Sign in as a user that's allowed to create an app
Connect-AzureAD

# Create a new Azure AD web application
$app = New-AzureADApplication -DisplayName "KustodyaPowerBI" -Homepage "https://www.kustodya.com.co" -ReplyUrls "https://www.kustodya.com.co"

# Creates a service principal
$sp = New-AzureADServicePrincipal -AppId $app.AppId

# Get the service principal key
$key = New-AzureADServicePrincipalPasswordCredential -ObjectId $sp.ObjectId



####################################################################
#                                                                  #
#       Script para cargar un Security Group a la aplicacion      #
#                                                                  #
####################################################################

# Required to sign in as a tenant admin
Connect-AzureAD

# Create an Azure AD security group
$group = New-AzureADGroup -DisplayName "KustodyaDefaultSecurityGroup" -SecurityEnabled $true -MailEnabled $false -MailNickName notSet

# Add the service principal to the group
Add-AzureADGroupMember -ObjectId $($group.ObjectId) -RefObjectId $($sp.ObjectId)
# Add-AzureADGroupMember -ObjectId $($group.ObjectId) -RefObjectId '901e7969-203d-4ecc-9a72-762b61fae98c'