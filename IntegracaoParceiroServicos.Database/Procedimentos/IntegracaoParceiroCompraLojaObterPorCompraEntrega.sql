create procedure [dbo].[IntegracaoParceiroCompraLojaObterPorCompraEntrega]
(
@IdCompra int,
@IdCompraEntregaSku int
)
as

begin

	select 		
		IdCompra,
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
		 DataEnvioAtivacao
	from IntegracaoParceiroCompraLoja
	where
	 IdCompra=@IdCompra
	 and IdCompraEntregaSku=@IdCompraEntregaSku

end

go