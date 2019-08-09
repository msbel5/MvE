using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.UnitTests.DAL
{
    public class BackgroundTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Background_Tests()
        {

            Background background = new Background("soldier", new ESkills[] { ESkills.Survival });
            Assert.That(background.Id, Is.InstanceOf<int>());
            Assert.AreSame(background.Name, "soldier");
            Assert.AreEqual(background.ProficientSkills, new int[] { 13 });

        }
    }

}
