create procedure [dbo].[IntegracaoParceiroCompraLojaAlterarStatusAceite]
(
@IdCompra int,
@IdCompraEntregaSku int,
@StatusAceite char(1) 
)

as 
begin

	update IntegracaoParceiroCompraLoja
	set			
		StatusAceite = @StatusAceite,
		DataIntegracaoParceiro = getdate()
		
	where
		IdCompra = @IdCompra
		and IdCompraEntregaSku = @IdCompraEntregaSku

end
go


