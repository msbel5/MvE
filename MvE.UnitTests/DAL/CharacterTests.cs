using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class CharacterTests
    {
        private Character _char;
        private Race _race;
        private EAbilities[] _abilities;
        private int[] _abilityArray;
        private ESkills[] _skills;
        private Class _class;
        private Background _background;
        private EAlignment _alignment;


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
