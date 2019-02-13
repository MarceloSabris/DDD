CREATE TABLE [dbo].[IntegracaoParceiroEmpresa]
(
	[IdParceiro] INT NOT NULL PRIMARY KEY identity(1,1),
	[NomeParceiro] varchar(255) not null,
	[Ativo] bit not null default(0)
)
