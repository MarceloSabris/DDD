

create procedure [dbo].[IntegracaoParceiroCompraLojaAlterarStatusParceiro]
(
@IdCompra int,
@IdCompraEntregaSku int,
@StatusIntegracaoParceiro	char(1),
@DataIntegracaoParceiro	datetime2 null,
@LogRetornoParceiro	text null,
@Hash	varchar(100) null,
@Ativacao	varchar(1000) null,
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
		 Hash = @Hash,
		 RequisicaoId = @RequisicaoId,
		 ClienteId=@ClienteId,
		 TentativasIntegracao = @TentativasIntegracao
	where
		IdCompra = @IdCompra
		and IdCompraEntregaSku = @IdCompraEntregaSku

end
go

