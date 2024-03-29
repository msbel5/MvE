﻿using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class RaceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Race_Tests()
        {
            EAbilities[] abilities = new EAbilities[] { EAbilities.Strength, EAbilities.Dexterity, EAbilities.Constitution, EAbilities.Intelligence, EAbilities.Wisdom, EAbilities.Charisma, EAbilities.Intelligence };
            Race race = new Race("Human", 30, abilities, 'm');

            Assert.AreEqual(race.Name, "Human");
            Assert.AreEqual(race.Speed, 30);
            Assert.AreEqual(race.Size, 'm');
            Assert.AreEqual(race.AbilityBonuses.Length, Array.ConvertAll( abilities, val => (int)val).Length);
            Assert.That(race.Id, Is.InstanceOf<int>());

        }
    }
}
