create TABLE [dbo].[IntegracaoParceiroProduto]
(
	[IdProdutoParceiro] int NOT NULL PRIMARY KEY identity(1,1),
	[IdSku] int not null,
	[SkuParceiro] varchar(255) not null,
	[Nome] varchar(255) not null,
	[Imagem] varchar(255) not null,
	[Descricao] varchar(255) not null,
	[InstrucoesUso] text not null,
	[TermosCondicoes] text not null,
	[Versao] decimal(10,2) not null,
	[Preco] decimal(10,2) not null,
	[Ativo] bit not null  , 
	[IdParceiro] int NOT NULL,
	[Tipo] int NOT NULL 

)
go

--alter table [dbo].[IntegracaoParceiroProduto]
--add constraint FK_IntegracaoParceiroProduto_Sku foreign key (IdSku)  references [dbo].[Sku] (idSku)
--go


alter table [dbo].[IntegracaoParceiroProduto]
add constraint FK_IntegracaoParceiroProduto_Parceiro foreign key (IdParceiro)  references [dbo].[IntegracaoParceiroEmpresa] (IdParceiro)
go