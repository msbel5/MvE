using MvE.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.BLL.DTOs
{
    public class SkillDTO
    {
        private readonly int _id;        
        private readonly AbilityDTO _associatedAbility;
        private bool _isProficient;

        [Key]
        public int Id { get => _id;  }

        public AbilityDTO AssociatedAbility { get => _associatedAbility; }

        public bool IsProficient { get => _isProficient; set => _isProficient = value; }

        public int Bonus
        {
            get
            {
                return AssociatedAbility.Modifier;
            }
        }

        public SkillDTO( AbilityDTO associatedAbility, bool isProficient)
        {
            _id = Guid.NewGuid().GetHashCode();            
            _associatedAbility = associatedAbility;
            _isProficient = isProficient;
        }

        private SkillDTO()
        {

        }

    }
}
