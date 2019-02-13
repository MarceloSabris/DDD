
declare @idlayout int;

IF NOT EXISTS(SELECT 1 FROM dbo.layout dc WHERE dc.Nome = 'Código Ativação BHN')
BEGIN	

	SET @idlayout = (SELECT MAX(idlayout)+1 FROM dbo.layout);

	INSERT INTO dbo.layout
	(		
		IdLayout,
		Nome,		
		Texto,
		FlagFormatoHtml
	)
	VALUES
	(
		@idlayout,
		'Código Ativação BHN', 
		'  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <html xmlns="http://www.w3.org/1999/xhtml">  <head>  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
  <meta name="viewport" content="initial-scale=1.0" />  <meta name="format-detection" content="telephone=no" />
  <meta name="viewport" content="width=device-width" />
  <title>HP</title>

  <style type="text/css">

  a:link {color:#cc0000;text-decoration:underline;}
  a:visited {color:#cc0000;text-decoration:underline;}
  a:focus {color:#cc0000 !important;}
  a:hover {text-decoration:underline;}

  .yshortcuts a {border-bottom: none !important;}
  #outlook a {padding:0;}
  .ReadMsgBody {width:100%;background-color:#ebebeb;}
  .ExternalClass {width:100%;background-color:#ebebeb;}
  .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {line-height:100%;}
  p {margin:0;padding:0;}
  html {width:100%;}
  body {margin:0;padding:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none; line-height:1.6;}
  table {border-collapse:collapse;mso-table-lspace:0pt;mso-table-rspace:0pt;border-spacing:0;}
  table td {border-collapse:collapse !important; }
  img {display:block;border:none;outline:none;text-decoration:none;}
  .container-padding{line-height:20px;font-family:Arial, sans-serif;font-size:14px;color:#707a80;border-collapse:collapse; text-align:left;}
  img.center {margin:0 auto;float:none;}

  @media screen and (max-width:600px) {
  	body {width:auto !important;} 
  	td[class="container-padding"] {padding-left:30px !important;padding-right:30px !important;}
  	img[class="destaque"] {width:100%!important;height:auto!important;-ms-interpolation-mode:bicubic;}
  	table[class="container"] {width:95% !important;}
  	table[class="header-row"] {width:490px !important;}
  	table[class="content-row"] {width:490px !important;}
  	table[class="footer-row"] {width:490px !important;}
  	table[class="expander"] {width:100%!important;}
  	img[class="none"] {display:none !important;}
  	div[class="none"] {display:none !important;}
  	img[class="footer-logo"] {float:none !important;}
  	table[class="col-2"] {float:none !important;width:100% !important;margin-bottom:15px;padding-bottom:15px;}
  	td[class="force-col"] {display:block;text-align:center !important; width:100% !important;}
  	table[id="last-col-2"] {margin:0; padding:0px;}
  }

  @media screen and (max-width: 480px) {
  	table[class="header-row"] {width:98% !important;}
  	table[class="content-row"] {width:98% !important;}
  	table[class="footer-row"] {width:98% !important;}
  	div[class="cta"]{width:100% !important;}
  	img[id="header-logo"] {width:85%!important;height:auto!important;-ms-interpolation-mode:bicubic;}
  }

</style>

</head>


<body bgcolor="#ffffff" style="margin: 0;padding: 0;-webkit-text-size-adjust: none;-ms-text-size-adjust: none;line-height: 1.6;">

	<div align="center" style="font-family:Arial, sans-serif; color:#666666; font-size:11px; line-height:60px; height:60px; text-align:center;">
		Caso n&atilde;o visualize este e-mail, <a target="_blank" href="https://www.lojahp.com.br" style="color:#666666;text-decoration:underline;">clique aqui</a>.
	</div>

	<table border="0" width="100%" cellpadding="0" cellspacing="0" bgcolor="#092055" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">
		<tr>      
			<td align="center" valign="top" bgcolor="#ffffff" style="background-color: #ffffff;border-collapse: collapse !important;" class="container">      
        <table width="640" border="0" cellspacing="0" cellpadding="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">          
          <tr>            
            <td bgcolor="#ffffff" width="184" height="90" valign="top" style="color:#ffffff; font-family:Arial, sans-serif; border-collapse: collapse !important;">
              <a href="https://www.lojahp.com.br" target="_blank" style="color: #de2042;text-decoration: none; padding-top: 20px; padding-bottom: 22px; padding-left: 30px; display: block">
                 <img src="https://imagens.lojahp.com.br/news/black-howk/email/codigo-ativacao/header-left.jpg" alt="Bem-vindo a Casas Bahia" width="81" height="81" border="0" class="destaque" style="display: block;border: none;outline: none;text-decoration: none;" />
                </a>
            </td>            
            <td bgcolor="#ffffff" width="456" height="90" valign="top" style="border-collapse: collapse !important;">
                <div style="color:#000000; font-family:Arial, sans-serif; padding-top:30px; font-size: 29px; line-height: 26px; text-align: left;">Voc&ecirc; adquiriu <span id="artigo">a</span><br /><strong><span id="produto">#(PRODUTO_NOME)</span><strong></div>              
            </td>          
          </tr>        
        </table>         
		    <table border="0" width="640" cellpadding="0" cellspacing="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">          
			    <tr>            
					  <td valign="center" class="container-padding" bgcolor="#0096d6" height="50" style="background-color: #0096d6;padding-left: 30px; padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
              <div style="font-size:14px; color:#ffffff; text-align:left; width:288px; display: inline-block;">
                Ol&aacute;, <font color="#ffffff"><strong>#(CLIE_NOME)</strong></font>
              </div>
              <div style="font-size:14px; color:#ffffff; text-align:right; width:288px; display: inline-block;">
                N&ordm; do pedido: <font color="#ffffff"><strong>#(PED_CLIE_ORIG)</strong></font>
              </div>                    
              <br />    
            </td>          
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
              <br />         
              <div>                     
              Sua <strong>#(PRODUTO_NOME)</strong> foi adquirida com sucesso, para que voc&ecirc; consiga usa-la,   &eacute; necess&aacute;rio utilizar a chave de ativa&ccedil;&atilde;o abaixo:<br /> 
              </div> 
            </td>
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="font-family: tahoma, Arial, sans-serif;">                     
                  <strong>Chave de ativa&ccedil;&atilde;o:</strong>
                </div> 
                <div style="color:#0096d6; font-size: 20px; margin-top: 6px;">                     
                    <strong><span>#(CODIGO_ATIVACAO)</span></strong>
                </div>                   
              <br />
            </td>
          </tr> 
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="color:#cc0000; font-family: tahoma, Arial, sans-serif; font-size: 16px;">                     
                  <strong>Termos e condi&ccedil;&otilde;es:</strong>
                </div> 
                <div style="font-size: 16px; margin-top: 8px;">                     
                  #(TERMOS_CONDICOES)
                </div>                   
            </td>
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="color:#5a5a5a; font-size: 16px; margin-top: 8px;">                     
                  Caso tenha qualquer d&uacute;vida, entre em <a href="mailto:atendimento@sac.lojahp.com.br">contato conosco!</a>
                </div>    
                <br /> 
                <br />                
            </td>
          </tr> 
          <tr>            
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #666666;border-collapse: collapse !important;text-align: left;">
              <table border="0" width="100%" cellpadding="0" cellspacing="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">
                <tr>
                    <td width="50%" valign="top" class="container-padding" style="font-family:Arial, sans-serif; font-size:14px; color:#0096d6; border-collapse:collapse !important; text-align: left;">
                      <strong>Resumo do pedido:</strong>
                      <br />
                      <div style="color:#666666; margin-top: 8px;">
                        QTD <span>#(TOTAL_PRODUTO)</span><br />
                       #(PRODUTO_NOME)
                      </div>                      
                    </td>
                    <td width="50%" valign="top" class="container-padding" style="font-family:Arial, sans-serif; font-size:14px; color:#0096d6; border-collapse:collapse !important; text-align: left;">
                      <strong>Endere&ccedil;o de entrega e montagem:</strong>
                      <br />
                      <div style="color:#666666; margin-top: 8px;">
                       #(ENDERECO)
                      </div>                      
                    </td>
                </tr>
              </table> 
              <br />    
              <br /> 
            </td>          
          </tr>  
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #0096d6;border-collapse: collapse !important;text-align: center;">
              Agradecemos por escolher nossos servi&ccedil;os!<br />
              Equipe HP
              <br />
              <br />              
            </td>
          </tr>                                                    
        </table>         
      </td>    
    </tr>  
  </table>  
    
  <div align="center" style="font-family:Arial, sans-serif; color:#666666; font-size:11px; line-height:60px; height:60px; text-align:center;">
      <strong>Aten&ccedil;&atilde;o:</strong> Esta &eacute; uma mensagem autom&aacute;tica, n&atilde;o &eacute; necess&aacute;rio respond&ecirc;-la.
  </div> 
    
	</body>  
	</html>', 
		1
	)
	PRINT 'Código Ativação BHN inserido com Sucesso.'
END
GO
