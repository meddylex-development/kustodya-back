namespace Kustodya.ApplicationCore.Constants
{
    public enum TipoCIE : int
    {
        DIAGNOSTICO = 1,
        SINTOMA = 2,
        SIGNO = 3
    }

    public enum TipoTranscripcion : int
    {
        EnfermedadComun = 1,
        LicenciaMaternidad = 2,
        LicenciaPaternidad = 3
    }

    public enum OCRExtractionMethod : int
    {
        Tesseract = 1,
        IBMWatson = 2,
        Azure = 3,
        Google_VisionAI = 4,
        iTextSharp = 5,
        Word = 6
    }

    public enum IncapacidadClassification : int
    {
        ANY = 0,
        CRUZ_ROJA = 1,
        MEDIMAS = 2,
        SANITAS = 3
    }

    public enum ClasificacionIncapacidad : int
    {
        INICIAL = 0,
        PRORROGA = 1,
    }

    public enum OrigenIncapacidad : long
    {
        Accidente_trabajo = 3549,
        Enfermedad_general = 3550,
        Enfermedad_laboral = 3551
    }

    public enum Etiologias : byte
    {
        Autoinmune = 1,
        Cardiovacular,
        Congenita,
        Degenerativa,

    }

    public enum Conceptos : byte
    {
        Favorable = 1,
        Desfavorable,

    }

    public enum TipoSecuelas : byte
    {
        Anatomica = 1,
        Funcional,

    }
    public enum Pronosticos : byte
    {
        Bueno = 1,
        Regular,
        Malo,

    }
    
    public enum FinalidadTratamientos : byte
    {
        Palativo = 1,
        Culativo,

    }

    public enum PlazoCorto : byte
    {
        Bueno = 1,
        Regular,
        Malo,

    }

    public enum PlazoLargo : byte
    {
            Bueno = 1,
            Regular,
            Malo,
    }

    public enum Origen : byte
    {
        Comun = 1,
        
    }

    public enum Subtabla
    {
        TipoIdentificacion = 1,
        Genero = 2,
        ciiu = 3,
        EstadoSucursal = 4,
        ClaseRiesgo = 5,
        CodigoRiesgo = 6,
        EstadoCivil = 7,
        FormacionEducativa = 8,
        TipoMoneda = 9,
        TipoVinculacion = 10,
        EstadoVigencia = 11,
        TipoPolitica = 12,
        RHSI = 13,
        Legislacion = 14,
        TipoActa = 15,
        ClaseActa = 16,
        ClaseSoporte = 17,
        NivelDeficiencia = 18,
        NivelExposicion = 19,
        NivelConsecuencia = 20,
        Actividades = 21,
        Tareas = 22,
        EfectosPosibles = 23,
        ControlesFuente = 24,
        ControlesMedio = 25,
        ControlesIndividuo = 26,
        MedidasControlesIngenieria = 27,
        MedidasControlesAdministrativos = 28,
        MedidasProteccionPersonal = 29,
        CarrerasTecnicas = 30,
        CarrerasTecnologica = 31,
        CarrerasProfesional = 32,
        Especializaciones = 33,
        NivelAcademico = 34,
        ObjetivosCargo = 35,
        FuncionesSST = 36,
        Periodicidad = 37,
        FuncionesAmbientales = 38,
        ResponsabilidadesSST = 39,
        Idiomas = 40,
        NivelLectura = 41,
        NivelEscritura = 42,
        NivelConversacion = 43,
        CompetenciasCorporativas = 44,
        NivelRequerido = 45,
        CompetenciasFuncionales = 46,
        Responsabilidades = 47,
        NivelAutoridad = 48,
        TipoReunion = 49,
        EstadoCompromiso = 50,
        TipoTarea = 51,
        TipoEvento = 52,
        TipoVinculador = 53,
        Zona = 54,
        JornadaHabitual = 56,
        TipoIPS = 57,
        AgentesDeLesion = 58,
        ParteDelCuerpoAfectada = 59,
        LesionODanyoAparente = 60,
        Estándares = 61,
        EstadoNorma = 62,
        TipoDocumentoNorma = 63,
        PerfilDocumentos = 64,
        TipoCapacitacion = 65,
        TipoPoliticaEstandar = 66,
        NivelDeProceso = 67,
        MecanismoDelAccidente = 68,
        CostadoCuerpo = 69,
        ATAnalisisCausas = 70,
        ActosSubEstandar = 71,
        CondicionesSubestandar = 72,
        FactoresPersonales = 73,
        Factoresdetrabajo = 74,
        ControlMedidaSeguridad = 75,
        MedidasAccionesCorrectivas = 76,
        TipoDanyo = 77,
        TipoPersonaAT = 78,
        TipoCapacitador = 84,
        TipoRecobro = 85,
        TipoDocumento = 86,
        TipoDiagnostico = 87,
        SoporteRecobro = 88,
        SoporteRecobroDocumentos = 89,
        Soportediagnostico = 90,
        SoporteUsuario = 91,
        SoporteRecobroDocumentoDiagnosticoMedicamento = 92,
        TipoInvimaEstadoMedicamentos = 93,
        TipoCalendario = 94,
        OrigenIncapacidad = 95,
        TipoAtencion = 96,
        Calles = 97,
        LetrasCalles = 98,
        RedesSociales = 99
    }

    public enum Sexos : long
    {
        Masculino = 1,
        Femenino
    }

    public enum TipoIdentificacion : int
    {
        Cédula_de_ciudadanía = 9,
        Nit_Empresarial = 10,
        Nit_Extranjeria = 11,
        Cédula_Extranjeria = 12,
        Pasaporte = 3553,
        Permiso_Especial = 3554,
        Registro_Civil = 3555,
        Tarjeta_Identidad = 3556
    }

    public enum Multivalores : int
    {
        
    }
    public enum TipoCliente { 
        TipoCliente1 = 1,
        TipoCliente2 = 2
    }
    public enum Regimen
    {
        Común = 1,
        Simplificado = 2
    }

    public enum Naturaleza : int
    {
        Pública = 1,
        Privada = 2
    }
    public enum Sociedad : int
    {
        Colectivas = 1,
        Comandita_Simple = 2,
        Comandita_por_Acciones = 3,
        Capital_e_Industria = 4,
        Responsabilidad_Limitada_SRL = 5,
        Anónimas_SA = 6,

    }
    public enum Via : int
    {
        Autopista = 1,
        Avenida = 2,
        Avenida_Calle = 3,
        Avenida_Carrera = 4,
        Bulevar = 5,
        Calle = 6,
        Carrera = 7,
        Carretera = 8,
        Circular = 9,
        Circunvalar = 10,
        Cuentas_Corridas = 11,
        Diagonal = 12,
        Pasaje = 13,
        Paseo = 14,
        Peatonal = 15,
        Transversal = 16,
        Troncal = 17,
        Variante = 18,
        Vía = 19
    }
    public enum RedSocial : int
    {
        Instagram = 1,
        FaceBook = 2,
        Twitter = 3,
    }
    public enum TipoEntidad : int
    {
        Privada = 1,
        Publica = 2
    }
    public enum TipoRelacion : int
    {
        Padre = 1,
        Hermano = 2
    }
    public enum TiposPersona : int
    {
        Natural = 1,
        Jurídica = 2
    }
}