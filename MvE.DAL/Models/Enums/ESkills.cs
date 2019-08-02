using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models.Enums
{
    public enum ESkills
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
