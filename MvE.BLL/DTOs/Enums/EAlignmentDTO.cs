using System.ComponentModel.DataAnnotations;

namespace MvE.BLL.DTOs.Enums
{
    public enum EAlignmentDTO
    {
        [Display(Name = "Lawful Good")]
        lawfulGood,
        [Display(Name = "Neutral Good")]
        neutralGood,
        [Display(Name = "Chaotic Good")]
        chaoticGood,
        [Display(Name = "Lawful Neutral")]
        lawfulNeutral,
        [Display(Name = "True Neutral")]
        trueNeutral,
        [Display(Name = "Chaotic Neutral")]
        chaoticNeutral,
        [Display(Name = "Lawful Evil")]
        lawfulEvil,
        [Display(Name = "Neutral Evil")]
        neutralEvil,
        [Display(Name = "Chaotic Evil")]
        chaoticEvil
    }
}