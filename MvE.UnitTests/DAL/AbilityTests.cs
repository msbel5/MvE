using MvE.DAL.Models;
using NUnit.Framework;
using System;

namespace MvE.UnitTests.DAL
{
    public class AbilityTests
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void Ability_Tests()
        {
            Ability ability = new Ability(16, false);
            Assert.AreEqual(ability.Modifier, 3);
            Assert.AreEqual(ability.Score, 16);
            Assert.That(ability.Id, Is.InstanceOf<int>());
        }
       
    }
}