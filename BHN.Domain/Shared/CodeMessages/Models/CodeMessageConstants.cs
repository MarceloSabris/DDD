namespace BHN.Domain.Shared.CodeMessages.Models
{
    public sealed class CodeMessageConstants
    {
        private CodeMessageConstants() { }

        public static class StatusCode
        {
            public const string BadRequest = "ATE-POS-400";
            public const string Conflict = "ATE-POS-409";
            public const string InternalServerError = "ATE-POS-500";
        }

        public sealed class Validation
        {
            public const string CampoCodigoCompanhiaMaiorQueZero = "ATE-POS-001";
            public const string CampoIdUnidadeNegocioMaiorQueZero = "ATE-POS-002";
            public const string CampoIdSkuMaiorQueZero = "ATE-POS-003";
            public const string CampoIdPedidoMaiorQueZero = "ATE-POS-004";
            public const string CampoIdPedidoEntregaMaiorQueZero = "ATE-POS-005";
            public const string HeaderFuncionarioObrigatorio = "ATE-POS-006";
            public const string HeaderProtocoloObrigatorio = "ATE-POS-007";
        }
    }
}
