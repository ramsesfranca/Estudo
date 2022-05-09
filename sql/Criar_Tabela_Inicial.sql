IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(250) NOT NULL,
    [Rg] varchar(9) NOT NULL,
    [Nascimento] datetime2 NOT NULL,
    [Endereco] varchar(250) NULL,
    [Bairro] varchar(250) NULL,
    [Cidade] varchar(250) NULL,
    [Cep] varchar(10) NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Telefones] (
    [Numero] varchar(20) NOT NULL,
    [TipoTelefone] int NOT NULL,
    [ClienteId] uniqueidentifier NULL,
    CONSTRAINT [PK_Telefones] PRIMARY KEY ([Numero]),
    CONSTRAINT [FK_Telefones_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Telefones_ClienteId] ON [Telefones] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220509165049_Criar_Tabela_Inicial', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Servicos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(250) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220509170854_Criar_Tabela_Servico', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Chales] (
    [Id] uniqueidentifier NOT NULL,
    [Localizacao] varchar(250) NOT NULL,
    [Capacidade] int NOT NULL,
    [ValorAltaEstacao] decimal(18,2) NOT NULL,
    [ValorBaixaEstacao] decimal(18,2) NOT NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Chales] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Items] (
    [Nome] varchar(80) NOT NULL,
    [Descricao] varchar(250) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Nome])
);
GO

CREATE TABLE [ChaleItem] (
    [ChalesId] uniqueidentifier NOT NULL,
    [ItensNome] varchar(80) NOT NULL,
    CONSTRAINT [PK_ChaleItem] PRIMARY KEY ([ChalesId], [ItensNome]),
    CONSTRAINT [FK_ChaleItem_Chales_ChalesId] FOREIGN KEY ([ChalesId]) REFERENCES [Chales] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ChaleItem_Items_ItensNome] FOREIGN KEY ([ItensNome]) REFERENCES [Items] ([Nome]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ChaleItem_ItensNome] ON [ChaleItem] ([ItensNome]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220509180246_Criar_Tabela_Chale_Item', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Hospedagens] (
    [Id] uniqueidentifier NOT NULL,
    [ChaleId] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Estado] int NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFim] datetime2 NOT NULL,
    [QtdPessoas] int NOT NULL,
    [Desconto] int NOT NULL,
    [ValorFinal] decimal(18,2) NOT NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Hospedagens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Hospedagens_Chales_ChaleId] FOREIGN KEY ([ChaleId]) REFERENCES [Chales] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Hospedagens_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Hospedagem_Servico] (
    [DataServico] datetime2 NOT NULL DEFAULT (getdate()),
    [HospedagemId] uniqueidentifier NOT NULL,
    [ServicoId] uniqueidentifier NOT NULL,
    [ValorServico] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Hospedagem_Servico] PRIMARY KEY ([DataServico]),
    CONSTRAINT [FK_Hospedagem_Servico_Hospedagens_HospedagemId] FOREIGN KEY ([HospedagemId]) REFERENCES [Hospedagens] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Hospedagem_Servico_Servicos_ServicoId] FOREIGN KEY ([ServicoId]) REFERENCES [Servicos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Hospedagem_Servico_HospedagemId] ON [Hospedagem_Servico] ([HospedagemId]);
GO

CREATE INDEX [IX_Hospedagem_Servico_ServicoId] ON [Hospedagem_Servico] ([ServicoId]);
GO

CREATE INDEX [IX_Hospedagens_ChaleId] ON [Hospedagens] ([ChaleId]);
GO

CREATE INDEX [IX_Hospedagens_ClienteId] ON [Hospedagens] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220509195401_Criar_Tabela_Hospedagem_Servico', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Servicos]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Servicos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Servicos] ADD DEFAULT (NEWID()) FOR [Id];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hospedagens]') AND [c].[name] = N'Id');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Hospedagens] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Hospedagens] ADD DEFAULT (NEWID()) FOR [Id];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Id');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Clientes] ADD DEFAULT (NEWID()) FOR [Id];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chales]') AND [c].[name] = N'Id');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Chales] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Chales] ADD DEFAULT (NEWID()) FOR [Id];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220509235012_Modificacao_Id', N'5.0.9');
GO

COMMIT;
GO

