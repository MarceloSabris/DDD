using System.Collections.Generic;
using System.Linq;

namespace Loja.Domain.Shared.CodeMessages.Models
{
    /// <summary>
    /// Represents an informational message with code.
    /// </summary>
    public class CodeMessage
    {
        /// <summary>
        /// Create a new message with code. 
        /// </summary>
        /// <param name="code">The message code.</param>
        /// <param name="message">The message.</param>
        public CodeMessage(string code, string message)
            : this(code, message, string.Empty)
        {
        }

        /// <summary>
        /// Create a new message with code. 
        /// </summary>
        /// <param name="code">The message code.</param>
        /// <param name="message">The message.</param>
        /// <param name="formattedMessage">The formatted message.</param>
        public CodeMessage(string code, string message, string formattedMessage)
        {
            Code = code;
            Message = message;
            FormattedMessageWithArguments = formattedMessage;
        }

        /// <summary>
        /// Get or set the code.
        /// </summary>
        public string Code { get; private set; }
        /// <summary>
        /// Get or set the message.
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Get or set the formatted message with arguments.
        /// </summary>
        public string FormattedMessageWithArguments { get; set; }
        /// <summary>
        /// Get the values used in the message.
        /// </summary>
        public IList<string> FormattedMessagePlaceholderValues { get; private set; } = new List<string>();
        /// <summary>
        /// Get message value.
        /// </summary>
        public string Value
        {
            get
            {
                if (HasFormattedMessage && FormattedMessagePlaceholderValues.Any())
                    return string.Format(FormattedMessageWithArguments, FormattedMessagePlaceholderValues.ToArray());

                return Message;
            }
        }
        /// <summary>
        /// Checks for formatted message. 
        /// </summary>        
        public bool HasFormattedMessage { get { return string.IsNullOrWhiteSpace(FormattedMessageWithArguments); } }
        /// <summary>
        /// Add a new value for formatted message.
        /// </summary>
        /// <param name="value"></param>
        public void Add(string value)
        {
            if (HasFormattedMessage)
                FormattedMessagePlaceholderValues.Add(value);
        }

        /// <summary>
        /// Returns a string that represents the code message.
        /// </summary>
        /// <returns>A string that represents the current code message.</returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Code) && !string.IsNullOrWhiteSpace(Message))
                return $"{Code}-{Message}";

            return base.ToString();
        }
    }
}
