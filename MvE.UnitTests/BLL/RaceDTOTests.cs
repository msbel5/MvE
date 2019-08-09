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
    public class RaceDTOTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Race_Tests()
        {
            EAbilitiesDTO[] abilities = new EAbilitiesDTO[] { EAbilitiesDTO.Strength, EAbilitiesDTO.Dexterity, EAbilitiesDTO.Constitution, EAbilitiesDTO.Intelligence, EAbilitiesDTO.Wisdom, EAbilitiesDTO.Charisma, EAbilitiesDTO.Intelligence };
            RaceDTO race = new RaceDTO("Human", 30, abilities, 'm');

            Assert.AreEqual(race.Name, "Human");
            Assert.AreEqual(race.Speed, 30);
            Assert.AreEqual(race.Size, 'm');
            Assert.AreEqual(race.AbilityBonuses.Length, Array.ConvertAll( abilities, val => (int)val).Length);
            Assert.That(race.Id, Is.InstanceOf<int>());

        }
    }
}
