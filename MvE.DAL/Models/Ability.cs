using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class Ability
    {
        private int _score;
        private int _id;
        private bool _isProficient;

        [Key]        
        public int Id { get => _id; set => _id = value; }
        
        public int Score { get => _score; set => _score = value; }

        public int Modifier
        {
            get
            {
                decimal Score = _score;
                return (int)Math.Floor((Score - 10) / 2);
            }
        }
        
        public bool IsProficient { get => _isProficient; set => _isProficient = value; }

        public Ability(int score, bool isProficient)
        {
            _score = score;
            _isProficient = isProficient;
            _id = Guid.NewGuid().GetHashCode();
        }
               
    }
}
