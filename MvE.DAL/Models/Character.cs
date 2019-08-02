using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class Character
    {
        #region privateProperties
        private readonly int _id;
        private readonly string _name;
        private Race _race;
        private Class[] _class = new Class[1];
        private int[] _hitDie = new int[1];
        private readonly EAlignment _alignment;
        private Ability _charisma;
        private Ability _wisdom;
        private Ability _intelligence;
        private Ability _strength;
        private Ability _dexterity;
        private Ability _constitution;
        private int _level = 1;
        private int _experience = 0;
        private int _health = 0;
        private int _maxHitPoint;
        private int _deathSaves = 0;
        private readonly int[] _levelExp = { 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000 };
        private Skill _persuasion;
        private Skill _athletics;
        private Skill _acrobatics;
        private Skill _sleightOfHand;
        private Skill _stealth;
        private Skill _arcana;
        private Skill _history;
        private Skill _investigation;
        private Skill _nature;
        private Skill _religion;
        private Skill _animalHandling;
        private Skill _insight;
        private Skill _medicine;
        private Skill _perception;
        private Skill _survival;
        private Skill _deception;
        private Skill _intimidation;
        private Skill _performance;
        private Background _background;

        #endregion

        [Key]
        public int Id { get => _id; }

        public string Name { get => _name; }

        public Race Race { get => _race; }

        public Class[] Class { get => _class; }

        public Background Background { get => _background; }

        public EAlignment Alignment { get => _alignment; }

        #region Abilities
        public Ability Strength { get => _strength; }
        public Ability Dexterity { get => _dexterity; }
        public Ability Constitution { get => _constitution; }
        public Ability Intelligence { get => _intelligence; }
        public Ability Wisdom { get => _wisdom; }
        public Ability Charisma { get => _charisma; }
        #endregion

        #region Skills
        #region Strength

        public Skill Athletics { get => _athletics; }
        #endregion
        #region Dexterity

        public Skill Acrobatics { get => _acrobatics; }

        [Display(Name = "Sleight Of Hand")]
        public Skill SleightOfHand { get => _sleightOfHand; }

        public Skill Stealth { get => _stealth; }
        #endregion
        #region Intelligence

        public Skill Arcana { get => _arcana; }

        public Skill History { get => _history; }

        public Skill Investigation { get => _investigation; }

        public Skill Nature { get => _nature; }

        public Skill Religion { get => _religion; }
        #endregion
        #region Wisdom

        [Display(Name = "Animal Handling")]
        public Skill AnimalHandling { get => _animalHandling; }

        public Skill Insight { get => _insight; }

        public Skill Medicine { get => _medicine; }

        public Skill Perception { get => _perception; }

        public Skill Survival { get => _survival; }
        #endregion
        #region Charisma

        public Skill Deception { get => _deception; }

        public Skill Intimidation { get => _intimidation; }

        public Skill Performance { get => _performance; }

        public Skill Persuasion { get => _persuasion; }
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

        public Character(string name, int[] abilityPoints_SDCIWC, Race race, Class CharClass, EAlignment alignment, Background background)
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

        public void AbilityBonusAttainer(int[] abilities)
        {
            foreach (int ability in abilities)
            {
                switch (ability)
                {
                    case (int)EAbilities.Strength:
                        _strength.Score += 1;
                        break;
                    case (int)EAbilities.Dexterity:
                        _dexterity.Score += 1;
                        break;
                    case (int)EAbilities.Constitution:
                        _constitution.Score += 1;
                        break;
                    case (int)EAbilities.Intelligence:
                        _intelligence.Score += 1;
                        break;
                    case (int)EAbilities.Wisdom:
                        _wisdom.Score += 1;
                        break;
                    case (int)EAbilities.Charisma:
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
                        case (int)EAbilities.Strength:
                            _strength.IsProficient = true;
                            break;
                        case (int)EAbilities.Dexterity:
                            _dexterity.IsProficient = true;
                            break;
                        case (int)EAbilities.Constitution:
                            _constitution.IsProficient = true;
                            break;
                        case (int)EAbilities.Intelligence:
                            _intelligence.IsProficient = true;
                            break;
                        case (int)EAbilities.Wisdom:
                            _wisdom.IsProficient = true;
                            break;
                        case (int)EAbilities.Charisma:
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
                    case (int)ESkills.Athletics:
                        _athletics.IsProficient = true;
                        break;
                    case (int)ESkills.Acrobatics:
                        _acrobatics.IsProficient = true;
                        break;
                    case (int)ESkills.sleightOfHand:
                        _sleightOfHand.IsProficient = true;
                        break;
                    case (int)ESkills.Stealth:
                        _stealth.IsProficient = true;
                        break;
                    case (int)ESkills.Arcana:
                        _arcana.IsProficient = true;
                        break;
                    case (int)ESkills.History:
                        _history.IsProficient = true;
                        break;
                    case (int)ESkills.Investigation:
                        _investigation.IsProficient = true;
                        break;
                    case (int)ESkills.Nature:
                        _nature.IsProficient = true;
                        break;
                    case (int)ESkills.Religion:
                        _religion.IsProficient = true;
                        break;
                    case (int)ESkills.animalHandling:
                        _animalHandling.IsProficient = true;
                        break;
                    case (int)ESkills.Insight:
                        _insight.IsProficient = true;
                        break;
                    case (int)ESkills.Medicine:
                        _medicine.IsProficient = true;
                        break;
                    case (int)ESkills.Perception:
                        _perception.IsProficient = true;
                        break;
                    case (int)ESkills.Survival:
                        _survival.IsProficient = true;
                        break;
                    case (int)ESkills.Deception:
                        _deception.IsProficient = true;
                        break;
                    case (int)ESkills.Intimidation:
                        _intimidation.IsProficient = true;
                        break;
                    case (int)ESkills.Performance:
                        _performance.IsProficient = true;
                        break;
                    case (int)ESkills.Persuasion:
                        _persuasion.IsProficient = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AbilityPointDistributor(int[] abilityPoints_SDCIWC)
        {
            _strength = new Ability(abilityPoints_SDCIWC[0], false);
            _dexterity = new Ability(abilityPoints_SDCIWC[1], false);
            _constitution = new Ability(abilityPoints_SDCIWC[2], false);
            _intelligence = new Ability(abilityPoints_SDCIWC[3], false);
            _wisdom = new Ability(abilityPoints_SDCIWC[4], false);
            _charisma = new Ability(abilityPoints_SDCIWC[5], false);
        }

        public void SkillAranger()
        {

            #region Strength

            _athletics = new Skill(_strength, false);

            #endregion

            #region Dexterity

            _acrobatics = new Skill(_dexterity, false);

            _sleightOfHand = new Skill(_dexterity, false);

            _stealth = new Skill(_dexterity, false);

            #endregion

            #region Intelligence

            _arcana = new Skill(_intelligence, false);

            _history = new Skill(_intelligence, false);

            _investigation = new Skill(_intelligence, false);

            _nature = new Skill(_intelligence, false);

            _religion = new Skill(_intelligence, false);

            #endregion

            #region Wisdom

            _animalHandling = new Skill(_wisdom, false);

            _insight = new Skill(_wisdom, false);

            _medicine = new Skill(_wisdom, false);

            _perception = new Skill(_wisdom, false);

            _survival = new Skill(_wisdom, false);
            #endregion

            #region Charisma

            _deception = new Skill(_charisma, false);

            _intimidation = new Skill(_charisma, false);

            _performance = new Skill(_charisma, false);

            _persuasion = new Skill(_charisma, false);

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

        public void LevelUp(Class newClass)
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

        private Character()
        {

        }

    }
}
