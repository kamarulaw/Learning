namespace Acme.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResult<TResult>
    {
        public OperationResult()
        {
        }

        public OperationResult(TResult result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public TResult Result { get; set; }
        public string Message { get; set; }
    }

    // Provides a decimal amount and message.  Useful as a method return type
    // Example code to highlight how we would have had to define different types of OperationResult classes if we had not made use of generics (OperationResultInteger, OperationResultString,etc.)
    public class OperationResultDecimal
    {
        // Properties 
        public decimal Result { get; set; }
        public string Message { get; set; }

        // Constructors
        public OperationResultDecimal()
        {
        }

        public OperationResultDecimal(decimal result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }
    }

}
