using AutoMapper;
using ConsoleTables;
using MvE.BLL.DTOs;
using MvE.BLL.Managers;
using MvE.DAL.Data;
using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using MvE.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MvE.Tester
{
    class Tester
    {
        static void Main(string[] args)
        {
            SheetRepository SheetRepo = new SheetRepository();

            SheetManager SheetMg = new SheetManager();

            List<CharacterSheetDTO> SheetList = SheetMg.GetAll().ToList();

            CharacterSheetDTO sheetDTO = SheetList.First();

            Console.WriteLine(sheetDTO.Name);

            CharacterSheet sheetMapped = SheetMg.DTOtoModel(sheetDTO);

            Console.WriteLine(sheetMapped.Name);

            Console.WriteLine("Do you want to create a new character?");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (input == 'y')
            {
                Console.WriteLine();
                SheetCreator();
            }


            if (SheetRepo.GetAll().Count() == 0) { Console.WriteLine("No character have been found!"); }

            foreach (CharacterSheet sheet in SheetRepo.GetAll())
            {
                Console.WriteLine();
                PrintSheet(sheet);
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        #region Methods

        public static void SheetCreator()
        {
            #region Personal Details
            Console.WriteLine("1. Choose your personal details");
            Console.WriteLine("What is your character's name?");
            string customCharName = Console.ReadLine();
            int[] customAbilityPoints = AbilityPointsCreator_SDCIWC();
            EAlignment customAlignment = AlignmentChooser();
            #endregion

            #region race
            Console.WriteLine("2. Create your race");
            Console.WriteLine("Name of the race?");
            string raceName = Console.ReadLine();
            Console.WriteLine("Speed of the race?");
            int raceSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Size of the race?");
            char raceSize = (char)Console.Read();
            Console.WriteLine("Select ability bonuses, every selection provides +1 to selected ability.");
            EAbilities[] selectedAbilities = AbilitiesArrayCreator();
            Race customRace = new Race(raceName, raceSpeed, selectedAbilities, raceSize);
            #endregion

            #region class
            Console.WriteLine("3. Create your class");
            Console.WriteLine("Name of the class?");
            string className = Console.ReadLine();
            Console.WriteLine("What is you hit die?");
            int customHitDie = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your primary abilities.");
            EAbilities[] customPrimaryAbilities = AbilitiesArrayCreator();
            Console.WriteLine("Choose saving throw proficiencies for your class.");
            EAbilities[] customSaves = AbilitiesArrayCreator();
            Console.WriteLine("Choose skill poficiencies for your class.");
            ESkills[] customProficiency = ESkillsArrayCreator();
            Class customClass = new Class(className, customHitDie, customPrimaryAbilities, customSaves, customProficiency);
            #endregion

            #region background
            Console.WriteLine("4. Create your background");
            Console.WriteLine("Name of the background?");
            string backgroundName = Console.ReadLine();
            Console.WriteLine("Choose skill poficiencies for your background.");
            ESkills[] customBackgroundProficiency = ESkillsArrayCreator();
            Background customBackground = new Background(backgroundName, customBackgroundProficiency);
            #endregion

            CharacterSheet customCharSheet = new CharacterSheet(new Character(customCharName, customAbilityPoints, customRace, customClass, customAlignment, customBackground));

            SheetRepository sheetRepository = new SheetRepository();
            var count = sheetRepository.Add(customCharSheet);
            Console.WriteLine("{0} character sheet/s have been modified.", count);

        }

        public static void PrintSheet(CharacterSheet sheet)
        {
            var table = new ConsoleTable("name", "value", "value2", "value3");
            table.AddRow("Id", "───────────────", "──────────────>", sheet.Id)
                .AddRow("CharName", "───────────────", "──────────────>", sheet.Name)
                .AddRow("Race", "───────────────", "──────────────>", sheet.Race)
                .AddRow("Class", "───────────────", "──────────────>", sheet.Class)
                .AddRow("Background", "───────────────", "──────────────>", sheet.Background)
                .AddRow("Alignment", "───────────────", "──────────────>", sheet.Alignment)
                .AddRow("Level", "───────────────", "──────────────>", sheet.Level)
                .AddRow("Initiative", "───────────────", "──────────────>", sheet.Initiative)
                .AddRow("Speed", "───────────────", "──────────────>", sheet.Speed)
                .AddRow("Proficiency Bonus", "───────────────", "──────────────>", sheet.ProficiencyBonus)
                .AddRow("Max Hit Points", "───────────────", "──────────────>", sheet.MaxHitPoints)
                .AddRow("Hit Die", "───────────────", "──────────────>", sheet.HitDie)
                .AddRow("Passive Wisdom", "───────────────", "──────────────>", sheet.PassiveWisdom)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Str", sheet.Strength, sheet.StrengthModifier, sheet.StrengthSave)
                .AddRow("└──────────────", "Athletics", "──────────────>", sheet.Athletics)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Dex", sheet.Dexterity, sheet.DexterityModifier, sheet.DexteritySave)
                .AddRow("├──────────────", "Acrobatics", "──────────────>", sheet.Acrobatics)
                .AddRow("├──────────────", "Sleight Of Hand", "──────────────>", sheet.SleightOfHand)
                .AddRow("└──────────────", "Stealth", "──────────────>", sheet.Stealth)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Con", sheet.Constitution, sheet.ConstitutionModifier, sheet.ConstitutionSave)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Int", sheet.Intelligence, sheet.IntelligenceModifier, sheet.IntelligenceSave)
                .AddRow("├──────────────", "Arcana", "──────────────>", sheet.Arcana)
                .AddRow("├──────────────", "History", "──────────────>", sheet.History)
                .AddRow("├──────────────", "Investigation", "──────────────>", sheet.Investigation)
                .AddRow("├──────────────", "Nature", "──────────────>", sheet.Nature)
                .AddRow("└──────────────", "Religion", "──────────────>", sheet.Religion)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Wis", sheet.Wisdom, sheet.WisdomModifier, sheet.WisdomSave)
                .AddRow("├──────────────", "Animal Handling", "──────────────>", sheet.AnimalHandling)
                .AddRow("├──────────────", "Insight", "──────────────>", sheet.Insight)
                .AddRow("├──────────────", "Medicine", "──────────────>", sheet.Medicine)
                .AddRow("├──────────────", "Perception", "──────────────>", sheet.Perception)
                .AddRow("└──────────────", "Survival", "──────────────>", sheet.Survival)
                .AddRow("---------------", "---------------", "---------------", "---------------")
                .AddRow("Cha", sheet.Charisma, sheet.CharismaModifier, sheet.CharismaSave)
                .AddRow("├──────────────", "Deception", "──────────────>", sheet.Deception)
                .AddRow("├──────────────", "Intimidation", "──────────────>", sheet.Intimidation)
                .AddRow("├──────────────", "Performance", "──────────────>", sheet.Performance)
                .AddRow("└──────────────", "Persuasion", "──────────────>", sheet.Persuasion);


            table.Configure(t => t.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
            Console.WriteLine(); Console.WriteLine("Press any key to show next sheet..."); Console.WriteLine(); Console.ReadKey(true);

        }

        public static EAbilities[] AbilitiesArrayCreator()
        {
            bool isDone = false;
            EAbilities[] selectedAbilities = new EAbilities[0];

            Console.WriteLine("Choose ability type to add.");
            Console.WriteLine("1) Strength");
            Console.WriteLine("2) Dexterity");
            Console.WriteLine("3) Constitution");
            Console.WriteLine("4) Intelligence");
            Console.WriteLine("5) Wisdom");
            Console.WriteLine("6) Charisma");
            Console.WriteLine("7) Done.");

            while (!isDone)
            {
                FlushKeyboard();
                var input = Console.ReadLine();
                int selection = Convert.ToInt32(input);
                switch (selection)
                {
                    case 1:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Strength;
                        Console.WriteLine("Strength added!");
                        break;
                    case 2:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Dexterity;
                        Console.WriteLine("Dexterity added!");
                        break;
                    case 3:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Constitution;
                        Console.WriteLine("Constitution added!");
                        break;
                    case 4:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Intelligence;
                        Console.WriteLine("Intelligence added!");
                        break;
                    case 5:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Wisdom;
                        Console.WriteLine("Wisdom added!");
                        break;
                    case 6:
                        Array.Resize(ref selectedAbilities, selectedAbilities.Length + 1);
                        selectedAbilities[selectedAbilities.Length - 1] = EAbilities.Charisma;
                        Console.WriteLine("Charisma added!");
                        break;
                    case 7:
                        isDone = true;
                        break;
                    default:
                        break;
                }
            }
            return selectedAbilities;
        }

        public static ESkills[] ESkillsArrayCreator()
        {
            bool isDone = false;
            ESkills[] selectedSkills = new ESkills[0];

            Console.WriteLine("Choose skills type to add.");
            Console.WriteLine("1) Athletics");
            Console.WriteLine("2) Acrobatics");
            Console.WriteLine("3) Sleight Of Hand");
            Console.WriteLine("4) Stealth");
            Console.WriteLine("5) Arcana");
            Console.WriteLine("6) History");
            Console.WriteLine("7) Investigation");
            Console.WriteLine("8) Nature");
            Console.WriteLine("9) Religion");
            Console.WriteLine("10) Animal Handling");
            Console.WriteLine("11) Insight");
            Console.WriteLine("12) Medicine");
            Console.WriteLine("13) Perception");
            Console.WriteLine("14) Survival");
            Console.WriteLine("15) Deception");
            Console.WriteLine("16) Intimidation");
            Console.WriteLine("17) Performance");
            Console.WriteLine("18) Persuasion");
            Console.WriteLine("19) Done.");

            while (!isDone)
            {
                FlushKeyboard();
                var input = Console.ReadLine();
                int selection = Convert.ToInt32(input);
                switch (selection)
                {
                    case 1:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Athletics;
                        Console.WriteLine("Athletics added!");
                        break;
                    case 2:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Acrobatics;
                        Console.WriteLine("Acrobatics added!");
                        break;
                    case 3:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.sleightOfHand;
                        Console.WriteLine("Sleight Of Hand added!");
                        break;
                    case 4:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Stealth;
                        Console.WriteLine("Stealth added!");
                        break;
                    case 5:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Arcana;
                        Console.WriteLine("Arcana added!");
                        break;
                    case 6:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.History;
                        Console.WriteLine("History added!");
                        break;
                    case 7:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Investigation;
                        Console.WriteLine("Investigation added!");
                        break;
                    case 8:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Nature;
                        Console.WriteLine("Nature added!");
                        break;
                    case 9:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Religion;
                        Console.WriteLine("Religion added!");
                        break;
                    case 10:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.animalHandling;
                        Console.WriteLine("Animal Handling added!");
                        break;
                    case 11:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Insight;
                        Console.WriteLine("Insight added!");
                        break;
                    case 12:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Medicine;
                        Console.WriteLine("Medicine added!");
                        break;
                    case 13:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Perception;
                        Console.WriteLine("Perception added!");
                        break;
                    case 14:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Survival;
                        Console.WriteLine("Survival added!");
                        break;
                    case 15:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Deception;
                        Console.WriteLine("Deception added!");
                        break;
                    case 16:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Intimidation;
                        Console.WriteLine("Intimidation added!");
                        break;
                    case 17:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Performance;
                        Console.WriteLine("Performance added!");
                        break;
                    case 18:
                        Array.Resize(ref selectedSkills, selectedSkills.Length + 1);
                        selectedSkills[selectedSkills.Length - 1] = ESkills.Persuasion;
                        Console.WriteLine("Persuasion added!");
                        break;
                    case 19:
                        isDone = true;
                        break;
                    default:
                        break;
                }

            }
            return selectedSkills;
        }

        public static int[] AbilityPointsCreator_SDCIWC()
        {
            int[] abilityPoints_SDCIWC = new int[6];
            Console.WriteLine("What is your Strength score");
            abilityPoints_SDCIWC[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your Dexterity score");
            abilityPoints_SDCIWC[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your Constitution score");
            abilityPoints_SDCIWC[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your Intelligence score");
            abilityPoints_SDCIWC[3] = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your Wisdom score");
            abilityPoints_SDCIWC[4] = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your Charisma score");
            abilityPoints_SDCIWC[5] = int.Parse(Console.ReadLine());

            return abilityPoints_SDCIWC;
        }

        public static EAlignment AlignmentChooser()
        {
            Console.WriteLine("What is your alignmet?");
            Console.WriteLine("1) Lawful Good");
            Console.WriteLine("2) Neutral Good");
            Console.WriteLine("3) Chaoti cGood");
            Console.WriteLine("4) Lawful Neutral");
            Console.WriteLine("5) True Neutral");
            Console.WriteLine("6) Chaotic Neutral");
            Console.WriteLine("7) Lawful Evil");
            Console.WriteLine("8) Neutral Evil");
            Console.WriteLine("9) Chaotic Evil");
            FlushKeyboard();
            var input = Console.ReadLine();
            int selection = Convert.ToInt32(input);

            switch (selection)
            {
                case 1:
                    return EAlignment.lawfulGood;
                case 2:
                    return EAlignment.neutralGood;
                case 3:
                    return EAlignment.chaoticGood;
                case 4:
                    return EAlignment.lawfulNeutral;
                case 5:
                    return EAlignment.trueNeutral;
                case 6:
                    return EAlignment.chaoticNeutral;
                case 7:
                    return EAlignment.lawfulEvil;
                case 8:
                    return EAlignment.neutralEvil;
                case 9:
                    return EAlignment.chaoticEvil;
                default:
                    return EAlignment.trueNeutral;
            }
        }

        private static void FlushKeyboard()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }

        #endregion

    }
}
