using System.ComponentModel.DataAnnotations;

namespace SixBDigital.CarValeting.Core.Enumerators
{
    public enum VehicleSize
    {
        [Display(Name = "Small")]
        Small = 0,
        [Display(Name = "Medium")]
        Medium = 1,
        [Display(Name = "Large")]
        Large = 2,
        [Display(Name = "Van")]
        Van = 3
    }
}
