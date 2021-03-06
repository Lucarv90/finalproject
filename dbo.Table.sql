﻿CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]    INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         NVARCHAR (50) NOT NULL,
    [Login]        NVARCHAR (20) NOT NULL unique,
    [Senha]        NVARCHAR (10) NOT NULL,
    [DataCadastro] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);
