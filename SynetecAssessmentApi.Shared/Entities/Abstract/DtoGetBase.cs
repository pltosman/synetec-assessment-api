using System;
using SynetecAssessmentApi.Shared.Utilities.Results.ComplexTypes;

namespace SynetecAssessmentApi.Shared.Entities.Abstract
{
    public class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
