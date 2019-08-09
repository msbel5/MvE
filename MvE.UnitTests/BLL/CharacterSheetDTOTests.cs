using MvE.BLL.DTOs;
using MvE.BLL.DTOs.Enums;
using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class CharacterSheetDTOTests
    {
        private CharacterDTO _char;
        private RaceDTO _race;
        private EAbilitiesDTO[] _abilities;
        private int[] _abilityArray;
        private ESkillsDTO[] _skills;
        private ClassDTO _class;
        private BackgroundDTO _background;
        private EAlignmentDTO _alignment;
        private CharacterSheetDTO _charSheet;

        [SetUp]
        public void Setup()
        {
            _abilityArray = new int[] { 10, 10, 10, 10, 10, 10 };
            _abilities = new EAbilitiesDTO[] { EAbilitiesDTO.Wisdom };
            _skills = new ESkillsDTO[] { ESkillsDTO.Athletics };
            _background = new BackgroundDTO("Background", _skills);
            _race = new RaceDTO("Race", 15, _abilities, 'm');
            _class = new ClassDTO("Class", 8, _abilities, _abilities, _skills);
            _alignment = EAlignmentDTO.trueNeutral;
            _char = new CharacterDTO("Char", _abilityArray, _race, _class, _alignment, _background);
            _charSheet = new CharacterSheetDTO(_char);
            CharacterSheetDTO EmptyCharSheet = new CharacterSheetDTO();
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
