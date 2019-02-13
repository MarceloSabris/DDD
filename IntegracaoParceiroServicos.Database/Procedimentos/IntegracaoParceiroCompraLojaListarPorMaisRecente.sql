
create procedure [dbo].[IntegracaoParceiroCompraLojaListarPorMaisRecente]
(
@DataUltimaExecucao datetime2 null
)

as 

begin


select 
	c.IdCompra,
	ces.IdCompraEntregaSku,
	p.IdProdutoParceiro,
	cli.Email
from CompraEntrega ce
inner join Compra c
	on ce.IdCompra = c.IdCompra
inner join Cliente cli
	on cli.IdCliente = c.IdCliente
inner join CompraEntregaStatusLog cesl 
	on cesl.IdCompraEntrega = ce.IdCompraEntrega
inner join CompraEntregaSku ces
	on ces.IdCompraEntrega = ce.IdCompraEntrega
inner join IntegracaoParceiroProduto p
	on p.IdSku = ces.IdSku
		and p.Ativo = 1
left join IntegracaoParceiroCompraLoja cl 
	on cl.IdCompraEntregaSku = ces.IdCompraEntregaSku

where
	(cesl.IdCompraEntregaStatus = 'PAP' OR cesl.IdCompraEntregaStatus = 'IVE')
	and (cl.IdCompraEntregaSku is null)
	and (@DataUltimaExecucao is null OR cesl.Data > @DataUltimaExecucao);


end

go