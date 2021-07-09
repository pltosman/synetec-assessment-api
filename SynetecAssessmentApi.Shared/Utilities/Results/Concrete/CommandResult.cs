using System;
namespace SynetecAssessmentApi.Shared.Utilities.Results.Concrete
{
    public class CommandResult
    {

        public string Message { get; set; }
        public object Data { get; set; }
        public string ErrorCode { get; set; }

        public static CommandResult GetError(string message)
        {
            return new CommandResult
            {
                ErrorCode = Guid.NewGuid().ToString().ToUpper(),
                Data = default,
                Message = message
            };
        }

        public static CommandResult GetError(object data, string message)
        {
            return new CommandResult
            {
                ErrorCode = Guid.NewGuid().ToString().ToUpper(),
                Data = data,
                Message = message
            };
        }

        public static CommandResult GetSuccess(object data, string message = null)
        {
            return new CommandResult
            {
                Data = data,
                Message = message
            };
        }
    }

    public static class CommandResultHelper
    {
        public static T GetT<T>(this CommandResult commandResult)
        {
            return (T)commandResult.Data;
        }
    }
}
