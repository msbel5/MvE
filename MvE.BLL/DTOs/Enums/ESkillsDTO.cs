using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.BLL.DTOs.Enums
{
    public enum ESkillsDTO
    {
        Athletics,
        Acrobatics,
        [Display(Name = "Sleight Of Hand")]
        sleightOfHand,
        Stealth,
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        [Display(Name = "Animal Handling")]
        animalHandling,
        Insight,
        Medicine,
        Perception,
        Survival,
        Deception,
        Intimidation,
        Performance,
        Persuasion
    }
}
