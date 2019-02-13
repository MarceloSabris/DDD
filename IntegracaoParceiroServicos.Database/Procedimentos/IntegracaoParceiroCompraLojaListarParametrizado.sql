  
create procedure IntegracaoParceiroCompraLojaListarParametrizado(            
 @IdCompra int = null                       
,@Certificado varchar(100) = null             
,@SeguradoCPF varchar(20) = null        
,@PageIndex INT                
,@PageSize INT                  
)              
as               
   

            
SET QUOTED_IDENTIFIER ON                
                
DECLARE @startRow INT, @endRow INT, @total INT;                
SET @startRow = ((@PageIndex - 1) * @PageSize + 1);                
SET @endRow = (@PageIndex * @PageSize);                
            
            
WITH CERTIFICADOS            
(  ROWNUM  
   , IdCompra  
   , IdCompraEntregaSku   
   , IdCertificado    
   , DataEmissao    
   , NomeCliente    
   , SeguradoCPF    
      , ProdutoNome        
   , ProdutoMarca    
   , dataInicioVigencia  
   , dataFimVigencia   
   , IdSku      
   , DataEnvio         
   , Valor  
   , Certificado  
   , Email   
)            
AS            
(            
   select ROW_NUMBER() OVER (ORDER BY cl.IdCompra) AS RowNum  
  
 , IdCompra    = cl.IdCompra  
 , IdCompraEntregaSku = cl.IdCompraEntregaSku
   , IdCertificado    = cl.RequisicaoId   
   , DataEmissao    = cl.DataIntegracaoParceiro
   , NomeCliente    = ct.Nome + ' ' + ct.Sobrenome
   , SeguradoCPF    = REPLACE(REPLACE(ct.CpfCnpj,'.',''),'-','')
      , ProdutoNome  = p.Nome      
   , ProdutoMarca    = m.Nome
   , dataInicioVigencia  = cl.DataIntegracaoParceiro
   , dataFimVigencia   = DATEADD(M,12, cl.DataIntegracaoParceiro)
   , IdSku      = ces.IdSku
   , DataEnvio         = cl.DataEnvioAtivacao
   , Valor  = ces.ValorVendaUnidade
   , Certificado  = cl.Ativacao
   , Email = ct.Email
 from [dbo].[IntegracaoParceiroCompraLoja] (nolock)  cl
	inner join Compra c  on c.IdCompra = cl.IdCompra
	inner join Cliente ct on ct.IdCliente = c.IdCliente
	inner join CompraEntregaSku ces on ces.IdCompraEntregaSku = cl.IdCompraEntregaSku
	inner join Sku s on s.IdSKU = ces.IdSku
	inner join Produto p on p.IdProduto = s.IdProduto
	inner join Marca m on m.IdMarca = p.IdMarca
    WHERE StatusAceite = 1 
	and StatusIntegracaoParceiro = 1	
	and (@IdCompra IS NULL OR  cl.IdCompra = @IdCompra)                                 
    AND (@Certificado IS NULL OR cl.RequisicaoId = @Certificado)                   
    AND (@SeguradoCPF IS NULL OR REPLACE(REPLACE(ct.CpfCnpj,'.',''),'-','') = @SeguradoCPF)        
         
             
)            
            
select  RowNum                      
      , IdCompra  
	  , IdCompraEntregaSku   
      , IdCertificado    
      , DataEmissao    
      , NomeCliente    
      , SeguradoCPF    
      , ProdutoNome          
   , ProdutoMarca    
      , dataInicioVigencia  
      , dataFimVigencia   
      , IdSku      
      , DataEnvio         
   , Valor  
   , Certificado    
   , Email 
      , CASE WHEN RowNum = @startRow THEN (SELECT MAX(RowNum) FROM CERTIFICADOS)  ELSE 0 END [__TotalRegistros]            
      from CERTIFICADOS            
WHERE RowNum BETWEEN @startRow AND @endRow                
ORDER BY RowNum ASC   
  
  
  