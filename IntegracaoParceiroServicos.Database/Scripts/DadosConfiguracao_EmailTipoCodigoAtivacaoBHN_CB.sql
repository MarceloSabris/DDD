
declare @idEmailTipo int;

IF NOT EXISTS(SELECT 1 FROM dbo.DadosConfiguracao dc WHERE dc.Nome = 'EmailTipoCodigoAtivacaoBHN')
BEGIN
	set @idEmailTipo  = (SELECT idEmailTipo FROM dbo.emailTipo where Nome='Código Ativação BHN');

	INSERT INTO dbo.DadosConfiguracao
	(
		IdDadosConfiguracaoAmbiente,IdDadosConfiguracaoAplicacao,IdDadosConfiguracaoGrupo,
		Nome,
		Valor,
		DataMudanca,FlagEditavel
	)
	VALUES
	(
		1,1,1,
		'EmailTipoCodigoAtivacaoBHN', 
		cast(@idEmailTipo as varchar), 
		GETDATE(),0
	)
	PRINT 'EmailTipoCodigoAtivacaoBHN inserido com Sucesso na DadosConfiguracao.'
END
GO

