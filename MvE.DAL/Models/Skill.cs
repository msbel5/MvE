using MvE.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class Skill
    {
        private readonly int _id;        
        private readonly Ability _associatedAbility;
        private bool _isProficient;

        [Key]
        public int Id { get => _id;  }

        public Ability AssociatedAbility { get => _associatedAbility; }

        public bool IsProficient { get => _isProficient; set => _isProficient = value; }

        public int Bonus
        {
            get
            {
                return AssociatedAbility.Modifier;
            }
        }

        public Skill( Ability associatedAbility, bool isProficient)
        {
            _id = Guid.NewGuid().GetHashCode();            
            _associatedAbility = associatedAbility;
            _isProficient = isProficient;
        }
                
    }
}
