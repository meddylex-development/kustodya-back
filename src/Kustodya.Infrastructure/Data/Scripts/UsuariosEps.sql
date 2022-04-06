IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200211211059_First')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200211211059_First', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDSecuela');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDSecuela] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDRemision');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDRemision] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDPronostico');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDPronostico] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDPlazoLargo');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDPlazoLargo] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDPlazoCorto');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDPlazoCorto] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDFinalidadTratamiento');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDFinalidadTratamiento] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[tblConceptoRehabilitacion]') AND [c].[name] = N'iIDConcepto');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Incapacidades].[tblConceptoRehabilitacion] ALTER COLUMN [iIDConcepto] bigint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212165848_Second')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212165848_Second', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    IF SCHEMA_ID(N'Conceptos') IS NULL EXEC(N'CREATE SCHEMA [Conceptos];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[Cie10DiagnosticosConceptos] (
        [Id] bigint NOT NULL IDENTITY,
        [Cie10DiagnosticoConcepto] nvarchar(max) NULL,
        [FechaCreacion] datetime2 NOT NULL,
        [Activo] int NOT NULL,
        CONSTRAINT [PK_Cie10DiagnosticosConceptos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[Conceptos] (
        [Id] bigint NOT NULL IDENTITY,
        [Concepto] nvarchar(max) NULL,
        CONSTRAINT [PK_Conceptos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[ConceptosMedicos] (
        [Id] bigint NOT NULL IDENTITY,
        [ConceptoMedico] nvarchar(max) NULL,
        CONSTRAINT [PK_ConceptosMedicos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[DescripcionSecuelas] (
        [Id] bigint NOT NULL IDENTITY,
        [Descripcion] nvarchar(max) NULL,
        CONSTRAINT [PK_DescripcionSecuelas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[Etiologias] (
        [Id] bigint NOT NULL IDENTITY,
        [Etiologia] nvarchar(max) NULL,
        CONSTRAINT [PK_Etiologias] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[FinalidadTratamientos] (
        [Id] bigint NOT NULL IDENTITY,
        [FinalidadTratamiento] nvarchar(max) NULL,
        CONSTRAINT [PK_FinalidadTratamientos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[NotaRemisiones] (
        [Id] bigint NOT NULL IDENTITY,
        [NotaRemision] nvarchar(max) NULL,
        CONSTRAINT [PK_NotaRemisiones] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[PlazoCorto] (
        [Id] bigint NOT NULL IDENTITY,
        [Plazo] nvarchar(max) NULL,
        CONSTRAINT [PK_PlazoCorto] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[PlazoLargo] (
        [Id] bigint NOT NULL IDENTITY,
        [Plazo] bigint NOT NULL,
        CONSTRAINT [PK_PlazoLargo] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[Pronosticos] (
        [Id] bigint NOT NULL IDENTITY,
        [Pronostico] nvarchar(max) NULL,
        CONSTRAINT [PK_Pronosticos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[Remisiones] (
        [Id] bigint NOT NULL IDENTITY,
        [Remision] nvarchar(max) NULL,
        CONSTRAINT [PK_Remisiones] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[TerapeuticaPosibles] (
        [Id] bigint NOT NULL IDENTITY,
        [TerapeuticaPosible] nvarchar(max) NULL,
        CONSTRAINT [PK_TerapeuticaPosibles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[TipoSecuelas] (
        [Id] bigint NOT NULL IDENTITY,
        [TipoSecuela] nvarchar(max) NULL,
        CONSTRAINT [PK_TipoSecuelas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Incapacidades].[Afiliado] (
        [Id] int NOT NULL IDENTITY,
        [TipoAfiliacion] int NULL,
        [Activo] bit NULL,
        [Sexo] int NULL,
        [FechaNacimiento] datetime2 NULL,
        [PermisoTrabajo] bit NULL,
        [Pensionado] bit NULL,
        CONSTRAINT [PK_Afiliado] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Conceptos].[ConceptoRehabilitacion] (
        [Id] bigint NOT NULL IDENTITY,
        [ConcetosMedicosId] bigint NOT NULL,
        [FechaCreacion] datetime2 NOT NULL,
        [PacientesId] int NOT NULL,
        [DiagnosticoId] bigint NOT NULL,
        [DescripcionSecuelasId] bigint NOT NULL,
        [EsFarmacologico] bit NOT NULL,
        [EsQuirurgico] bit NOT NULL,
        [EsTerapiaFisica] bit NOT NULL,
        [EsTerapiaOcupaciona] bit NOT NULL,
        [EsFonoaudiologia] bit NOT NULL,
        [EsOtrosTratamientos] bit NOT NULL,
        [DescripcionTratamientos] nvarchar(max) NULL,
        [ResumenHistoriaClinica] nvarchar(max) NULL,
        [OtrosTramites] nvarchar(max) NULL,
        [Origen] nvarchar(max) NULL,
        [FinalidadTratamientosId] bigint NOT NULL,
        [PlazoCortoId] bigint NOT NULL,
        [PlazoLargoId] bigint NOT NULL,
        [RemisionesId] bigint NOT NULL,
        [ConceptosId] bigint NOT NULL,
        [NotaRemisionesId] bigint NOT NULL,
        [PronosticosId] bigint NOT NULL,
        [MedicosId] bigint NOT NULL,
        [EtiologiasId] bigint NOT NULL,
        [TipoSecuelasId] bigint NOT NULL,
        [PronosticoFavorable] bit NOT NULL,
        [DesPronosticoFavorable] nvarchar(max) NULL,
        [PronosticoDesfavorableAcumulados] bit NOT NULL,
        [DesPronosticoDesfavorableAcumulados] nvarchar(max) NULL,
        [PronosticoDesfavorable] bit NOT NULL,
        [DesPronosticoDesfavorable] nvarchar(max) NULL,
        [ConceptosMedicosId] bigint NULL,
        [TblPacientesIIdpaciente] int NULL,
        [TblDiagnosticosIIddiagnostico] int NULL,
        CONSTRAINT [PK_ConceptoRehabilitacion] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ConceptoRehabilitacion_Conceptos_ConceptosId] FOREIGN KEY ([ConceptosId]) REFERENCES [Conceptos].[Conceptos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_ConceptosMedicos_ConceptosMedicosId] FOREIGN KEY ([ConceptosMedicosId]) REFERENCES [Conceptos].[ConceptosMedicos] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId] FOREIGN KEY ([DescripcionSecuelasId]) REFERENCES [Conceptos].[DescripcionSecuelas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_Etiologias_EtiologiasId] FOREIGN KEY ([EtiologiasId]) REFERENCES [Conceptos].[Etiologias] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_FinalidadTratamientos_FinalidadTratamientosId] FOREIGN KEY ([FinalidadTratamientosId]) REFERENCES [Conceptos].[FinalidadTratamientos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_NotaRemisiones_NotaRemisionesId] FOREIGN KEY ([NotaRemisionesId]) REFERENCES [Conceptos].[NotaRemisiones] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_PlazoCorto_PlazoCortoId] FOREIGN KEY ([PlazoCortoId]) REFERENCES [Conceptos].[PlazoCorto] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId] FOREIGN KEY ([PlazoLargoId]) REFERENCES [Conceptos].[PlazoLargo] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_Pronosticos_PronosticosId] FOREIGN KEY ([PronosticosId]) REFERENCES [Conceptos].[Pronosticos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_Remisiones_RemisionesId] FOREIGN KEY ([RemisionesId]) REFERENCES [Conceptos].[Remisiones] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ConceptoRehabilitacion_tblDiagnosticos_TblDiagnosticosIIddiagnostico] FOREIGN KEY ([TblDiagnosticosIIddiagnostico]) REFERENCES [administracion].[tblDiagnosticos] ([iIDDiagnostico]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ConceptoRehabilitacion_tblPacientes_TblPacientesIIdpaciente] FOREIGN KEY ([TblPacientesIIdpaciente]) REFERENCES [Incapacidades].[tblPacientes] ([iIDPaciente]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId] FOREIGN KEY ([TipoSecuelasId]) REFERENCES [Conceptos].[TipoSecuelas] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE TABLE [Incapacidades].[Incapacidad] (
        [Id] int NOT NULL IDENTITY,
        [IpsNit] nvarchar(max) NULL,
        [FechaAfiliacion] datetime2 NULL,
        [Sexo] int NULL,
        [FechaNacimiento] datetime2 NULL,
        [FechaInicio] datetime2 NULL,
        [FechaFin] datetime2 NULL,
        [FechaRadicacion] datetime2 NULL,
        [AfiliadoId] int NOT NULL,
        [Prorroga] bit NULL,
        CONSTRAINT [PK_Incapacidad] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Incapacidad_Afiliado_AfiliadoId] FOREIGN KEY ([AfiliadoId]) REFERENCES [Incapacidades].[Afiliado] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_ConceptosId] ON [Conceptos].[ConceptoRehabilitacion] ([ConceptosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_ConceptosMedicosId] ON [Conceptos].[ConceptoRehabilitacion] ([ConceptosMedicosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_DescripcionSecuelasId] ON [Conceptos].[ConceptoRehabilitacion] ([DescripcionSecuelasId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_EtiologiasId] ON [Conceptos].[ConceptoRehabilitacion] ([EtiologiasId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_FinalidadTratamientosId] ON [Conceptos].[ConceptoRehabilitacion] ([FinalidadTratamientosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_NotaRemisionesId] ON [Conceptos].[ConceptoRehabilitacion] ([NotaRemisionesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_PlazoCortoId] ON [Conceptos].[ConceptoRehabilitacion] ([PlazoCortoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_PlazoLargoId] ON [Conceptos].[ConceptoRehabilitacion] ([PlazoLargoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_PronosticosId] ON [Conceptos].[ConceptoRehabilitacion] ([PronosticosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_RemisionesId] ON [Conceptos].[ConceptoRehabilitacion] ([RemisionesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_TblDiagnosticosIIddiagnostico] ON [Conceptos].[ConceptoRehabilitacion] ([TblDiagnosticosIIddiagnostico]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_TblPacientesIIdpaciente] ON [Conceptos].[ConceptoRehabilitacion] ([TblPacientesIIdpaciente]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_TipoSecuelasId] ON [Conceptos].[ConceptoRehabilitacion] ([TipoSecuelasId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    CREATE INDEX [IX_Incapacidad_AfiliadoId] ON [Incapacidades].[Incapacidad] ([AfiliadoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217185611_CRHB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200217185611_CRHB', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_PlazoCorto_PlazoCortoId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DROP TABLE [Conceptos].[Cie10DiagnosticosConceptos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DROP TABLE [Conceptos].[TerapeuticaPosibles];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Conceptos].[PlazoCorto] DROP CONSTRAINT [PK_PlazoCorto];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[TipoSecuelas];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[Remisiones];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[Pronosticos];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[PlazoLargo];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    EXEC sp_rename N'[Conceptos].[PlazoCorto]', N'PLazoCorto';
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[PLazoCorto];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[NotaRemisiones];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[FinalidadTratamientos];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[Etiologias];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[DescripcionSecuelas];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[ConceptosMedicos];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    DECLARE @defaultSchema sysname = SCHEMA_NAME();
    EXEC(N'ALTER SCHEMA [' + @defaultSchema + N'] TRANSFER [Conceptos].[Conceptos];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Incapacidad] ADD [AlteracionOFraude] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Incapacidad] ADD [DobleCobro] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Incapacidad] ADD [FraudeEnOtorgacion] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [ActividadimpideRecuperacion] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [AsisteAExamenes] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [AsisteATratamientos] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [CalificacionPcl] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [CalificacionAtel] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [ChrbDesfavorable] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [ConductasContrarias] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Incapacidades].[Afiliado] ADD [DatosFalsos] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [PLazoCorto] ADD CONSTRAINT [PK_PLazoCorto] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    CREATE TABLE [Conceptos].[Diagnostico] (
        [Id] bigint NOT NULL IDENTITY,
        [ConceptoRehabilitacionId] nvarchar(max) NULL,
        [Cie10Id] int NOT NULL,
        [tblCie10IIdcie10] int NULL,
        CONSTRAINT [PK_Diagnostico] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Diagnostico_tblCIE10_tblCie10IIdcie10] FOREIGN KEY ([tblCie10IIdcie10]) REFERENCES [Incapacidades].[tblCIE10] ([iIDCIE10]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    CREATE UNIQUE INDEX [IX_ConceptoRehabilitacion_DiagnosticoId] ON [Conceptos].[ConceptoRehabilitacion] ([DiagnosticoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    CREATE INDEX [IX_Diagnostico_tblCie10IIdcie10] ON [Conceptos].[Diagnostico] ([tblCie10IIdcie10]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_Diagnostico_DiagnosticoId] FOREIGN KEY ([DiagnosticoId]) REFERENCES [Conceptos].[Diagnostico] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_PLazoCorto_PlazoCortoId] FOREIGN KEY ([PlazoCortoId]) REFERENCES [PLazoCorto] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200217224712_CRHB2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200217224712_CRHB2', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_Conceptos_ConceptosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_ConceptosMedicos_ConceptosMedicosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_Etiologias_EtiologiasId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_FinalidadTratamientos_FinalidadTratamientosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_NotaRemisiones_NotaRemisionesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_PLazoCorto_PlazoCortoId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_Pronosticos_PronosticosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_Remisiones_RemisionesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_tblDiagnosticos_TblDiagnosticosIIddiagnostico];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] DROP CONSTRAINT [FK_Diagnostico_tblCIE10_tblCie10IIdcie10];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [Conceptos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [ConceptosMedicos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [DescripcionSecuelas];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [Etiologias];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [NotaRemisiones];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [Pronosticos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP TABLE [Remisiones];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_ConceptosId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_DescripcionSecuelasId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_EtiologiasId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_NotaRemisionesId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_PronosticosId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_RemisionesId] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DROP INDEX [IX_ConceptoRehabilitacion_TblDiagnosticosIIddiagnostico] ON [Conceptos].[ConceptoRehabilitacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'ConceptosId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [ConceptosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'ConcetosMedicosId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [ConcetosMedicosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'DesPronosticoDesfavorable');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [DesPronosticoDesfavorable];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'DesPronosticoDesfavorableAcumulados');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [DesPronosticoDesfavorableAcumulados];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'DesPronosticoFavorable');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [DesPronosticoFavorable];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'DescripcionSecuelasId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [DescripcionSecuelasId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'EtiologiasId');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [EtiologiasId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'MedicosId');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [MedicosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'NotaRemisionesId');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [NotaRemisionesId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'PronosticoDesfavorable');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [PronosticoDesfavorable];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'PronosticoDesfavorableAcumulados');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [PronosticoDesfavorableAcumulados];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'PronosticoFavorable');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [PronosticoFavorable];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'PronosticosId');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [PronosticosId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'TblDiagnosticosIIddiagnostico');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [TblDiagnosticosIIddiagnostico];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[Diagnostico].[tblCie10IIdcie10]', N'TblCie10IIdcie10', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[Diagnostico].[IX_Diagnostico_tblCie10IIdcie10]', N'IX_Diagnostico_TblCie10IIdcie10', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[PlazoCortoId]', N'plazoCortoId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[Origen]', N'origen', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[FinalidadTratamientosId]', N'finalidadTratamientosId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[RemisionesId]', N'empleadoId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[OtrosTramites]', N'DescripcionSecuelas', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[DescripcionTratamientos]', N'DescripcionOtrosTramites', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[ConceptosMedicosId]', N'TblEmpleadosIIdempleado', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[IX_ConceptoRehabilitacion_PlazoCortoId]', N'IX_ConceptoRehabilitacion_plazoCortoId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[IX_ConceptoRehabilitacion_FinalidadTratamientosId]', N'IX_ConceptoRehabilitacion_finalidadTratamientosId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    EXEC sp_rename N'[Conceptos].[ConceptoRehabilitacion].[IX_ConceptoRehabilitacion_ConceptosMedicosId]', N'IX_ConceptoRehabilitacion_TblEmpleadosIIdempleado', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] ADD [Etiologia] tinyint NOT NULL DEFAULT CAST(0 AS tinyint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] ADD [FechaIncapacidad] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'TipoSecuelasId');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ALTER COLUMN [TipoSecuelasId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'PlazoLargoId');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ALTER COLUMN [PlazoLargoId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'plazoCortoId');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ALTER COLUMN [plazoCortoId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'origen');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ALTER COLUMN [origen] tinyint NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'finalidadTratamientosId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ALTER COLUMN [finalidadTratamientosId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [Etiologias] tinyint NOT NULL DEFAULT CAST(0 AS tinyint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [FechaIncapacidad] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [pronosticos] tinyint NOT NULL DEFAULT CAST(0 AS tinyint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId] FOREIGN KEY ([PlazoLargoId]) REFERENCES [PlazoLargo] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_tblEmpleados_TblEmpleadosIIdempleado] FOREIGN KEY ([TblEmpleadosIIdempleado]) REFERENCES [negocio].[tblEmpleados] ([iIDEmpleado]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId] FOREIGN KEY ([TipoSecuelasId]) REFERENCES [TipoSecuelas] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_FinalidadTratamientos_finalidadTratamientosId] FOREIGN KEY ([finalidadTratamientosId]) REFERENCES [FinalidadTratamientos] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_PLazoCorto_plazoCortoId] FOREIGN KEY ([plazoCortoId]) REFERENCES [PLazoCorto] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] ADD CONSTRAINT [FK_Diagnostico_tblCIE10_TblCie10IIdcie10] FOREIGN KEY ([TblCie10IIdcie10]) REFERENCES [Incapacidades].[tblCIE10] ([iIDCIE10]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218160158_CRHB3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200218160158_CRHB3', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[Incapacidad]') AND [c].[name] = N'Sexo');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[Incapacidad] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Incapacidades].[Incapacidad] DROP COLUMN [Sexo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[Diagnostico]') AND [c].[name] = N'Etiologia');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[Diagnostico] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Conceptos].[Diagnostico] DROP COLUMN [Etiologia];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'Etiologias');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [Etiologias];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'pronosticos');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [pronosticos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Incapacidades].[Incapacidad] ADD [DiagnosticoId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] ADD [EtiologiaId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [EtiologiasId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [pronosticosId] bigint NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE TABLE [Diagnostico] (
        [Id] int NOT NULL IDENTITY,
        [CodigoCie10] nvarchar(max) NULL,
        [Descripcion] nvarchar(max) NULL,
        [Capitulo] nvarchar(max) NULL,
        [TituloCapitulo] nvarchar(max) NULL,
        [Caracter] nvarchar(max) NULL,
        [Categoria] nvarchar(max) NULL,
        [Cie] nvarchar(max) NULL,
        [DiasMaxConsulta] int NOT NULL,
        [DiasMaxAcumulados] int NOT NULL,
        [TipoCieId] int NULL,
        [Sexo] int NOT NULL,
        [EdadInferior] int NOT NULL,
        [EdadSuperior] int NOT NULL,
        [TipoCie] int NOT NULL,
        CONSTRAINT [PK_Diagnostico] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE TABLE [Etiologias] (
        [Id] bigint NOT NULL IDENTITY,
        [Etiologia] nvarchar(max) NULL,
        CONSTRAINT [PK_Etiologias] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE TABLE [Pronosticos] (
        [Id] bigint NOT NULL IDENTITY,
        [Pronostico] nvarchar(max) NULL,
        CONSTRAINT [PK_Pronosticos] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE TABLE [Cie10Correlacion] (
        [Id] int NOT NULL IDENTITY,
        [Cie10Id] int NOT NULL,
        [CorrelacionId] nvarchar(max) NULL,
        [DiagnosticoId] int NULL,
        CONSTRAINT [PK_Cie10Correlacion] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Cie10Correlacion_Diagnostico_DiagnosticoId] FOREIGN KEY ([DiagnosticoId]) REFERENCES [Diagnostico] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE INDEX [IX_Incapacidad_DiagnosticoId] ON [Incapacidades].[Incapacidad] ([DiagnosticoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE INDEX [IX_Diagnostico_EtiologiaId] ON [Conceptos].[Diagnostico] ([EtiologiaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_EtiologiasId] ON [Conceptos].[ConceptoRehabilitacion] ([EtiologiasId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE INDEX [IX_ConceptoRehabilitacion_pronosticosId] ON [Conceptos].[ConceptoRehabilitacion] ([pronosticosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    CREATE INDEX [IX_Cie10Correlacion_DiagnosticoId] ON [Cie10Correlacion] ([DiagnosticoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_Etiologias_EtiologiasId] FOREIGN KEY ([EtiologiasId]) REFERENCES [Etiologias] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_Pronosticos_pronosticosId] FOREIGN KEY ([pronosticosId]) REFERENCES [Pronosticos] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Conceptos].[Diagnostico] ADD CONSTRAINT [FK_Diagnostico_Etiologias_EtiologiaId] FOREIGN KEY ([EtiologiaId]) REFERENCES [Etiologias] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    ALTER TABLE [Incapacidades].[Incapacidad] ADD CONSTRAINT [FK_Incapacidad_Diagnostico_DiagnosticoId] FOREIGN KEY ([DiagnosticoId]) REFERENCES [Diagnostico] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200219152642_CRHB4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200219152642_CRHB4', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Incapacidades].[Incapacidad]') AND [c].[name] = N'FechaNacimiento');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Incapacidades].[Incapacidad] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Incapacidades].[Incapacidad] DROP COLUMN [FechaNacimiento];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'DescripcionSecuelas');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [DescripcionSecuelas];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Conceptos].[ConceptoRehabilitacion]') AND [c].[name] = N'FechaIncapacidad');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] DROP COLUMN [FechaIncapacidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Diagnostico]') AND [c].[name] = N'EdadInferior');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Diagnostico] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [Diagnostico] DROP COLUMN [EdadInferior];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Diagnostico]') AND [c].[name] = N'EdadSuperior');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Diagnostico] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [Diagnostico] DROP COLUMN [EdadSuperior];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD [DescripcionSecuelasId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    ALTER TABLE [Diagnostico] ADD [EdadMaxima] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    ALTER TABLE [Diagnostico] ADD [EdadMinima] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    CREATE TABLE [DescripcionSecuelas] (
        [Id] bigint NOT NULL IDENTITY,
        [ConceptoRehabilitacionId] nvarchar(max) NULL,
        [TipoSecuelas] tinyint NOT NULL,
        [Descripcion] nvarchar(max) NULL,
        [Pronosticos] tinyint NOT NULL,
        CONSTRAINT [PK_DescripcionSecuelas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    CREATE UNIQUE INDEX [IX_ConceptoRehabilitacion_DescripcionSecuelasId] ON [Conceptos].[ConceptoRehabilitacion] ([DescripcionSecuelasId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    ALTER TABLE [Conceptos].[ConceptoRehabilitacion] ADD CONSTRAINT [FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId] FOREIGN KEY ([DescripcionSecuelasId]) REFERENCES [DescripcionSecuelas] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200221172309_CRHB6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200221172309_CRHB6', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    DROP TABLE [Cie10Correlacion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    DROP TABLE [Incapacidades].[Incapacidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    DROP TABLE [Incapacidades].[Afiliado];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    DROP TABLE [Diagnostico];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    ALTER TABLE [seguridad].[tblMenu] ADD [EsReporte] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    ALTER TABLE [seguridad].[tblMenu] ADD [ReporteGroupId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    ALTER TABLE [seguridad].[tblMenu] ADD [ReporteId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200326234943_QuitarMallaValidadora')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200326234943_QuitarMallaValidadora', N'3.1.2');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200413170007_UsuarioEPS')
BEGIN
    CREATE TABLE [UsuarioEPSs] (
        [Id] int NOT NULL IDENTITY,
        [TblEpsId] bigint NOT NULL,
        [TblUsuariosId] int NOT NULL,
        [Activo] bit NOT NULL,
        CONSTRAINT [PK_UsuarioEPSs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UsuarioEPSs_tblEPS_TblEpsId] FOREIGN KEY ([TblEpsId]) REFERENCES [negocio].[tblEPS] ([iIDEPS]) ON DELETE CASCADE,
        CONSTRAINT [FK_UsuarioEPSs_tblUsuarios_TblUsuariosId] FOREIGN KEY ([TblUsuariosId]) REFERENCES [seguridad].[tblUsuarios] ([iIDUsuario]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200413170007_UsuarioEPS')
BEGIN
    CREATE INDEX [IX_UsuarioEPSs_TblEpsId] ON [UsuarioEPSs] ([TblEpsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200413170007_UsuarioEPS')
BEGIN
    CREATE INDEX [IX_UsuarioEPSs_TblUsuariosId] ON [UsuarioEPSs] ([TblUsuariosId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200413170007_UsuarioEPS')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200413170007_UsuarioEPS', N'3.1.2');
END;

GO

