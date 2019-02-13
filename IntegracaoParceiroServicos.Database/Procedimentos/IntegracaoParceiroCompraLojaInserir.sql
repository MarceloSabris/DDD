create procedure [dbo].[IntegracaoParceiroCompraLojaInserir]
(
@IdCompra int,
@IdCompraEntregaSku int,
@IdProdutoParceiro int,
@DataInclusao datetime2,	
@EmailEnvioAceito varchar(255) null,
@DataEnvioAceite datetime2 null, 
@StatusAceite char(1) null,
@DataStatusAceite datetime2 null, 
@StatusIntegracaoParceiro char(1) null, 
@DataIntegracaoParceiro datetime2 null, 
@LogRetornoParceiro text null, 
@Ativacao varchar(1000) null,
@EmailEnvioAtivacao varchar(255), 
 @DataEnvioAtivacao DATETIME2 NULL
)

as 
begin

	insert into IntegracaoParceiroCompraLoja
	(IdCompra,
	IdCompraEntregaSku,
	IdProdutoParceiro ,
	DataInclusao,	
	EmailEnvioAceito ,
	DataEnvioAceite, 
	StatusAceite,
	DataStatusAceite , 
	StatusIntegracaoParceiro , 
	DataIntegracaoParceiro , 
	LogRetornoParceiro , 
	Ativacao,
	EmailEnvioAtivacao , 
	 DataEnvioAtivacao)
	values
	(@IdCompra,
	@IdCompraEntregaSku,
	@IdProdutoParceiro ,
	@DataInclusao,	
	@EmailEnvioAceito ,
	@DataEnvioAceite, 
	@StatusAceite,
	@DataStatusAceite , 
	@StatusIntegracaoParceiro , 
	@DataIntegracaoParceiro , 
	@LogRetornoParceiro , 
	@Ativacao,
	@EmailEnvioAtivacao , 
	 @DataEnvioAtivacao )

end
go
