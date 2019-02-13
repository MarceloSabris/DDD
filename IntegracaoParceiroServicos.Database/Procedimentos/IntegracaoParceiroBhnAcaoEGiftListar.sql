create procedure [dbo].[IntegracaoParceiroBhnAcaoEGiftListar]
(
@Numero	int	null,
@CodigoRetorno	varchar(1000) null,
@Acao	varchar	(255) null,
@Desfazimento	bit	null
)

as 

begin

	select 
		IdRetornoBhnEGift
	,Numero
	,CodigoRetorno
	,Descricao
	,Acao
	,Desfazimento
	 from 
		IntegracaoParceiroBhnAcaoEGift
	where
	   (@Desfazimento is null OR Desfazimento = @Desfazimento)
	and (@Numero is null OR Numero = @Numero)
	and (@CodigoRetorno is null OR CodigoRetorno = @CodigoRetorno)
	and (@Acao is null OR Acao = @Acao)

end

go