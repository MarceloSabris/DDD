using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Framework.Logging.Utils
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
            public const string CampoIdCompraObrigatorio = "Campo Id Compra obrigatório.";
            public const string CampoIdCompraSKUObrigatorio = "Campo Id compra sku obrigatório.";
            public const string CampoStautsAceiteObrigatorio = "Campo Stauts Aceite obrigatório.";

        }
    }
}
