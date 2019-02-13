CREATE TABLE [dbo].[IntegracaoParceiroCompraLoja]
(	
	[IdCompra] int not null,
	[IdCompraEntregaSku] int not null,
	[IdProdutoParceiro] int not null,
	[DataInclusao] datetime2 not null default getdate(),	
	[EmailEnvioAceito] varchar(255) null,
	[DataEnvioAceite] datetime2 null, 
	[StatusAceite] char(1) null, 
    [DataStatusAceite] datetime2 null, 
	[StatusIntegracaoParceiro] char(1) null, 
	[DataIntegracaoParceiro] datetime2 null, 
	[LogRetornoParceiro] text null, 
	[Hash] varchar(100) NULL,
	[Ativacao] varchar(1000)  null,
    [EmailEnvioAtivacao] varchar(255) null, 
    [DataEnvioAtivacao] DATETIME2 NULL, 
    [RequisicaoId] varchar(100) NULL, 
	[ClienteId] varchar(100) null,
    [TentativasIntegracao] INT NULL DEFAULT 0,
	[StatusIntegracaoERP] [bit] NULL,
	[LogRetornoERP] [text] NULL,
	[DataIntegracaoERP] [datetime2](7) NULL,
	[TentativasIntegracaoERP] [int] NULL
)
go

--alter table [dbo].[IntegracaoParceiroCompraLoja]
--add constraint FK_IntegracaoParceiroCompraLoja_Compra foreign key (IdCompra)  references [dbo].[Compra] (IdCompra)
--go


--alter table [dbo].[IntegracaoParceiroCompraLoja]
--add constraint FK_IntegracaoParceiroCompraLoja_CompraEntregaSku foreign key (IdCompraEntregaSku)  references [dbo].[CompraEntregaSku] (IdCompraEntregaSku)
--go

alter table [dbo].[IntegracaoParceiroCompraLoja]
add constraint PK_IntegracaoParceiroCompraLoja   PRIMARY KEY (IdCompra, IdCompraEntregaSku)
go

alter table [dbo].[IntegracaoParceiroCompraLoja]
add constraint FK_IntegracaoParceiroCompraLoja_IdProdutoParceiro foreign key (IdProdutoParceiro)  references [dbo].[IntegracaoParceiroProduto] (IdProdutoParceiro)
go
