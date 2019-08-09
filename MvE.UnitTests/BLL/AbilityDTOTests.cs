using MvE.BLL.DTOs;
using MvE.DAL.Models;
using NUnit.Framework;
using System;

namespace MvE.UnitTests.DAL
{
    public class AbilityDTOTests
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void Ability_Tests()
        {
            AbilityDTO ability = new AbilityDTO(16, false);
            Assert.AreEqual(ability.Modifier, 3);
            Assert.AreEqual(ability.Score, 16);
            Assert.That(ability.Id, Is.InstanceOf<int>());
            Assert.IsFalse(ability.IsProficient);
        }
       
    }
}