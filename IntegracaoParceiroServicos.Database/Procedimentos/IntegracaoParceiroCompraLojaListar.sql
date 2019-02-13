
create PROCEDURE [dbo].[IntegracaoParceiroCompraLojaListar]
@IdCompra int ,
@IdCompraEntregaSku int ,
@IdProdutoParceiro int 

AS
	
begin

	select 	
		IdCompra,
		IdCompraEntregaSku,
		IdProdutoParceiro,
		DataInclusao,
		EmailEnvioAceito,
		DataEnvioAceite,
		StatusAceite,
		DataStatusAceite,
		StatusIntegracaoParceiro,
		DataIntegracaoParceiro,
		LogRetornoParceiro,
		Hash,
		Ativacao,
		EmailEnvioAtivacao,
		DataEnvioAtivacao,
		RequisicaoId,
		TentativasIntegracao,
		ClienteId
	from IntegracaoParceiroCompraLoja
	where 
		(@IdCompra = 0 OR IdCompra = @IdCompra)
	and (@IdCompraEntregaSku = 0 OR IdCompraEntregaSku = @IdCompraEntregaSku)
	and (@IdProdutoParceiro = 0 OR IdProdutoParceiro = @IdProdutoParceiro)
	
	

end

go
