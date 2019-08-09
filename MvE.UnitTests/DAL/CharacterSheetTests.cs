using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class CharacterSheetTests
    {
        private Character _char;
        private Race _race;
        private EAbilities[] _abilities;
        private int[] _abilityArray;
        private ESkills[] _skills;
        private Class _class;
        private Background _background;
        private EAlignment _alignment;
        private CharacterSheet _charSheet;

        [SetUp]
        public void Setup()
        {
            _abilityArray = new int[] { 10, 10, 10, 10, 10, 10 };
            _abilities = new EAbilities[] { EAbilities.Wisdom };
            _skills = new ESkills[] { ESkills.Athletics };
            _background = new Background("Background", _skills);
            _race = new Race("Race", 15, _abilities, 'm');
            _class = new Class("Class", 8, _abilities, _abilities, _skills);
            _alignment = EAlignment.trueNeutral;
            _char = new Character("Char", _abilityArray, _race, _class, _alignment, _background);
            _charSheet = new CharacterSheet(_char);
            CharacterSheet EmptyCharSheet = new CharacterSheet();
        }
        [Test]
        public void CharacterSheet_Tests()
        {
            Assert.That(_charSheet.Id, Is.InstanceOf<int>());
            Assert.AreEqual("Char", _char.Name);
            Assert.AreEqual(_charSheet.Race, "Race");
            Assert.AreEqual(_charSheet.Class, "Class");
            Assert.AreEqual(_charSheet.Background, "Background");
          
            Assert.AreEqual(_charSheet.PassiveWisdom, 12);
            Assert.AreEqual(_charSheet.Size, 'm');
            Assert.AreEqual(_charSheet.MaxHitPoints, 8);
            Assert.AreEqual(_charSheet.Name,"Char");
            Assert.AreEqual(_charSheet.Level,1);
            Assert.AreEqual(_charSheet.Alignment,EAlignment.trueNeutral.ToString());
            Assert.AreEqual(_charSheet.ProficiencyBonus,2);
            Assert.AreEqual(_charSheet.Initiative,0);
            Assert.AreEqual(_charSheet.Speed,15);
            Assert.AreEqual(_charSheet.HitDie,8);

            #region Abilities

            Assert.AreEqual(_abilityArray, new int[] { _charSheet.Strength, _charSheet.Dexterity, _charSheet.Constitution, _charSheet.Intelligence, _charSheet.Wisdom - 1 /*substrack class bonus from wis*/, _charSheet.Charisma });

            Assert.AreEqual(_charSheet.StrengthModifier,0);
            Assert.AreEqual(_charSheet.DexterityModifier, 0);
            Assert.AreEqual(_charSheet.ConstitutionModifier, 0);
            Assert.AreEqual(_charSheet.IntelligenceModifier, 0);
            Assert.AreEqual(_charSheet.WisdomModifier, 0);
            Assert.AreEqual(_charSheet.CharismaModifier, 0);
            Assert.AreEqual(_charSheet.StrengthSave, 0);
            Assert.AreEqual(_charSheet.DexteritySave, 0);
            Assert.AreEqual(_charSheet.ConstitutionSave, 0);
            Assert.AreEqual(_charSheet.IntelligenceSave, 0);
            Assert.AreEqual(_charSheet.WisdomSave, 2);
            Assert.AreEqual(_charSheet.CharismaSave, 0);

            #endregion

            #region Skills
            Assert.AreEqual(_charSheet.Acrobatics, 0);
            Assert.AreEqual(_charSheet.AnimalHandling, 0);
            Assert.AreEqual(_charSheet.Arcana, 0);
            Assert.AreEqual(_charSheet.Athletics, 2);
            Assert.AreEqual(_charSheet.Deception, 0);
            Assert.AreEqual(_charSheet.History, 0);
            Assert.AreEqual(_charSheet.Insight, 0);
            Assert.AreEqual(_charSheet.Intimidation, 0);
            Assert.AreEqual(_charSheet.Investigation, 0);
            Assert.AreEqual(_charSheet.Medicine, 0);
            Assert.AreEqual(_charSheet.Nature, 0);
            Assert.AreEqual(_charSheet.Perception, 0);
            Assert.AreEqual(_charSheet.Performance, 0);
            Assert.AreEqual(_charSheet.Persuasion, 0);
            Assert.AreEqual(_charSheet.Religion, 0);
            Assert.AreEqual(_charSheet.SleightOfHand, 0);
            Assert.AreEqual(_charSheet.Stealth, 0);
            Assert.AreEqual(_charSheet.Survival, 0);
            #endregion

        }
    }
}
