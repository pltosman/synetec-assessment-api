using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SynetecAssessmentApi.Domain.Dtos
{
    public class CalculateBonusDto
    {
        [DisplayName("TotalBonusPoolAmount")]
        [Required(ErrorMessage = "{0} missing.")]
       
        public int? TotalBonusPoolAmount { get; set; }


        [DisplayName("EmployeeId")]
        [Required(ErrorMessage = "{0} missing.")]
        public int? SelectedEmployeeId { get; set; }
    }
}
