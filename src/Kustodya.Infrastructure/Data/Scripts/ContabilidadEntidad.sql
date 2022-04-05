IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[DepuracionesContables] DROP CONSTRAINT [FK_DepuracionesContables_Contabilidades_CodigoContabilidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Movimientos] DROP CONSTRAINT [FK_Movimientos_CentroBeneficio_CentroBeneficioId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Pucs] DROP CONSTRAINT [FK_Pucs_Contabilidades_CodigoContabilidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Segmento] DROP CONSTRAINT [FK_Segmento_DepuracionesContables_Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DROP TABLE [Contabilidad].[CentroBeneficio];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DROP INDEX [IX_Pucs_CodigoContabilidad] ON [Contabilidad].[Pucs];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DROP INDEX [IX_DepuracionesContables_CodigoContabilidad] ON [Contabilidad].[DepuracionesContables];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Contabilidades] DROP CONSTRAINT [PK_Contabilidades];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[Pucs]') AND [c].[name] = N'CodigoContabilidad');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[Pucs] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Contabilidad].[Pucs] DROP COLUMN [CodigoContabilidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[DepuracionesContables]') AND [c].[name] = N'CodigoContabilidad');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[DepuracionesContables] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Contabilidad].[DepuracionesContables] DROP COLUMN [CodigoContabilidad];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[Segmento]') AND [c].[name] = N'Id');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[Segmento] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Contabilidad].[Segmento] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Segmento] ADD [Id] int NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Pucs] ADD [ContabilidadId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Pucs] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DROP INDEX [IX_Movimientos_DepuracionContableId] ON [Contabilidad].[Movimientos];
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[Movimientos]') AND [c].[name] = N'DepuracionContableId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[Movimientos] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Contabilidad].[Movimientos] ALTER COLUMN [DepuracionContableId] uniqueidentifier NOT NULL;
    CREATE INDEX [IX_Movimientos_DepuracionContableId] ON [Contabilidad].[Movimientos] ([DepuracionContableId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[Movimientos]') AND [c].[name] = N'Id');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[Movimientos] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Contabilidad].[Movimientos] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Movimientos] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Movimientos] ADD [EntidadId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[DepuracionesContables]') AND [c].[name] = N'Id');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[DepuracionesContables] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Contabilidad].[DepuracionesContables] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[DepuracionesContables] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[DepuracionesContables] ADD [ContabilidadId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contabilidad].[Contabilidades]') AND [c].[name] = N'Codigo');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Contabilidad].[Contabilidades] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Contabilidad].[Contabilidades] ALTER COLUMN [Codigo] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Contabilidades] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Contabilidades] ADD [EntidadId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Contabilidades] ADD CONSTRAINT [PK_Contabilidades] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE TABLE [Contabilidad].[CentroCosto] (
        [Id] int NOT NULL IDENTITY,
        [Codigo] nvarchar(max) NULL,
        [SegmentoId] int NULL,
        [RegionalId] int NULL,
        CONSTRAINT [PK_CentroCosto] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CentroCosto_Regional_RegionalId] FOREIGN KEY ([RegionalId]) REFERENCES [Contabilidad].[Regional] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_CentroCosto_Segmento_SegmentoId] FOREIGN KEY ([SegmentoId]) REFERENCES [Contabilidad].[Segmento] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE INDEX [IX_Pucs_ContabilidadId] ON [Contabilidad].[Pucs] ([ContabilidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE INDEX [IX_DepuracionesContables_ContabilidadId] ON [Contabilidad].[DepuracionesContables] ([ContabilidadId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE INDEX [IX_DepuracionesContables_SegmentoId] ON [Contabilidad].[DepuracionesContables] ([SegmentoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE UNIQUE INDEX [IX_Contabilidades_EntidadId_Codigo] ON [Contabilidad].[Contabilidades] ([EntidadId], [Codigo]) WHERE [Codigo] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE INDEX [IX_CentroCosto_RegionalId] ON [Contabilidad].[CentroCosto] ([RegionalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    CREATE INDEX [IX_CentroCosto_SegmentoId] ON [Contabilidad].[CentroCosto] ([SegmentoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[DepuracionesContables] ADD CONSTRAINT [FK_DepuracionesContables_Contabilidades_ContabilidadId] FOREIGN KEY ([ContabilidadId]) REFERENCES [Contabilidad].[Contabilidades] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[DepuracionesContables] ADD CONSTRAINT [FK_DepuracionesContables_Segmento_SegmentoId] FOREIGN KEY ([SegmentoId]) REFERENCES [Contabilidad].[Segmento] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Movimientos] ADD CONSTRAINT [FK_Movimientos_CentroCosto_CentroBeneficioId] FOREIGN KEY ([CentroBeneficioId]) REFERENCES [Contabilidad].[CentroCosto] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    ALTER TABLE [Contabilidad].[Pucs] ADD CONSTRAINT [FK_Pucs_Contabilidades_ContabilidadId] FOREIGN KEY ([ContabilidadId]) REFERENCES [Contabilidad].[Contabilidades] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200617181339_ContabilidadEntidad')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200617181339_ContabilidadEntidad', N'3.1.2');
END;

GO

