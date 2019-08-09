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
    public class CharacterDTOTests
    {
        private CharacterDTO _char;
        private RaceDTO _race;
        private EAbilitiesDTO[] _abilities;
        private int[] _abilityArray;
        private ESkillsDTO[] _skills;
        private ClassDTO _class;
        private BackgroundDTO _background;
        private EAlignmentDTO _alignment;


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
        }
        [Test]
        public void Character_Tests()
        {
            Assert.That(_char.Id, Is.InstanceOf<int>());
            Assert.AreEqual("Char", _char.Name);
            Assert.AreEqual(_char.Race, _race);
            Assert.AreEqual(_char.Class[0], _class);
            Assert.AreEqual(_char.Background, _background);
            Assert.AreEqual(_abilityArray, new int[] { _char.Strength.Score, _char.Dexterity.Score, _char.Constitution.Score, _char.Intelligence.Score, _char.Wisdom.Score - 1 /*substrack class bonus from wis*/, _char.Charisma.Score });
            Assert.AreEqual(_char.PassiveWisdom, 12);
            Assert.AreEqual(_char.Size,'m');
            Assert.AreEqual(_char.HitPoint, 8);
            _char.GainExp(310);
            Assert.AreEqual(_char.Experience, 310);
            _char.Heal(-8);
            Assert.AreEqual(_char.HitPoint,0);
            _char.Heal(8);
            Assert.AreEqual(_char.HitPoint,8);
            _char.Stabilize(true);
            _char.LevelUp(_class);
            Assert.AreEqual(_char.Class[1], _class);
            Assert.AreEqual(_char.Level,2);

        }
    }
}
