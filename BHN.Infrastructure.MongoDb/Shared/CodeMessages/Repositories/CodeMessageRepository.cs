using BHN.Domain.Shared.CodeMessages.Models;
using BHN.Domain.Shared.CodeMessages.Repositories;
using BHN.Infrastructure.MongoDb.Common;
using BHN.Infrastructure.MongoDb.Shared.CodeMessages.Documents;
using BHN.Infrastructure.MongoDb.Shared.CodeMessages.Mappers;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHN.Infrastructure.MongoDb.Shared.CodeMessages.Repositories
{
    public class CodeMessageRepository : ICodeMessageRepository
    {
        private readonly IDataBaseFacade databaseFacade;
        private readonly string collectionName;

        public CodeMessageRepository(IDataBaseFacade databaseFacade)
                : this(databaseFacade, CollectionsNames.CodeMessagesCollectionName)
        {
        }

        public CodeMessageRepository(IDataBaseFacade databaseFacade, string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
                throw new ArgumentNullException(nameof(collectionName));

            this.collectionName = collectionName;
            this.databaseFacade = databaseFacade ?? throw new ArgumentNullException(nameof(databaseFacade));
            CreateCollectionAndIndexes();
        }

        private void CreateCollectionAndIndexes()
        {
            var collectionExists = databaseFacade.CollectionExistsAsync(collectionName).Result;
            databaseFacade.CreateCollectionIfNotExistsAsync<CodeMessageDocument>(collectionName);
            databaseFacade.CreateIndexIfNotExistsAsync<CodeMessageDocument>(collectionName, e => e.Code, "code");
            Seed();
        }

        public CodeMessage Obter(string code)
        {
            var document = databaseFacade.FindOne<CodeMessageDocument>(collectionName, expr => expr.Code == code);
            return document.Mapper();
        }

        public async Task<CodeMessage> ObterAsync(string code)
        {
            var document = await databaseFacade.FindOneAsync<CodeMessageDocument>(collectionName, expr => expr.Code == code);
            return document.Mapper();
        }

        public async Task<IList<CodeMessage>> ListarAsync()
        {
            var result = new List<CodeMessage>();
            var documents = await databaseFacade.FindAllAsync<CodeMessageDocument>(collectionName);
            if (documents != null && documents.Any())
            {
                foreach (var document in documents)
                {
                    result.Add(document.Mapper());
                }
            }
            return result;
        }

        public async Task<IList<CodeMessage>> ListarAsync(ValidationResult validationResult)
        {
            var result = new List<CodeMessage>();
            var messages = await ListarAsync();
            if (validationResult != null)
            {
                foreach (var error in validationResult.Errors)
                {
                    var message = messages.FirstOrDefault(codeMessage => codeMessage.Code == error.ErrorCode);
                    result.Add(message);
                }
            }
            return result;
        }

        public async Task<IList<CodeMessage>> ListarAsync(IEnumerable<ValidationResult> validationResults)
        {
            var result = new List<CodeMessage>();
            var messages = await ListarAsync();
            if (validationResults != null)
            {
                foreach (var validationResult in validationResults)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        var message = messages.FirstOrDefault(codeMessage => codeMessage.Code == error.ErrorCode);
                        result.Add(message);
                    }
                }
            }
            return result;
        }

        private void Seed()
        {
            var codeMessages = new List<CodeMessageDocument>
            {
                new CodeMessageDocument { Code = "ATE-POS-400", Message = "Bad Request" },
                new CodeMessageDocument { Code = "ATE-POS-409", Message = "Conflict" },
                new CodeMessageDocument { Code = "ATE-POS-500", Message = "Internal Server Error" },

                new CodeMessageDocument { Code = "ATE-POS-001", Message = "Campo CodigoCompanhia deve ser maior que 0." },
                new CodeMessageDocument { Code = "ATE-POS-002", Message = "Campo IdUnidadeNegocio deve ser maior que 0." },
                new CodeMessageDocument { Code = "ATE-POS-003", Message = "Campo IdSku deve ser maior que 0." },
                new CodeMessageDocument { Code = "ATE-POS-004", Message = "Campo IdPedido deve ser maior que 0." },
                new CodeMessageDocument { Code = "ATE-POS-005", Message = "Campo IdPedidoEntrega deve ser maior que 0." },
                new CodeMessageDocument { Code = "ATE-POS-006", Message = "O Header X-Funcionario é obrigatório." },
                new CodeMessageDocument { Code = "ATE-POS-007", Message = "O Header X-Protocolo é obrigatório." }
            };

            databaseFacade.BulkWriteAsync(collectionName, codeMessages, null);
        }
    }
}
