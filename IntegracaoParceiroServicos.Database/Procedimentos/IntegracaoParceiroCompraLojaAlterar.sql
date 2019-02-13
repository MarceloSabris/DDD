create procedure [dbo].[IntegracaoParceiroCompraLojaAlterar]
(
@IdCompra int,
@IdCompraEntregaSku int,
@IdProdutoParceiro int,
@StatusIntegracaoParceiro	char(1),
@DataIntegracaoParceiro	datetime2 null,
@LogRetornoParceiro	text null,
@Hash	varchar(100) null,
@Ativacao	varchar(1000) null,
@EmailEnvioAtivacao	varchar(255) null,
@DataEnvioAtivacao	datetime2 null,
@RequisicaoId	varchar(100) null,
@ClienteId	varchar(100) null,
@TentativasIntegracao	int null
)

as 
begin

	update IntegracaoParceiroCompraLoja
	set	
		StatusIntegracaoParceiro = @StatusIntegracaoParceiro , 
		DataIntegracaoParceiro = @DataIntegracaoParceiro , 
		LogRetornoParceiro = @LogRetornoParceiro, 
		Ativacao = @Ativacao ,
		EmailEnvioAtivacao = @EmailEnvioAtivacao, 
		 DataEnvioAtivacao = @DataEnvioAtivacao ,
		 Hash = @Hash,
		 RequisicaoId = @RequisicaoId,
		 ClienteId=@ClienteId,
		 TentativasIntegracao = @TentativasIntegracao
	where
		IdCompra = @IdCompra
		and IdCompraEntregaSku = @IdCompraEntregaSku

end
go
