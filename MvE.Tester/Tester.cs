using ConsoleTables;
using MvE.DAL.Data;
using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using System;
using System.IO;
using System.Reflection;

namespace MvE.Tester
{
    class Tester
    {
        static void Main(string[] args)
        {
            EAbilities[] abilities = new EAbilities[]
                { EAbilities.Strength, EAbilities.Dexterity, EAbilities.Constitution, EAbilities.Intelligence, EAbilities.Wisdom, EAbilities.Charisma, EAbilities.Intelligence };
            Race human = new Race("Human", 30, abilities, 'm');
            EAbilities[] primaryAbilities = new EAbilities[] { EAbilities.Charisma };
            EAbilities[] saves = new EAbilities[] { EAbilities.Dexterity, EAbilities.Charisma };
            ESkills[] classProficency = new ESkills[] { ESkills.Deception, ESkills.Persuasion, ESkills.Performance };
            Class bard = new Class("Bard", 8, primaryAbilities, saves, classProficency);
            Background sage = new Background("Sage", new ESkills[] { ESkills.Arcana, ESkills.History });
            int[] abilityPoints_SDCIWC = new int[6] { 14, 14, 10, 17, 15, 16 };
            Character MarvinTheHumanBard = new Character("Marvin", abilityPoints_SDCIWC, human, bard, EAlignment.neutralGood, sage);
            CharacterSheet marvin = new CharacterSheet(MarvinTheHumanBard);

            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MvE\MvE.db");

            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MvE\MvE.db");

            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"\MvE.db");

            string startupPath2 = Path.Combine(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName, @"\MvE.db");

            string path2 = System.IO.Path.GetDirectoryName(Directory.GetParent(Assembly.GetExecutingAssembly().CodeBase).Parent.Parent.Parent.Parent.ToString());

            string path3 = System.IO.Path.GetDirectoryName(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.Parent.ToString());

            Console.WriteLine(path3);
            Console.ReadKey(true);
            
            //table
            var table = new ConsoleTable("name", "value", "value2", "value3");
            table.AddRow("Id", "───────────────", "──────────────>", marvin.Id)
                .AddRow("CharName", "───────────────", "──────────────>", marvin.Name)
                .AddRow("Race", "───────────────", "──────────────>", marvin.Race)
                .AddRow("Class", "───────────────", "──────────────>", marvin.Class)
                .AddRow("Background", "───────────────", "──────────────>", marvin.Background)
                .AddRow("Alignment", "───────────────", "──────────────>", marvin.Alignment)
                .AddRow("Level", "───────────────", "──────────────>", marvin.Level)
                .AddRow("Initiative", "───────────────", "──────────────>", marvin.Initiative)
                .AddRow("Speed", "───────────────", "──────────────>", marvin.Speed)
                .AddRow("Proficiency Bonus", "───────────────", "──────────────>", marvin.ProficiencyBonus)
                .AddRow("Max Hit Points", "───────────────", "──────────────>", marvin.MaxHitPoints)
                .AddRow("Hit Die", "───────────────", "──────────────>", marvin.HitDie)
                .AddRow("Passive Wisdom", "───────────────", "──────────────>", marvin.PassiveWisdom)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Str", marvin.Strength, marvin.StrengthModifier, marvin.StrengthSave)
                .AddRow("└──────────────", "Athletics", "──────────────>", marvin.Athletics)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Dex", marvin.Dexterity, marvin.DexterityModifier, marvin.DexteritySave)
                .AddRow("├──────────────", "Acrobatics", "──────────────>", marvin.Acrobatics)
                .AddRow("├──────────────", "Sleight Of Hand", "──────────────>", marvin.SleightOfHand)
                .AddRow("└──────────────", "Stealth", "──────────────>", marvin.Stealth)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Con", marvin.Constitution, marvin.ConstitutionModifier, marvin.ConstitutionSave)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Int", marvin.Intelligence, marvin.IntelligenceModifier, marvin.IntelligenceSave)
                .AddRow("├──────────────", "Arcana", "──────────────>", marvin.Arcana)
                .AddRow("├──────────────", "History", "──────────────>", marvin.History)
                .AddRow("├──────────────", "Investigation", "──────────────>", marvin.Investigation)
                .AddRow("├──────────────", "Nature", "──────────────>", marvin.Nature)
                .AddRow("└──────────────", "Religion", "──────────────>", marvin.Religion)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Wis", marvin.Wisdom, marvin.WisdomModifier, marvin.WisdomSave)
                .AddRow("├──────────────", "Animal Handling", "──────────────>", marvin.AnimalHandling)
                .AddRow("├──────────────", "Insight", "──────────────>", marvin.Insight)
                .AddRow("├──────────────", "Medicine", "──────────────>", marvin.Medicine)
                .AddRow("├──────────────", "Perception", "──────────────>", marvin.Perception)
                .AddRow("└──────────────", "Survival", "──────────────>", marvin.Survival)
                .AddRow("───────────────", "───────────────", "───────────────", "───────────────")
                .AddRow("Cha", marvin.Charisma, marvin.CharismaModifier, marvin.CharismaSave)
                .AddRow("├──────────────", "Deception", "──────────────>", marvin.Deception)
                .AddRow("├──────────────", "Intimidation", "──────────────>", marvin.Intimidation)
                .AddRow("├──────────────", "Performance", "──────────────>", marvin.Performance)
                .AddRow("└──────────────", "Persuasion", "──────────────>", marvin.Persuasion);


            table.Configure(t => t.NumberAlignment = Alignment.Right).Write(Format.Minimal);
            Console.WriteLine();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
