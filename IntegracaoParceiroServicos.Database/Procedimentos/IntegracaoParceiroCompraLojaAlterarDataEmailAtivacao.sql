
create procedure [dbo].[IntegracaoParceiroCompraLojaAlterarDataEmailAtivacao]
(
@IdCompra int,
@IdCompraEntregaSku int,
@EmailEnvioAtivacao varchar(255)
)

as 
begin

	update IntegracaoParceiroCompraLoja
	set			
		 DataEnvioAtivacao = null ,
		EmailEnvioAtivacao = @EmailEnvioAtivacao
	where
		IdCompra = @IdCompra
		and IdCompraEntregaSku = @IdCompraEntregaSku

end
go