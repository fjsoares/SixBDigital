using System.ComponentModel.DataAnnotations;


namespace SixBDigital.CarValeting.Core.Enumerators
{
    public enum Flexibility
    {
        [Display(Name = "+/- One Day")]
        PlusMinusOneDay = 0,

        [Display(Name = "+/- Two Days")]
        PlusMinusTwoDays = 1,

        [Display(Name = "+/- Three Days")]
        PlusMinusThreeDays = 2
    }
}
