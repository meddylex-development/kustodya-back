using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Rethus
{
    public class tblRethusQuerys
    {
        public int iIDRethusQuerys { get; set; }
        public int iIDTask { get; set; }
        public int iIDSearchType { get; set; }
        public int iIDQueryState { get; set; }
        public int? iIDRethusIdentificationType { get; set; }
        public string tIdentificationNumber { get; set; }
        public string tFirstName { get; set; }
        public string tSecondName { get; set; }
        public string tLastName { get; set; }
        public string tSecondLastName { get; set; }
        public bool? bIsInRethus { get; set; }
        public int? iIDEntidad { get; set; }
    }
}
