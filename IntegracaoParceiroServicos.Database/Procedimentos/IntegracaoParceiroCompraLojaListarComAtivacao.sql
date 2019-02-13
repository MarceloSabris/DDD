create procedure [dbo].[IntegracaoParceiroCompraLojaListarComAtivacao]
AS
	
begin

	select 	
		c.IdCompra,
		c.IdCliente,
		ces.IdCompraEntregaSku,
		ipp.IdProdutoParceiro,
		p.Nome as Produto,
		ces.IdSku,		
		ipp.TermosCondicoes,		
		EmailEnvioAceito,		
		Hash,
		Ativacao,
		EmailEnvioAtivacao,
		RequisicaoId,		
		ct.Nome,
		ct.Sobrenome,
		cc.IdentificacaoEndereco,
		cc.Rua,
		cc.Numero,
		cc.Complemento,
		cc.Bairro,
		cc.Cep,
		cc.PontoReferencia,
		cc.Municipio,
		cc.Estado,
		cc.Pais
		
	from IntegracaoParceiroCompraLoja cp
	inner join Compra c on c.IdCompra = cp.IdCompra	
	inner join CompraEntregaSku ces on ces.IdCompraEntregaSku = cp.IdCompraEntregaSku
	inner join Sku s on s.IdSKU = ces.IdSku
	inner join IntegracaoParceiroProduto ipp on ipp.IdSku = s.IdSKU
	inner join Produto p on p.IdProduto = s.IdProduto
	inner join Cliente ct on ct.IdCliente = c.IdCliente
	inner join CompraCliente cc on cc.IdCompra = c.IdCompra
	
	
	where StatusAceite = 1
	and cp.DataEnvioAtivacao is null
	and Ativacao is not null
	and cc.TipoCliente = 1

end

go
