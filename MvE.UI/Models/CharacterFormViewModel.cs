using MvE.BLL.DTOs;
using MvE.BLL.DTOs.Enums;
using MvE.BLL.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvE.UI.Models
{
    
    public class CharacterFormViewModel
    {
        private int _id;
        private IEnumerable<char> _sizes;
        private IEnumerable<EAbilitiesDTO> _abilities;
        private IEnumerable<ESkillsDTO> _skills;
        private IEnumerable<EAlignmentDTO> _alignments;
        private string _charName;
        private EAlignmentDTO _alignment;
        private int[] _baseAbilityPoints_SDCIWC;
        private string _raceName;
        private char _raceSize;
        private int _raceSpeed;
        private int[] _raceAbilityBonuses_SDCIWC;
        private string _className;
        private int _classHitDie;
        private EAbilitiesDTO[] _classPrimaryAbilities;
        private EAbilitiesDTO[] _classSavingProficiencies;
        private ESkillsDTO[] _classProficientSkills;
        private string _backgroundName;
        private ESkillsDTO[] _backgroundProficientSkills;
        private string _title;
        
        public int Id { get => _id; set => _id = value; }        
        public string Title { get => _title; set => _title = value; }
        public IEnumerable<Char> Sizes { get => _sizes; set => _sizes = value; }
        public IEnumerable<EAbilitiesDTO> Abilities { get => _abilities; set => _abilities = value; }
        public IEnumerable<ESkillsDTO> Skills { get => _skills; set => _skills = value; }
        public IEnumerable<EAlignmentDTO> Alignments { get => _alignments; set => _alignments = value; }

        
        public string CharName { get => _charName; set => _charName = value; }        
        public EAlignmentDTO Alignment { get => _alignment; set => _alignment = value; }        
        public int[] BaseAbilityPoints_SDCIWC { get => _baseAbilityPoints_SDCIWC; set => _baseAbilityPoints_SDCIWC = value; }

        
        public string RaceName { get => _raceName; set => _raceName = value; }        
        public char RaceSize { get => _raceSize; set => _raceSize = value; }        
        public int RaceSpeed { get => _raceSpeed; set => _raceSpeed = value; }        
        public int[] RaceAbilityBonuses_SDCIWC { get => _raceAbilityBonuses_SDCIWC; set => _raceAbilityBonuses_SDCIWC = value; }

        
        public string ClassName { get => _className; set => _className = value; }        
        public int ClassHitDie { get => _classHitDie; set => _classHitDie = value; }        
        public EAbilitiesDTO[] ClassPrimaryAbilities { get => _classPrimaryAbilities; set => _classPrimaryAbilities = value; }        
        public EAbilitiesDTO[] ClassSavingProficiencies { get => _classSavingProficiencies; set => _classSavingProficiencies = value; }        
        public ESkillsDTO[] ClassProficientSkills { get => _classProficientSkills; set => _classProficientSkills = value; }

        
        public string BackgroundName { get => _backgroundName; set => _backgroundName = value; }        
        public ESkillsDTO[] BackgroundProficientSkills { get => _backgroundProficientSkills; set => _backgroundProficientSkills = value; }


        public CharacterFormViewModel(CharacterSheetDTO cs)
        {
            CharacterDTO _char = new CharacterDTO(cs);
            _id = cs.Id;
            if (_id != 0) { _title = _char.Name + " the " + _char.Race.Name + " " + _char.Class[0].Name; } else { _title = "Yeni Karakter"; }
            _charName = _char.Name;
            _alignment = _char.Alignment;
            _baseAbilityPoints_SDCIWC = new int[] { cs.Strength, cs.Dexterity, cs.Constitution, cs.Intelligence, cs.Wisdom, cs.Charisma };
            _raceName = _char.Race.Name;
            _raceSize = _char.Size;
            _raceSpeed = _char.Speed;
            _raceAbilityBonuses_SDCIWC = new int[] { 0, 0, 0, 0, 0, 0 };
            foreach (int item in _char.Race.AbilityBonuses)
            {
                switch (item)
                {
                    case 0:
                        _raceAbilityBonuses_SDCIWC[0] += 1;
                        _baseAbilityPoints_SDCIWC[0] -= 1;
                        break;
                    case 1:
                        _raceAbilityBonuses_SDCIWC[1] += 1;
                        _baseAbilityPoints_SDCIWC[1] -= 1;
                        break;
                    case 2:
                        _raceAbilityBonuses_SDCIWC[2] += 1;
                        _baseAbilityPoints_SDCIWC[2] -= 1;
                        break;
                    case 3:
                        _raceAbilityBonuses_SDCIWC[3] += 1;
                        _baseAbilityPoints_SDCIWC[3] -= 1;
                        break;
                    case 4:
                        _raceAbilityBonuses_SDCIWC[4] += 1;
                        _baseAbilityPoints_SDCIWC[4] -= 1;
                        break;
                    case 5:
                        _raceAbilityBonuses_SDCIWC[5] += 1;
                        _baseAbilityPoints_SDCIWC[5] -= 1;
                        break;
                    default:
                        break;
                }
            }
            _className = _char.Class[0].Name;
            _classHitDie = _char.Class[0].HitDie;
            _classPrimaryAbilities = Array.ConvertAll(_char.Class[0].PrimaryAbilities, val => (EAbilitiesDTO)val);
            _classSavingProficiencies = Array.ConvertAll(_char.Class[0].SavingProficiencies, val => (EAbilitiesDTO)val);
            _classProficientSkills = Array.ConvertAll(_char.Class[0].ProficientSkills, val => (ESkillsDTO)val);
            _backgroundName = _char.Background.Name;
            _backgroundProficientSkills = Array.ConvertAll(_char.Background.ProficientSkills, val => (ESkillsDTO)val);
            _sizes = new char[] { 'T', 'S', 'M', 'L', 'H' };
            _abilities = new EAbilitiesDTO[] { EAbilitiesDTO.Strength, EAbilitiesDTO.Dexterity, EAbilitiesDTO.Constitution, EAbilitiesDTO.Intelligence, EAbilitiesDTO.Wisdom, EAbilitiesDTO.Charisma };
            _skills = new ESkillsDTO[] { ESkillsDTO.Acrobatics, ESkillsDTO.animalHandling, ESkillsDTO.Arcana, ESkillsDTO.Athletics, ESkillsDTO.Deception, ESkillsDTO.History, ESkillsDTO.Insight, ESkillsDTO.Intimidation, ESkillsDTO.Investigation, ESkillsDTO.Medicine, ESkillsDTO.Nature, ESkillsDTO.Perception, ESkillsDTO.Performance, ESkillsDTO.Persuasion, ESkillsDTO.Religion, ESkillsDTO.sleightOfHand, ESkillsDTO.Stealth, ESkillsDTO.Survival };
            _alignments = new EAlignmentDTO[] { EAlignmentDTO.chaoticEvil, EAlignmentDTO.chaoticGood, EAlignmentDTO.chaoticNeutral, EAlignmentDTO.lawfulEvil, EAlignmentDTO.lawfulGood, EAlignmentDTO.lawfulNeutral, EAlignmentDTO.neutralEvil, EAlignmentDTO.neutralGood, EAlignmentDTO.trueNeutral };
        }

        public CharacterFormViewModel()
        {
            _title = "Yeni Karakter";
            _sizes = new Char[] { 'T', 'S', 'M', 'L', 'H' };
            _abilities = new EAbilitiesDTO[] { EAbilitiesDTO.Strength, EAbilitiesDTO.Dexterity, EAbilitiesDTO.Constitution, EAbilitiesDTO.Intelligence, EAbilitiesDTO.Wisdom, EAbilitiesDTO.Charisma };
            _skills = new ESkillsDTO[] { ESkillsDTO.Acrobatics, ESkillsDTO.animalHandling, ESkillsDTO.Arcana, ESkillsDTO.Athletics, ESkillsDTO.Deception, ESkillsDTO.History, ESkillsDTO.Insight, ESkillsDTO.Intimidation, ESkillsDTO.Investigation, ESkillsDTO.Medicine, ESkillsDTO.Nature, ESkillsDTO.Perception, ESkillsDTO.Performance, ESkillsDTO.Persuasion, ESkillsDTO.Religion, ESkillsDTO.sleightOfHand, ESkillsDTO.Stealth, ESkillsDTO.Survival };
            _alignments = new EAlignmentDTO[] { EAlignmentDTO.chaoticEvil, EAlignmentDTO.chaoticGood, EAlignmentDTO.chaoticNeutral, EAlignmentDTO.lawfulEvil, EAlignmentDTO.lawfulGood, EAlignmentDTO.lawfulNeutral, EAlignmentDTO.neutralEvil, EAlignmentDTO.neutralGood, EAlignmentDTO.trueNeutral };
        }
    }
}
