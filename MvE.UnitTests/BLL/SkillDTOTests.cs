using MvE.BLL.DTOs;
using MvE.DAL.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class SkillDTOTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Skill_Tests()
        {
            AbilityDTO dexterity = new AbilityDTO(14,false);
            SkillDTO skill = new SkillDTO(dexterity,true);
            Assert.IsTrue(skill.IsProficient);
            Assert.AreEqual(skill.Bonus,2);
            Assert.AreSame(skill.AssociatedAbility, dexterity);
            Assert.That(skill.Id, Is.InstanceOf<int>());
        }
    }
}
