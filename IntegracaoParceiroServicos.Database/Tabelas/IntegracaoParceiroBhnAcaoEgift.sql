CREATE TABLE [dbo].[IntegracaoParceiroBhnAcaoEgift]
(
	[IdRetornoBhnEGift] INT NOT NULL PRIMARY KEY identity(1,1),
	[Numero] int not null,
	[CodigoRetorno] varchar(1000) not null,
	[Descricao] varchar(255) not null,
	[Acao] varchar(255) not null,
	[Desfazimento] bit not null,
)
