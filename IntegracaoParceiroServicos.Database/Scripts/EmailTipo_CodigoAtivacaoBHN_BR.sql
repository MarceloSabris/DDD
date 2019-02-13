
declare @idEmailTipo int;
declare @idlayout int;

IF NOT EXISTS(SELECT 1 FROM dbo.emailTipo dc WHERE dc.Nome = 'Código Ativação BHN')
BEGIN	

	set @idEmailTipo  = (SELECT MAX(idemailtipo)+1 FROM dbo.emailTipo);
	set @idlayout  = (SELECT idlayout FROM dbo.Layout where Nome='Código Ativação BHN');

	insert into dbo.emailTipo 
	(
	IdEmailTipo,
	 IdLayout,
	 Nome,
	 NomeRemetentePadrao,
	 EmailRemetentePadrao,
	 AssuntoPadrao,
	 Ordem,
	 FlagAtivo,
	 Mailer,
	 HabilitaSsl
	)
	values
	(
	@idEmailTipo,
	@idlayout,
	'Código Ativação BHN',
	'barateiro.com.br',
	'atendimento@sac.barateiro.com.br',
	'Solicitação de Código Ativação BHN',
	1,
	1,
	'vip-mailer.dc.nova',
	'false'
	)
	PRINT 'Código Ativação BHN inserido com Sucesso.'
END
GO
