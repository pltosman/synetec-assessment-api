using System;
using SynetecAssessmentApi.Shared.Utilities.Results.ComplexTypes;

namespace SynetecAssessmentApi.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } // ResultStatus.Success // ResultStatus.Error
        public string Message { get; }
        public Exception Exception { get; }
    }
}
