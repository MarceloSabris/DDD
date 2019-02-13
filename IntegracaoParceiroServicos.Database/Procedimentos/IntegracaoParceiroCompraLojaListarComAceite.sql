create PROCEDURE [dbo].[IntegracaoParceiroCompraLojaListarComAceite]
AS
	
begin

	select 	
		IdCompra,
		ces.IdCompraEntregaSku,
		cl.IdProdutoParceiro,
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
		ClienteId,
		TentativasIntegracao,
		p.Tipo,
		p.SkuParceiro,
		ces.IdSku,
		p.Preco as ValorVendaUnidade

	from IntegracaoParceiroCompraLoja cl
	inner join IntegracaoParceiroProduto p
		on p.IdProdutoParceiro = cl.IdProdutoParceiro
	inner join CompraEntregaSku  ces
		on ces.IdCompraEntregaSku = cl.IdCompraEntregaSku
	where StatusAceite = 1
	and (StatusIntegracaoParceiro = 0 OR StatusIntegracaoParceiro IS NULL)

end

go
