using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvE.DAL.Models
{
    public class CharacterSheet
    {
        private Character _character;
        private int _id;

        
        public int Id { get { return _id; } }
                
        public string Name { get {return _character.Name; } }

        public string Race { get {return _character.Race.Name; } }

        public string Class { get {return _character.Class[0].Name; } }

        public int Level { get {return _character.Level; } }

        public string Background { get {return _character.Background.Name; } }

        public string Alignment { get {return _character.Alignment.ToString(); } }

        public int ProficiencyBonus { get {return _character.ProficiencyBonus; } }

        public int Speed { get {return _character.Speed; } }

        public int Initiative { get {return _character.Initiative; } }

        #region abilities
        public int Strength { get {return _character.Strength.Score; } }
        public int StrengthModifier { get {return _character.Strength.Modifier; } }
        public int StrengthSave { get { return _character.Strength.IsProficient ? _character.Strength.Modifier + _character.ProficiencyBonus : _character.Strength.Modifier; } }

        public int Dexterity { get {return _character.Dexterity.Score; } }
        public int DexterityModifier { get {return _character.Dexterity.Modifier; } }
        public int DexteritySave { get { return _character.Dexterity.IsProficient ? _character.Dexterity.Modifier + _character.ProficiencyBonus : _character.Dexterity.Modifier; } }

        public int Constitution { get {return _character.Constitution.Score; } }
        public int ConstitutionModifier { get {return _character.Constitution.Modifier; } }
        public int ConstitutionSave { get { return _character.Constitution.IsProficient ? _character.Constitution.Modifier + _character.ProficiencyBonus : _character.Constitution.Modifier; } }

        public int Intelligence { get {return _character.Intelligence.Score; } }
        public int IntelligenceModifier { get {return _character.Intelligence.Modifier; } }
        public int IntelligenceSave { get { return _character.Intelligence.IsProficient ? _character.Intelligence.Score + _character.ProficiencyBonus : _character.Intelligence.Modifier; } }

        public int Wisdom { get {return _character.Wisdom.Score; } }
        public int WisdomModifier { get {return _character.Wisdom.Modifier; } }
        public int WisdomSave { get { return _character.Wisdom.IsProficient ? _character.Wisdom.Modifier + _character.ProficiencyBonus : _character.Wisdom.Modifier; } }

        public int Charisma { get {return _character.Charisma.Score; } }
        public int CharismaModifier { get {return _character.Charisma.Modifier; } }
        public int CharismaSave { get { return _character.Charisma.IsProficient ? _character.Charisma.Modifier + _character.ProficiencyBonus : _character.Charisma.Modifier; } }
        #endregion

        #region skills

        public int Acrobatics { get {return _character.Acrobatics.IsProficient ? _character.Acrobatics.Bonus + _character.ProficiencyBonus : _character.Acrobatics.Bonus; } }
        public int AnimalHandling { get {return _character.AnimalHandling.IsProficient ? _character.AnimalHandling.Bonus + _character.ProficiencyBonus : _character.AnimalHandling.Bonus; } }
        public int Arcana { get {return _character.Arcana.IsProficient ? _character.Arcana.Bonus + _character.ProficiencyBonus : _character.Arcana.Bonus; } }
        public int Athletics { get {return _character.Athletics.IsProficient ? _character.Athletics.Bonus + _character.ProficiencyBonus : _character.Athletics.Bonus; } }
        public int Deception { get {return _character.Deception.IsProficient ? _character.Deception.Bonus + _character.ProficiencyBonus : _character.Deception.Bonus; } }
        public int History { get {return _character.History.IsProficient ? _character.History.Bonus + _character.ProficiencyBonus : _character.History.Bonus; } }
        public int Insight { get {return _character.Insight.IsProficient ? _character.Insight.Bonus + _character.ProficiencyBonus : _character.Insight.Bonus; } }
        public int Intimidation { get {return _character.Intimidation.IsProficient ? _character.Intimidation.Bonus + _character.ProficiencyBonus : _character.Intimidation.Bonus; } }
        public int Investigation { get {return _character.Investigation.IsProficient ? _character.Investigation.Bonus + _character.ProficiencyBonus : _character.Investigation.Bonus; } }
        public int Medicine { get {return _character.Medicine.IsProficient ? _character.Medicine.Bonus + _character.ProficiencyBonus : _character.Medicine.Bonus; } }
        public int Nature { get {return _character.Nature.IsProficient ? _character.Nature.Bonus + _character.ProficiencyBonus : _character.Nature.Bonus; } }
        public int Perception { get {return _character.Perception.IsProficient ? _character.Perception.Bonus + _character.ProficiencyBonus : _character.Perception.Bonus; } }
        public int Performance { get {return _character.Performance.IsProficient ? _character.Performance.Bonus + _character.ProficiencyBonus : _character.Performance.Bonus; } }
        public int Persuasion { get {return _character.Persuasion.IsProficient ? _character.Persuasion.Bonus + _character.ProficiencyBonus : _character.Persuasion.Bonus; } }
        public int Religion { get {return _character.Religion.IsProficient ? _character.Religion.Bonus + _character.ProficiencyBonus : _character.Religion.Bonus; } }
        public int SleightOfHand { get {return _character.SleightOfHand.IsProficient ? _character.SleightOfHand.Bonus + _character.ProficiencyBonus : _character.SleightOfHand.Bonus; } }
        public int Stealth { get {return _character.Stealth.IsProficient ? _character.Stealth.Bonus + _character.ProficiencyBonus : _character.Stealth.Bonus; } }
        public int Survival { get {return _character.Survival.IsProficient ? _character.Survival.Bonus + _character.ProficiencyBonus : _character.Survival.Bonus; } }

        #endregion

        public int PassiveWisdom { get {return _character.PassiveWisdom; } }

        public int MaxHitPoints { get {return _character.MaxHitPoint; } }

        public int HitDie { get {return _character.HitDice[0]; } }

        public CharacterSheet(Character character)
        {
            _character = character;
            _id = Guid.NewGuid().GetHashCode();
        }

        public CharacterSheet()
        {
            _id = Guid.NewGuid().GetHashCode();
        }
    }
}
