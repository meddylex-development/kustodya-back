using Kustodya.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Tercero : BaseEntity
    {
        private Tercero()
        {
            
        }
        
        ///<sumary>
        ///Crear persona natural
        ///</sumary>
        public Tercero(int entidadId, string numeroId, TipoIdentificacion tipoIdentificacion, string primerNombre, string primerApellido)
        {
            EntidadId = entidadId;
            NumeroId = numeroId;
            // TODO: Agregar validacion de tipos de persona permitidos para personas naturales
            TipoId = tipoIdentificacion;
            PrimerNombre = primerNombre;
            PrimerApellido = primerApellido;
            TipoPersona =  TiposPersona.Natural;
        }

        public Tercero(int entidadId, string numeroId, TipoIdentificacion tipoIdentificacion, string razonSocial)
        {
            EntidadId = entidadId;
            NumeroId = numeroId;
            // TODO: [PK-779] Agregar validacion de tipos de persona permitidos para personas juridicas
            TipoId = tipoIdentificacion;
            TipoPersona =  TiposPersona.Jurídica;
            RazonSocial = razonSocial;
            // TODO: [PK-780] Agregar calculo del numero de verificacion del nit
            DigitoVerificacion = CalcularDigitoVerificacion();
            RazonSocial = razonSocial;
        }

        public TiposPersona TipoPersona { get; private set; }
        public TipoIdentificacion TipoId { get; private set; }
        public string NumeroId { get; private set; }
        public int EntidadId { get; private set; }
        public string RazonSocial { get; private set; }
        public string PrimerNombre { get; private set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; private set; }
        public string SegundoApellido { get; set; }
        public int DigitoVerificacion { get; private set; }
        public long NumeroComprobante { get; set; }
        public DateTime FechaComprobante { get; set; }
        public long CodigoContable { get; set; }
        public int ValorCredito { get; set; }
        public int ValorDebito { get; set; }
        public string CodigoContabilidad { get; set; }
        public string CentroCosto { get; set; }
        public DateTime FechaCorte { get; set; }

        private int CalcularDigitoVerificacion()
        {
            int n;
            bool isNumeric = int.TryParse(NumeroId, out n);
            if (!isNumeric)
                return 0;
            string unNit = NumeroId;
            string miTemp;
            int miContador;
            int miResiduo;
            int miChequeo;
            int[] miArregloPA = new int[15];
            miArregloPA[0] = 3;
            miArregloPA[1] = 7;
            miArregloPA[2] = 13;
            miArregloPA[3] = 17;
            miArregloPA[4] = 19;
            miArregloPA[5] = 23;
            miArregloPA[6] = 29;
            miArregloPA[7] = 37;
            miArregloPA[8] = 41;
            miArregloPA[9] = 43;
            miArregloPA[10] = 47;
            miArregloPA[11] = 53;
            miArregloPA[12] = 59;
            miArregloPA[13] = 67;
            miArregloPA[14] = 71;
            miChequeo = 0;
            miResiduo = 0;
            for (miContador = 0; miContador < unNit.Length; miContador++)
            {
                miTemp = unNit[(unNit.Length - 1) - miContador].ToString();
                miChequeo = miChequeo + (Convert.ToInt32(miTemp) * miArregloPA[miContador]);
            }
            miResiduo = miChequeo % 11;
            if (miResiduo > 1)
                return 11 - miResiduo;
            return miResiduo;
        }
    }
}
