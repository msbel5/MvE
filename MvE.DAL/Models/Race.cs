using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvE.DAL.Models
{
    public class Race
    {
        private string _name;
        private int _id;
        private int _speed;
        private char _size;
        private readonly int[] _abilityBonuses;

        [Key]
        public int Id { get => _id; set => _id = value; }

        public string Name { get => _name; set => _name = value; }

        public int Speed { get => _speed; set => _speed = value; }

        public int[] AbilityBonuses { get => _abilityBonuses; }

        public char Size { get => _size; set => _size = value; }


        public Race(string name, int speed, EAbilities[] abilityBonuses, char size)
        {
            _name = name;
            _id = Guid.NewGuid().GetHashCode();
            _speed = speed;
            _size = size;
            int[] abilityBonusesInt = Array.ConvertAll(abilityBonuses, value => (int)value);
            _abilityBonuses = abilityBonusesInt;
        }

        //private Race() { }

        /*
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        [Display(Name = "Half-Elf")]
        halfElf,
        [Display(Name = "Half-Orc")]
        halfOrc,
        Tiefling
        */
    }
}