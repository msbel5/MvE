using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class CharacterSheet
    {

        private int _id;
        private string _name;
        private string _race;
        private string _class;
        private int _level;
        private string _alignment;
        private string _background;
        private int _proficiencyBonus;
        private int _speed;
        private int _initiative;
        private int _passiveWisdom;
        private int _maxHitPoints;
        private int _hitDie;
        private int _strength;
        private int _strengthModifier;
        private int _strengthSave;
        private int _dexterity;
        private int _dexterityModifier;
        private int _dexteritySave;
        private int _constitution;
        private int _constitutionModifier;
        private int _constitutionSave;
        private int _intelligence;
        private int _intelligenceModifier;
        private int _intelligenceSave;
        private int _wisdom;
        private int _wisdomModifier;
        private int _wisdomSave;
        private int _charisma;
        private int _charismaModifier;
        private int _charismaSave;
        private int _acrobatics;
        private int _animalHandling;
        private int _arcana;
        private int _athletics;
        private int _deception;
        private int _history;
        private int _insight;
        private int _intimidation;
        private int _investigation;
        private int _medicine;
        private int _nature;
        private int _perception;
        private int _performance;
        private int _persuasion;
        private int _religion;
        private int _sleightOfHand;
        private int _stealth;
        private int _survival;
        private char _size;
        private string _raceAbilityBonusses;
        private string _classPrimaryAbilities;
        private string _classSavingProficiencies;
        private string _classProficientSkills;
        private string _backgroundProficientSkills;

        public int Id { get => _id; set => _id = value; }

        public string Name { get => _name; set => _name = value; }

        public string Race { get => _race; set => _race = value; }

        public string Class { get => _class; set => _class = value; }

        public int Level { get => _level; set => _level = value; }

        public string Background { get => _background; set => _background = value; }

        public string Alignment { get => _alignment; set => _alignment = value; }

        public int ProficiencyBonus { get => _proficiencyBonus; set => _proficiencyBonus = value; }

        public int Speed { get => _speed; set => _speed = value; }

        public char Size { get => _size; set => _size = value; }

        public int Initiative { get => _initiative; set => _initiative = value; }

        public int PassiveWisdom { get => _passiveWisdom; set => _passiveWisdom = value; }

        public int MaxHitPoints { get => _maxHitPoints; set => _maxHitPoints = value; }

        public int HitDie { get => _hitDie; set => _hitDie = value; }

        #region abilities
        public int Strength { get => _strength; set => _strength = value; }
        public int StrengthModifier { get => _strengthModifier; set => _strengthModifier = value; }
        public int StrengthSave { get => _strengthSave; set => _strengthSave = value; }

        public int Dexterity { get => _dexterity; set => _dexterity = value; }
        public int DexterityModifier { get => _dexterityModifier; set => _dexterityModifier = value; }
        public int DexteritySave { get => _dexteritySave; set => _dexteritySave = value; }

        public int Constitution { get => _constitution; set => _constitution = value; }
        public int ConstitutionModifier { get => _constitutionModifier; set => _constitutionModifier = value; }
        public int ConstitutionSave { get => _constitutionSave; set => _constitutionSave = value; }

        public int Intelligence { get => _intelligence; set => _intelligence = value; }
        public int IntelligenceModifier { get => _intelligenceModifier; set => _intelligenceModifier = value; }
        public int IntelligenceSave { get => _intelligenceSave; set => _intelligenceSave = value; }

        public int Wisdom { get => _wisdom; set => _wisdom = value; }
        public int WisdomModifier { get => _wisdomModifier; set => _wisdomModifier = value; }
        public int WisdomSave { get => _wisdomSave; set => _wisdomSave = value; }

        public int Charisma { get => _charisma; set => _charisma = value; }
        public int CharismaModifier { get => _charismaModifier; set => _charismaModifier = value; }
        public int CharismaSave { get => _charismaSave; set => _charismaSave = value; }
        #endregion

        #region skills

        public int Acrobatics { get => _acrobatics; set => _acrobatics = value; }
        public int AnimalHandling { get => _animalHandling; set => _animalHandling = value; }
        public int Arcana { get => _arcana; set => _arcana = value; }
        public int Athletics { get => _athletics; set => _athletics = value; }
        public int Deception { get => _deception; set => _deception = value; }
        public int History { get => _history; set => _history = value; }
        public int Insight { get => _insight; set => _insight = value; }
        public int Intimidation { get => _intimidation; set => _intimidation = value; }
        public int Investigation { get => _investigation; set => _investigation = value; }
        public int Medicine { get => _medicine; set => _medicine = value; }
        public int Nature { get => _nature; set => _nature = value; }
        public int Perception { get => _perception; set => _perception = value; }
        public int Performance { get => _performance; set => _performance = value; }
        public int Persuasion { get => _persuasion; set => _persuasion = value; }
        public int Religion { get => _religion; set => _religion = value; }
        public int SleightOfHand { get => _sleightOfHand; set => _sleightOfHand = value; }
        public int Stealth { get => _stealth; set => _stealth = value; }
        public int Survival { get => _survival; set => _survival = value; }

        #endregion

        public string RaceAbilityBonusses { get => _raceAbilityBonusses; set => _raceAbilityBonusses = value; }

        public string ClassPrimaryAbilities { get => _classPrimaryAbilities; set => _classPrimaryAbilities = value; }

        public string ClassSavingProficiencies { get => _classSavingProficiencies; set => _classSavingProficiencies = value; }

        public string ClassProficientSkills { get => _classProficientSkills; set => _classProficientSkills = value; }

        public string BackgroundProficientSkills { get => _backgroundProficientSkills; set => _backgroundProficientSkills = value; }

        public CharacterSheet(Character character)
        {

            _id = Guid.NewGuid().GetHashCode();


            _name = character.Name;
            _race = character.Race.Name;

            _class = character.Class[0].Name;

            _level = character.Level;

            _background = character.Background.Name;

            _alignment = character.Alignment.ToString();

            _proficiencyBonus = character.ProficiencyBonus;

            _speed = character.Speed;

            _size = character.Size;

            _initiative = character.Initiative;

            _passiveWisdom = character.PassiveWisdom;

            _maxHitPoints = character.MaxHitPoint;

            _hitDie = character.HitDice[0];

            #region abilities

            _strength = character.Strength.Score;
            _strengthModifier = character.Strength.Modifier;
            _strengthSave = character.Strength.IsProficient ? character.Strength.Modifier + character.ProficiencyBonus : character.Strength.Modifier;

            _dexterity = character.Dexterity.Score;
            _dexterityModifier = character.Dexterity.Modifier;
            _dexteritySave = character.Dexterity.IsProficient ? character.Dexterity.Modifier + character.ProficiencyBonus : character.Dexterity.Modifier;

            _constitution = character.Constitution.Score;
            _constitutionModifier = character.Constitution.Modifier;
            _constitutionSave = character.Constitution.IsProficient ? character.Constitution.Modifier + character.ProficiencyBonus : character.Constitution.Modifier;

            _intelligence = character.Intelligence.Score;
            _intelligenceModifier = character.Intelligence.Modifier;
            _intelligenceSave = character.Intelligence.IsProficient ? character.Intelligence.Score + character.ProficiencyBonus : character.Intelligence.Modifier;

            _wisdom = character.Wisdom.Score;
            _wisdomModifier = character.Wisdom.Modifier;
            _wisdomSave = character.Wisdom.IsProficient ? character.Wisdom.Modifier + character.ProficiencyBonus : character.Wisdom.Modifier;

            _charisma = character.Charisma.Score;
            _charismaModifier = character.Charisma.Modifier;
            _charismaSave = character.Charisma.IsProficient ? character.Charisma.Modifier + character.ProficiencyBonus : character.Charisma.Modifier;

            #endregion

            #region skills

            _acrobatics = character.Acrobatics.IsProficient ? character.Acrobatics.Bonus + character.ProficiencyBonus : character.Acrobatics.Bonus;
            _animalHandling = character.AnimalHandling.IsProficient ? character.AnimalHandling.Bonus + character.ProficiencyBonus : character.AnimalHandling.Bonus;
            _arcana = character.Arcana.IsProficient ? character.Arcana.Bonus + character.ProficiencyBonus : character.Arcana.Bonus;
            _athletics = character.Athletics.IsProficient ? character.Athletics.Bonus + character.ProficiencyBonus : character.Athletics.Bonus;
            _deception = character.Deception.IsProficient ? character.Deception.Bonus + character.ProficiencyBonus : character.Deception.Bonus;
            _history = character.History.IsProficient ? character.History.Bonus + character.ProficiencyBonus : character.History.Bonus;
            _insight = character.Insight.IsProficient ? character.Insight.Bonus + character.ProficiencyBonus : character.Insight.Bonus;
            _intimidation = character.Intimidation.IsProficient ? character.Intimidation.Bonus + character.ProficiencyBonus : character.Intimidation.Bonus;
            _investigation = character.Investigation.IsProficient ? character.Investigation.Bonus + character.ProficiencyBonus : character.Investigation.Bonus;
            _medicine = character.Medicine.IsProficient ? character.Medicine.Bonus + character.ProficiencyBonus : character.Medicine.Bonus;
            _nature = character.Nature.IsProficient ? character.Nature.Bonus + character.ProficiencyBonus : character.Nature.Bonus;
            _perception = character.Perception.IsProficient ? character.Perception.Bonus + character.ProficiencyBonus : character.Perception.Bonus;
            _performance = character.Performance.IsProficient ? character.Performance.Bonus + character.ProficiencyBonus : character.Performance.Bonus;
            _persuasion = character.Persuasion.IsProficient ? character.Persuasion.Bonus + character.ProficiencyBonus : character.Persuasion.Bonus;
            _religion = character.Religion.IsProficient ? character.Religion.Bonus + character.ProficiencyBonus : character.Religion.Bonus;
            _sleightOfHand = character.SleightOfHand.IsProficient ? character.SleightOfHand.Bonus + character.ProficiencyBonus : character.SleightOfHand.Bonus;
            _stealth = character.Stealth.IsProficient ? character.Stealth.Bonus + character.ProficiencyBonus : character.Stealth.Bonus;
            _survival = character.Survival.IsProficient ? character.Survival.Bonus + character.ProficiencyBonus : character.Survival.Bonus;

            #endregion

            _raceAbilityBonusses = string.Join(",", character.Race.AbilityBonuses);

            _classPrimaryAbilities = string.Join(",", character.Class[0].PrimaryAbilities);

            _classSavingProficiencies = string.Join(",", character.Class[0].SavingProficiencies);

            _classProficientSkills = string.Join(",", character.Class[0].ProficientSkills);

            _backgroundProficientSkills = string.Join(",", character.Background.ProficientSkills);

        }

        public CharacterSheet()
        {
            _id = Guid.NewGuid().GetHashCode();
        }

    }
}





