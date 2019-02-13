DELETE FROM IntegracaoParceiroBhnAcaoEgift;

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (400, 'egiftprocessing.giftAmount.null','Load amount is missing in the request', 'Correct the data and resend', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (400, 'egiftprocessing.productConfigurationId.null','Product configuration id is missing in the request', 'Add the data and resend', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (400, 'egiftprocessing.retrievalReferenceNumber.invalid','RetrievalReferenceNumber (RRN) is invalid', 'Correct the data and resend', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (400, 'egitprocessing.invalid.contract.id','ContractId passed in the header is invalid', 'Correct the data and resend', 0);

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.product.not.in.catalog','Product not in Partner Catalog', 'If true error -contact BHN', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.transaction.cannot.process','Transaction could not be processed', 'No action, transaction never completed', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.general.decline','The transaction was declined by the provider', 'No action, transaction never completed', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.card.not.found','Transaction not fulfilled', 'Contact BHN', 0);
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.invalid.merchant','Not authorized to make this transaction.', 'If true error -contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.invalid.transaction','Transaction rejected', 'If true error -contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.invalid.amount','Invalid amount', 'Correct the data and resend', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.exceeds.transaction.count.limit','Maximum number of transaction limits reached', 'If true error -contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.invalid.expiration.date','The system could not fetch a valid card', 'Contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.transaction.duplicate','Duplicate transaction', 'No action, transaction already completed', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.cannot.route.transaction','Error in completing the transaction.', 'Contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.account.creation.failed.account.inventory.unavailable','No inventory available', 'Contact BHN', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'egiftprocessing.egift.creation.failed','System error', 'Resend request / Contact BHN if persists', 0); 
INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (409, 'max.reversal.time.elapsed','Reversal request sent after 24hrs', 'No Action', 0); 

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (500, 'Internal Server Error','System error', 'Resend request / Contact BHN if persists', 0); 

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (502, '-','Timeout in processing the request', 'Reverse (see reversal retry logic) the request / submit new request', 1); 

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (503, '-','Service is temporarily unreachable', 'Resend once service is established', 0); 

INSERT INTO IntegracaoParceiroBhnAcaoEgift VALUES (504, 'provider.transaction.timeout','Timeout in processing the request', 'Reverse (see reversal retry logic) the request / submit new request', 1); 