namespace BHN.Infrastructure.Http.Shared
{
    public sealed class LogInfo
    {
        public static class CriarCodigoPostagem
        {
            public const string Description = "Gerar Código Postagem";
            public const string MainEntity = "CriarCodigoDto";
        }

        public static class ConsultarPedido
        {
            public const string Description = "Consultar Pedido";
            public const string MainEntity = "Pedido";
        }

        public static class CancelarCodigoPostagem
        {
            public const string Description = "Cancelar Código Postagem";
            public const string MainEntity = "CodigoPostagem";
        }

        public static class AtualizarCodigoPostagem
        {
            public const string Description = "Atualizar Código Postagem";
            public const string MainEntity = "CodigoPostagem";
        }

        
    }
}
