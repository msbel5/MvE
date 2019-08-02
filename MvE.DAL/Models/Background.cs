using MvE.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class Background
    {
        private readonly int _id;
        private string _name;
        private readonly int[] _proficientSkills;

        [Key]
        public int Id { get => _id; }

        public string Name { get => _name; set => _name = value; }


        public int[] ProficientSkills { get => _proficientSkills; }


        public Background(string name, ESkills[] proficientSkills)
        {
            _name = name;
            _id = Guid.NewGuid().GetHashCode();
            int[] proficientSkillsInt = Array.ConvertAll(proficientSkills, value => (int)value);
            _proficientSkills = proficientSkillsInt;
        }

        //private Background() { }

    }
}
