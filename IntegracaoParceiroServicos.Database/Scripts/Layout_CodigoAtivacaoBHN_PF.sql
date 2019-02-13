
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
  <title>Ponto Frio</title>

  <style type="text/css">

  a:link {color:#e6191e;text-decoration:underline;}
  a:visited {color:#e6191e;text-decoration:underline;}
  a:focus {color:#e6191e !important;}
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


<body bgcolor="#151826" style="margin: 0;padding: 0;-webkit-text-size-adjust: none;-ms-text-size-adjust: none;line-height: 1.6;">

	<div align="center" style="font-family:Arial, sans-serif; color:#ffffff; font-size:11px; line-height:60px; height:60px; text-align:center;">
		Caso n&atilde;o visualize este e-mail, <a target="_blank" href="https://www.pontofrio.com.br" style="color:#ffffff;text-decoration:underline;">clique aqui</a>.
	</div>

	<table border="0" width="100%" cellpadding="0" cellspacing="0" bgcolor="#151826" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">
		<tr>      
			<td align="center" valign="top" bgcolor="#f6f2e7" style="background-color: #151826;border-collapse: collapse !important;" class="container">      
				<table width="640" border="0" cellspacing="0" cellpadding="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">          
    			<tr>            
						<td style="border-collapse: collapse !important;">
							<a href="https://www.pontofrio.com.br" target="_blank" style="color: #de2042;text-decoration: none;">
								<img src="https://www.pontofrio-imagens.com.br/html/news/black-howk/email/codigo-ativacao/header-left.jpg" alt="Bem-vindo ao Ponto Frio" width="167" height="200" border="0" class="destaque" style="display: block;border: none;outline: none;text-decoration: none;" />
							</a>
						</td>          
            <td background="https://www.pontofrio-imagens.com.br/html/news/black-howk/email/codigo-ativacao/header-right.jpg" width="473" height="200" style="color:#fff; font-size:24px; font-family:Arial, sans-serif; border-collapse: collapse !important;">
                <div style="padding-left: 30px;">Parab&eacute;ns, voc&ecirc; adquiriu <span id="artigo">a</span><br /><strong><span id="produto">#(PRODUTO_NOME)</span><strong></div>
            </td> 
					</tr>        
		    </table>        
		    <table border="0" width="640" cellpadding="0" cellspacing="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">          
			    <tr>            
					  <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
              <br /><br />            
              <div style="font-size:14px; color:#000000; text-align:left; width:288px; display: inline-block;">
                <strong>Ol&aacute;, <font color="#e6191e">#(CLIE_NOME)</font></strong>
              </div>
              <div style="font-size:14px; color:#000000; text-align:right; width:288px; display: inline-block;">
                <strong>N&ordm; do pedido: <font color="#e6191e">#(PED_CLIE_ORIG)</font></strong>
              </div>                    
              <br />    
            </td>          
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
              <br />         
              <div>                     
              Sua <strong>#(PRODUTO_NOME)</strong> foi adquirida com sucesso, para que voc&ecirc; consiga usa-la,   &eacute; necess&aacute;rio utilizar a chave de ativa&ccedil;&atilde;o abaixo:<br /> 
              </div> 
            </td>
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="font-family: tahoma, Arial, sans-serif;">                     
                  <strong>Chave de ativa&ccedil;&atilde;o:</strong>
                </div> 
                <div style="color:#e6191e; font-size: 20px; margin-top: 6px;">                     
                    <strong><span>#(CODIGO_ATIVACAO)</span></strong>
                </div>                   
              <br />
            </td>
          </tr> 
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="color:#151826; font-family: tahoma, Arial, sans-serif; font-size: 16px;">                     
                  <strong>Termos e condi&ccedil;&otilde;es:</strong>
                </div> 
                <div style="font-size: 16px; margin-top: 8px;">                     
                 #(TERMOS_CONDICOES)
                </div>                   
            </td>
          </tr>
          <tr>
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
                <br />         
                <div style="color:#5a5a5a; font-size: 16px; margin-top: 8px;">                     
                  Caso tenha qualquer d&uacute;vida, entre em <a href="mailto:atendimento@sac.pontofrio.com.br">contato conosco!</a>
                </div>    
                <br /> 
                <br />                
            </td>
          </tr> 
          <tr>            
            <td valign="top" class="container-padding" bgcolor="#ffffff" style="background-color: #ffffff;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #434242;border-collapse: collapse !important;text-align: left;">
              <table border="0" width="100%" cellpadding="0" cellspacing="0" class="content-row" style="border-collapse: collapse;mso-table-lspace: 0pt;mso-table-rspace: 0pt;border-spacing: 0;">
                <tr>
                    <td width="50%" valign="top" class="container-padding" style="font-family:Arial, sans-serif; font-size:14px; color:#e6191e; border-collapse:collapse !important; text-align: left;">
                      <strong>Resumo do pedido:</strong>
                      <br />
                      <div style="color:#545454; margin-top: 8px;">
                        QTD <span>#(TOTAL_PRODUTO)</span><br />
                        #(PRODUTO_NOME)
                      </div>                      
                    </td>
                    <td width="50%" valign="top" class="container-padding" style="font-family:Arial, sans-serif; font-size:14px; color:#e6191e; border-collapse:collapse !important; text-align: left;">
                      <strong>Endere&ccedil;o de entrega e montagem:</strong>
                      <br />
                      <div style="color:#545454; margin-top: 8px;">
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
            <td valign="top" class="container-padding" bgcolor="#e6191e" style="background-color: #e6191e;padding-top: 20px;padding-left: 30px;padding-right: 30px;line-height: 20px;font-family: Arial, sans-serif;font-size: 14px;color: #ffffff;border-collapse: collapse !important;text-align: center;">
              Agradecemos por escolher nossos servi&ccedil;os!<br />
              Equipe Pontofrio.com.br
              <br />
              <br />              
            </td>
          </tr>                                                    
        </table>         
      </td>    
    </tr>  
  </table>  
    
  <div align="center" style="font-family:Arial, sans-serif; color:#ffffff; font-size:11px; line-height:60px; height:60px; text-align:center;">
      <strong>Aten&ccedil;&atilde;o:</strong> Esta &eacute; uma mensagem autom&aacute;tica, n&atilde;o &eacute; necess&aacute;rio respond&ecirc;-la.
  </div> 
    
	</body>  
	</html>', 
		1
	)
	PRINT 'Código Ativação BHN inserido com Sucesso.'
END
GO
