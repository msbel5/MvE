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
    public class ClassDTOTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Class_Tests()
        {

            EAbilitiesDTO[] primaryAbilities = new EAbilitiesDTO[]{ EAbilitiesDTO.Charisma};
            EAbilitiesDTO[] savingProficiencies = new EAbilitiesDTO[] { EAbilitiesDTO.Charisma, EAbilitiesDTO.Dexterity};
            ESkillsDTO[] classProficency = new ESkillsDTO[] { ESkillsDTO.Deception, ESkillsDTO.Persuasion, ESkillsDTO.Performance };

            ClassDTO bard = new ClassDTO("Bard",8,primaryAbilities,savingProficiencies, classProficency);


            Assert.That(bard.Id, Is.InstanceOf<int>());
            Assert.AreEqual(bard.Name, "Bard");
            Assert.AreEqual(bard.PrimaryAbilities, Array.ConvertAll(primaryAbilities, value => (int)value));
            Assert.AreEqual(bard.SavingProficiencies, Array.ConvertAll(savingProficiencies, value => (int)value));
            Assert.AreEqual(bard.ProficientSkills, Array.ConvertAll(classProficency, value => (int)value));
            Assert.AreEqual(bard.HitDie, 8);
            



        }
    }
}
