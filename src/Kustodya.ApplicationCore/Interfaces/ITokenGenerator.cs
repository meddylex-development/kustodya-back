//using ComponentSpace.Saml2;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces
{
    public interface ITokenGenerator
    {
        string CreateJwtSecurityToken(Entities.TblUsuarios usuario);
    }
}