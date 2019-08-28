using MvE.BLL.DTOs.Enums;
using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.BLL.DTOs
{
    public class CharacterDTO
    {
        #region privateProperties
        private readonly int _id;
        private readonly string _name;
        private RaceDTO _race;
        private ClassDTO[] _class = new ClassDTO[1];
        private int[] _hitDie = new int[1];
        private readonly EAlignmentDTO _alignment;
        private AbilityDTO _charisma;
        private AbilityDTO _wisdom;
        private AbilityDTO _intelligence;
        private AbilityDTO _strength;
        private AbilityDTO _dexterity;
        private AbilityDTO _constitution;
        private int _level = 1;
        private int _experience = 0;
        private int _health = 0;
        private int _maxHitPoint;
        private int _deathSaves = 0;
        private readonly int[] _levelExp = { 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        private SkillDTO _persuasion;
        private SkillDTO _athletics;
        private SkillDTO _acrobatics;
        private SkillDTO _sleightOfHand;
        private SkillDTO _stealth;
        private SkillDTO _arcana;
        private SkillDTO _history;
        private SkillDTO _investigation;
        private SkillDTO _nature;
        private SkillDTO _religion;
        private SkillDTO _animalHandling;
        private SkillDTO _insight;
        private SkillDTO _medicine;
        private SkillDTO _perception;
        private SkillDTO _survival;
        private SkillDTO _deception;
        private SkillDTO _intimidation;
        private SkillDTO _performance;
        private BackgroundDTO _background;

        #endregion

        [Key]
        public int Id { get => _id; }

        public string Name { get => _name; }

        public RaceDTO Race { get => _race; }

        public ClassDTO[] Class { get => _class; }

        public BackgroundDTO Background { get => _background; }

        public EAlignmentDTO Alignment { get => _alignment; }

        #region Abilities
        public AbilityDTO Strength { get => _strength; }
        public AbilityDTO Dexterity { get => _dexterity; }
        public AbilityDTO Constitution { get => _constitution; }
        public AbilityDTO Intelligence { get => _intelligence; }
        public AbilityDTO Wisdom { get => _wisdom; }
        public AbilityDTO Charisma { get => _charisma; }
        #endregion

        #region Skills
        #region Strength

        public SkillDTO Athletics { get => _athletics; }
        #endregion
        #region Dexterity

        public SkillDTO Acrobatics { get => _acrobatics; }

        [Display(Name = "Sleight Of Hand")]
        public SkillDTO SleightOfHand { get => _sleightOfHand; }

        public SkillDTO Stealth { get => _stealth; }
        #endregion
        #region Intelligence

        public SkillDTO Arcana { get => _arcana; }

        public SkillDTO History { get => _history; }

        public SkillDTO Investigation { get => _investigation; }

        public SkillDTO Nature { get => _nature; }

        public SkillDTO Religion { get => _religion; }
        #endregion
        #region Wisdom

        [Display(Name = "Animal Handling")]
        public SkillDTO AnimalHandling { get => _animalHandling; }

        public SkillDTO Insight { get => _insight; }

        public SkillDTO Medicine { get => _medicine; }

        public SkillDTO Perception { get => _perception; }

        public SkillDTO Survival { get => _survival; }
        #endregion
        #region Charisma

        public SkillDTO Deception { get => _deception; }

        public SkillDTO Intimidation { get => _intimidation; }

        public SkillDTO Performance { get => _performance; }

        public SkillDTO Persuasion { get => _persuasion; }
        #endregion
        #endregion

        public int ProficiencyBonus { get { return (int)((Level / 4.000001) + 2); } }

        public int PassiveWisdom
        {
            get
            {
                int _passiveWisdom = 10 + Wisdom.Modifier;
                if (Wisdom.IsProficient)
                {
                    _passiveWisdom += ProficiencyBonus;
                }
                return _passiveWisdom;
            }
        }
                
        public int Initiative { get { return _dexterity.Modifier; } }

        public int Speed { get { return _race.Speed; } }

        public char Size { get { return _race.Size; } }

        public int MaxHitPoint { get => _maxHitPoint; }

        public int HitPoint { get => _health; }

        public int[] HitDice { get => _hitDie; }

        public int Level { get => _level; }

        public int Experience { get => _experience; }

        public CharacterDTO(string name, int[] abilityPoints_SDCIWC, RaceDTO race, ClassDTO CharClass, EAlignmentDTO alignment, BackgroundDTO background)
        {
            _id = Guid.NewGuid().GetHashCode();
            _name = name;
            AbilityPointDistributor(abilityPoints_SDCIWC);
            SkillAranger();
            _race = race;
            _class[0] = CharClass;
            _alignment = alignment;
            _background = background;
            _hitDie[0] = _class[0].HitDie;
            _maxHitPoint = _hitDie[0];
            _health = _maxHitPoint;
            AbilityBonusAttainer(_race.AbilityBonuses);
            AbilityProficiencyAtainer(_class[0].SavingProficiencies);
            SkillProficiencyAtainer(_class[0].ProficientSkills);
            SkillProficiencyAtainer(_background.ProficientSkills);
        }


        public CharacterDTO(CharacterSheetDTO cs)
        {
            int[] RaceAbilityBonusses = Array.ConvertAll(cs.RaceAbilityBonusses.Split(','), x => int.Parse(x));
            int[] ClassPrimaryAbilities = Array.ConvertAll(cs.ClassPrimaryAbilities.Split(','), x => int.Parse(x));
            int[] ClassSavingProficiencies = Array.ConvertAll(cs.ClassSavingProficiencies.Split(','), x => int.Parse(x));
            int[] ClassProficientSkills = Array.ConvertAll(cs.ClassProficientSkills.Split(','), x => int.Parse(x));
            int[] BackgroundProficientSkills = Array.ConvertAll(cs.BackgroundProficientSkills.Split(','), x => int.Parse(x));
            int[] TotalAbilityBonus = new int[] { cs.Stealth, cs.Dexterity, cs.Constitution, cs.Intelligence, cs.Wisdom, cs.Charisma };

            foreach (int ability in RaceAbilityBonusses)
            {
                switch (ability)
                {
                    case (int)EAbilities.Strength:
                        TotalAbilityBonus[0] -= 1;
                        break;
                    case (int)EAbilities.Dexterity:
                        TotalAbilityBonus[1] -= 1;
                        break;
                    case (int)EAbilities.Constitution:
                        TotalAbilityBonus[2] -= 1;
                        break;
                    case (int)EAbilities.Intelligence:
                        TotalAbilityBonus[3] -= 1;
                        break;
                    case (int)EAbilities.Wisdom:
                        TotalAbilityBonus[4] -= 1;
                        break;
                    case (int)EAbilities.Charisma:
                        TotalAbilityBonus[5] -= 1;
                        break;
                    default:
                        break;
                }
            }

            _id = cs.Id;
            _name = cs.Name;
            AbilityPointDistributor(TotalAbilityBonus);
            SkillAranger();
            _race = new RaceDTO(cs.Race, cs.Speed, Array.ConvertAll(RaceAbilityBonusses, x => (EAbilitiesDTO)x), cs.Size);
            _class[0] = new ClassDTO(cs.Class, cs.HitDie, Array.ConvertAll(ClassPrimaryAbilities, x => (EAbilitiesDTO)x), Array.ConvertAll(ClassSavingProficiencies, x => (EAbilitiesDTO)x), Array.ConvertAll(ClassProficientSkills, x => (ESkillsDTO)x));
            _alignment = (EAlignmentDTO)Enum.Parse(typeof(EAlignment), cs.Alignment);
            _background = new BackgroundDTO(cs.Background, Array.ConvertAll(BackgroundProficientSkills, x => (ESkillsDTO)x));
            _hitDie[0] = cs.HitDie;
            _maxHitPoint = cs.MaxHitPoints;
            _health = _maxHitPoint;
            AbilityBonusAttainer(_race.AbilityBonuses);
            AbilityProficiencyAtainer(_class[0].SavingProficiencies);
            SkillProficiencyAtainer(_class[0].ProficientSkills);
            SkillProficiencyAtainer(_background.ProficientSkills);
        }

        public void AbilityBonusAttainer(int[] abilities)
        {
            foreach (int ability in abilities)
            {
                switch (ability)
                {
                    case (int)EAbilitiesDTO.Strength:
                        _strength.Score += 1;
                        break;
                    case (int)EAbilitiesDTO.Dexterity:
                        _dexterity.Score += 1;
                        break;
                    case (int)EAbilitiesDTO.Constitution:
                        _constitution.Score += 1;
                        break;
                    case (int)EAbilitiesDTO.Intelligence:
                        _intelligence.Score += 1;
                        break;
                    case (int)EAbilitiesDTO.Wisdom:
                        _wisdom.Score += 1;
                        break;
                    case (int)EAbilitiesDTO.Charisma:
                        _charisma.Score += 1;
                        break;
                    default:
                        break;
                }            
            }

        }

        public void AbilityProficiencyAtainer(int[] abilities)
        {
            {
                foreach (int ability in abilities)
                {
                    switch (ability)
                    {
                        case (int)EAbilitiesDTO.Strength:
                            _strength.IsProficient = true;
                            break;
                        case (int)EAbilitiesDTO.Dexterity:
                            _dexterity.IsProficient = true;
                            break;
                        case (int)EAbilitiesDTO.Constitution:
                            _constitution.IsProficient = true;
                            break;
                        case (int)EAbilitiesDTO.Intelligence:
                            _intelligence.IsProficient = true;
                            break;
                        case (int)EAbilitiesDTO.Wisdom:
                            _wisdom.IsProficient = true;
                            break;
                        case (int)EAbilitiesDTO.Charisma:
                            _charisma.IsProficient = true;
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        public void SkillProficiencyAtainer(int[] skills)
        {
            foreach (int skill in skills)
            {
                switch (skill)
                {
                    case (int)ESkillsDTO.Athletics:
                        _athletics.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Acrobatics:
                        _acrobatics.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.sleightOfHand:
                        _sleightOfHand.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Stealth:
                        _stealth.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Arcana:
                        _arcana.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.History:
                        _history.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Investigation:
                        _investigation.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Nature:
                        _nature.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Religion:
                        _religion.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.animalHandling:
                        _animalHandling.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Insight:
                        _insight.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Medicine:
                        _medicine.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Perception:
                        _perception.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Survival:
                        _survival.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Deception:
                        _deception.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Intimidation:
                        _intimidation.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Performance:
                        _performance.IsProficient = true;
                        break;
                    case (int)ESkillsDTO.Persuasion:
                        _persuasion.IsProficient = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AbilityPointDistributor(int[] abilityPoints_SDCIWC)
        {
            _strength = new AbilityDTO(abilityPoints_SDCIWC[0], false);
            _dexterity = new AbilityDTO(abilityPoints_SDCIWC[1], false);
            _constitution = new AbilityDTO(abilityPoints_SDCIWC[2], false);
            _intelligence = new AbilityDTO(abilityPoints_SDCIWC[3], false);
            _wisdom = new AbilityDTO(abilityPoints_SDCIWC[4], false);
            _charisma = new AbilityDTO(abilityPoints_SDCIWC[5], false);
        }

        public void SkillAranger()
        {

            #region Strength

            _athletics = new SkillDTO(_strength, false);

            #endregion

            #region Dexterity

            _acrobatics = new SkillDTO(_dexterity, false);

            _sleightOfHand = new SkillDTO(_dexterity, false);

            _stealth = new SkillDTO(_dexterity, false);

            #endregion

            #region Intelligence

            _arcana = new SkillDTO(_intelligence, false);

            _history = new SkillDTO(_intelligence, false);

            _investigation = new SkillDTO(_intelligence, false);

            _nature = new SkillDTO(_intelligence, false);

            _religion = new SkillDTO(_intelligence, false);

            #endregion

            #region Wisdom

            _animalHandling = new SkillDTO(_wisdom, false);

            _insight = new SkillDTO(_wisdom, false);

            _medicine = new SkillDTO(_wisdom, false);

            _perception = new SkillDTO(_wisdom, false);

            _survival = new SkillDTO(_wisdom, false);
            #endregion

            #region Charisma

            _deception = new SkillDTO(_charisma, false);

            _intimidation = new SkillDTO(_charisma, false);

            _performance = new SkillDTO(_charisma, false);

            _persuasion = new SkillDTO(_charisma, false);

            #endregion
        }
            
        public void GainExp(int experience)
        {
            _experience += experience;
            if (_experience >= _levelExp[_level] && _level < 20) { _level += 1; Array.Resize(ref _class, _class.Length + 1); Array.Resize(ref _hitDie, _hitDie.Length + 1); }
        }

        public void Heal(int hitPoint)
        {

            if (hitPoint < 0 && _health <= 0) _deathSaves--;
            _health += hitPoint;
        }

        public void Stabilize(bool deathSave)
        {
            if (deathSave) _deathSaves++; _deathSaves--;
            if (_deathSaves == 3) { _health = 1; _deathSaves = 0; } else if (_deathSaves == -3) { _health = 0; _deathSaves = 0; };
        }

        public void LevelUp(ClassDTO newClass)
        {

            if (_class[_class.Length-1] == null)
            {
                _class[_class.Length-1] = newClass;
                Random rnd = new Random();
                _maxHitPoint += rnd.Next(1, newClass.HitDie);
                _health = _maxHitPoint;
                _hitDie[_hitDie.Length-1] = newClass.HitDie;
            }
        }

        private CharacterDTO()
        {

        }

    }
}
