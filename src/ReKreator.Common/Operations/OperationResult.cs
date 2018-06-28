using System.Collections.Generic;

namespace ReKreator.Common.Operations
{
    public class OperationResult
    {
        public bool Succedeed { get; set; }
        public string Message { get; set; }

        public static OperationResult<T> Succeed<T>(T content, string message = null)
        {
            return new OperationResult<T> { Content = content, Succedeed = true, Message = message };
        }

        public static OperationResult<T> Fail<T>(T content, string errorMessage)
        {
            return new OperationResult<T> { Content = content, Succedeed = false, Message = errorMessage };
        }

        public static OperationResult Succeed(string message = null)
        {
            return new OperationResult { Succedeed = true, Message = message };
        }

        public static OperationResult Fail(string errorMessage)
        {
            return new OperationResult { Succedeed = false, Message = errorMessage };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Content { get; set; }
    }
}