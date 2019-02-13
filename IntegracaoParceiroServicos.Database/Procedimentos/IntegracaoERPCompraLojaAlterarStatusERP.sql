create procedure [dbo].[IntegracaoERPCompraLojaAlterarStatusERP]  
(  
	@IdCompra int,  
	@IdCompraEntregaSku int,
	@StatusIntegracaoERP char(1),  
	@LogRetornoERP text null,  
	@TentativasIntegracaoERP int null,
	@DataIntegracaoERP datetime2 null
)  
  
as   
begin  
  
 update IntegracaoParceiroCompraLoja  
 set   
	StatusIntegracaoERP = @StatusIntegracaoERP,  
	LogRetornoERP = @LogRetornoERP,  
	TentativasIntegracaoERP = @TentativasIntegracaoERP,
	DataIntegracaoERP = @DataIntegracaoERP 
 where  
  IdCompra = @IdCompra  
  and IdCompraEntregaSku = @IdCompraEntregaSku  
  
end
