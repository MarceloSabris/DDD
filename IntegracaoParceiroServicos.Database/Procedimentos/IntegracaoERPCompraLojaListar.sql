
CREATE PROCEDURE [dbo].[IntegracaoERPCompraLojaListar]        
        
AS        
         
begin        
        
select          
    compraEntrega.IdCompra,      
    CompraLoja.IdCompraEntregaSku,      
    DataIntegracaoERP,      
    TentativasIntegracaoERP,      
  compSKU.Sequencial  SequencialID,    
  compraEntrega.GerencialId    
 from IntegracaoParceiroCompraLoja CompraLoja       
 inner join compraentrega compraEntrega  on     
     compraloja.IdCompra = compraentrega.IdCompra      
 inner join CompraEntregaSku compSKU on compSKU.IdCompraEntregaSku = CompraLoja.IdCompraEntregaSku   
 and  compSKU.IdCompraEntrega = compraEntrega.IdCompraEntrega  
   
 where StatusAceite = 1  
 and StatusIntegracaoParceiro = 1  
 and (StatusIntegracaoERP is null or  StatusIntegracaoERP = 0)  
      
         
        
end