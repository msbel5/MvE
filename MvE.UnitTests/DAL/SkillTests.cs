using MvE.DAL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class SkillTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Skill_Tests()
        {
            Ability dexterity = new Ability(14,false);
            Skill skill = new Skill(dexterity,true);
            Assert.IsTrue(skill.IsProficient);
            Assert.AreEqual(skill.Bonus,2);
            Assert.AreSame(skill.AssociatedAbility, dexterity);
            Assert.That(skill.Id, Is.InstanceOf<int>());
        }
    }
}
