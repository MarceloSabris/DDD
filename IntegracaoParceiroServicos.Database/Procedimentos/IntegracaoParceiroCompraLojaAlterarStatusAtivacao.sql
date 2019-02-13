

create procedure [dbo].[IntegracaoParceiroCompraLojaAlterarStatusAtivacao]
(
@IdCompra int,
@IdCompraEntregaSku int,
@DataEnvioAtivacao	datetime2 null
)

as 
begin

	update IntegracaoParceiroCompraLoja
	set			
		 DataEnvioAtivacao = @DataEnvioAtivacao 
		
	where
		IdCompra = @IdCompra
		and IdCompraEntregaSku = @IdCompraEntregaSku

end
go

