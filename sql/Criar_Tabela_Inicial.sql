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

CREATE TABLE [Categorias] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(250) NOT NULL,
    [Descricao] varchar(500) NOT NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [CategoriaId] uniqueidentifier NOT NULL,
    [Nome] varchar(250) NOT NULL,
    [Descricao] varchar(500) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Quantidade] int NOT NULL,
    [Altura] int NULL,
    [Largura] int NULL,
    [Profundidade] int NULL,
    [TipoProduto] int NOT NULL,
    [Ativo] bit NOT NULL,
    [DataHoraCadastro] datetime2 NOT NULL,
    [DataHoraModificado] datetime2 NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Produtos_CategoriaId] ON [Produtos] ([CategoriaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220508142357_Criar_Tabela_Inicial', N'5.0.9');
GO

COMMIT;
GO

