using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class ClassTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Class_Tests()
        {

            EAbilities[] primaryAbilities = new EAbilities[]{ EAbilities.Charisma};
            EAbilities[] savingProficiencies = new EAbilities[] { EAbilities.Charisma, EAbilities.Dexterity};
            ESkills[] classProficency = new ESkills[] { ESkills.Deception, ESkills.Persuasion, ESkills.Performance };

            Class bard = new Class("Bard",8,primaryAbilities,savingProficiencies, classProficency);


            Assert.That(bard.Id, Is.InstanceOf<int>());
            Assert.AreEqual(bard.Name, "Bard");
            Assert.AreSame(bard.PrimaryAbilities, primaryAbilities);
            Assert.AreSame(bard.SavingProficiencies,savingProficiencies);
            Assert.AreSame(bard.ProficientSkills, classProficency);
            Assert.That(bard.HitDie, Is.InstanceOf<int>());



        }
    }
}
