using Microsoft.AspNetCore.Mvc;
using MvE.BLL.DTOs;
using MvE.BLL.DTOs.Enums;
using MvE.BLL.Managers;
using MvE.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvE.UI.Controllers
{
    public class HomeController : Controller
    {
        private SheetManager _sm;

        public HomeController() => _sm = new SheetManager();

        public IActionResult Index()
        {
            var charSheets = _sm.GetAll();
            return View(charSheets);
        }

        public IActionResult Details(int id)
        {
            CharacterSheetDTO cs = _sm.Get(id);
            if (cs == null) return NotFound();
            return View(cs);
        }

        public IActionResult Edit(int id)
        {
            CharacterSheetDTO cs = _sm.Get(id);
            if (cs == null) return NotFound();
            var viewModel = new CharacterFormViewModel(cs);
            return View("CharacterForm", viewModel);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult New()
        {
            var viewModel = new CharacterFormViewModel();
            return View("CharacterForm", viewModel);
        }



        [HttpPost]
        public ActionResult Save(CharacterFormViewModel VM)
        {
            CharacterSheetDTO cs = ViewModelToSheet(VM);
            if (!ModelState.IsValid)
            {
                var falultyViewModel = new CharacterFormViewModel(cs);
                return View("CharacterForm", falultyViewModel);
            }
            if (_sm.Get(VM.Id)==null)
            {
                _sm.Add(cs);
            }
            else
            {
                var sheet = _sm.Get(VM.Id);
                _sm.Update(sheet.Id, cs);
            }
            return RedirectToAction("Index", "Home");
        }



        public CharacterSheetDTO ViewModelToSheet(CharacterFormViewModel VM)
        {
            EAbilitiesDTO[] RaceAbilityBonuses = new EAbilitiesDTO[0];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < VM.RaceAbilityBonuses_SDCIWC[i]; j++)
                {
                    Array.Resize(ref RaceAbilityBonuses, RaceAbilityBonuses.Length + 1);
                    RaceAbilityBonuses[RaceAbilityBonuses.Length - 1] = (EAbilitiesDTO)i;
                }
            }
            RaceDTO Race = new RaceDTO(VM.RaceName, VM.RaceSpeed, RaceAbilityBonuses, VM.RaceSize);
            ClassDTO Class = new ClassDTO(VM.ClassName, VM.ClassHitDie, VM.ClassPrimaryAbilities, VM.ClassSavingProficiencies, VM.ClassProficientSkills);
            BackgroundDTO Background = new BackgroundDTO(VM.BackgroundName, VM.BackgroundProficientSkills);
            CharacterDTO Character = new CharacterDTO(VM.CharName, VM.BaseAbilityPoints_SDCIWC, Race, Class, VM.Alignment, Background);
            return new CharacterSheetDTO(Character);
        }
    }
}
