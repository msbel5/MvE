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
    public class BackgroundDTOTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Background_Tests()
        {

            BackgroundDTO background = new BackgroundDTO("soldier", new ESkillsDTO[] { ESkillsDTO.Survival });
            Assert.That(background.Id, Is.InstanceOf<int>());
            Assert.AreSame(background.Name, "soldier");
            Assert.AreEqual(background.ProficientSkills, new int[] { 13 });

        }
    }

}
