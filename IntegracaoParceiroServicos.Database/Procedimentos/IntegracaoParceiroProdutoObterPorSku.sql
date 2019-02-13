create procedure [dbo].[IntegracaoParceiroProdutoObterPorSku]
(
@IdSku int
)

as 
begin

	select 
		IdProdutoParceiro,
		IdSku,
		SkuParceiro,
		Nome,
		Imagem,
		Descricao,
		InstrucoesUso,
		TermosCondicoes,
		Versao,
		Preco,
		Ativo,
		IdParceiro,
		Tipo
	from 
		IntegracaoParceiroProduto
	where
		IdSku = @IdSku

end
go