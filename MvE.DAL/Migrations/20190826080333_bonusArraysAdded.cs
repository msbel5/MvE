using Microsoft.EntityFrameworkCore.Migrations;

namespace MvE.DAL.Migrations
{
    public partial class bonusArraysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSheets",
                keyColumn: "Id",
                keyValue: 526055437);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundProficientSkills",
                table: "CharacterSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassPrimaryAbilities",
                table: "CharacterSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassProficientSkills",
                table: "CharacterSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassSavingProficiencies",
                table: "CharacterSheets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceAbilityBonusses",
                table: "CharacterSheets",
                nullable: true);

            migrationBuilder.InsertData(
                table: "CharacterSheets",
                columns: new[] { "Id", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Background", "BackgroundProficientSkills", "Charisma", "CharismaModifier", "CharismaSave", "Class", "ClassPrimaryAbilities", "ClassProficientSkills", "ClassSavingProficiencies", "Constitution", "ConstitutionModifier", "ConstitutionSave", "Deception", "Dexterity", "DexterityModifier", "DexteritySave", "History", "HitDie", "Initiative", "Insight", "Intelligence", "IntelligenceModifier", "IntelligenceSave", "Intimidation", "Investigation", "Level", "MaxHitPoints", "Medicine", "Name", "Nature", "PassiveWisdom", "Perception", "Performance", "Persuasion", "ProficiencyBonus", "Race", "RaceAbilityBonusses", "Religion", "Size", "SleightOfHand", "Speed", "Stealth", "Strength", "StrengthModifier", "StrengthSave", "Survival", "Wisdom", "WisdomModifier", "WisdomSave" },
                values: new object[] { 415872852, 2, "neutralGood", 3, 6, 2, "Sage", "4,5", 17, 3, 5, "Bard", "5", "14,17,16", "1,5", 11, 0, 0, 5, 15, 2, 4, 6, 8, 2, 3, 18, 4, 4, 3, 4, 1, 8, 3, "Marvin", 4, 13, 3, 5, 5, 2, "Human", "0,1,2,3,4,5", 4, 'm', 2, 30, 2, 15, 2, 2, 3, 16, 3, 3 });

            migrationBuilder.InsertData(
                table: "CharacterSheets",
                columns: new[] { "Id", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Background", "BackgroundProficientSkills", "Charisma", "CharismaModifier", "CharismaSave", "Class", "ClassPrimaryAbilities", "ClassProficientSkills", "ClassSavingProficiencies", "Constitution", "ConstitutionModifier", "ConstitutionSave", "Deception", "Dexterity", "DexterityModifier", "DexteritySave", "History", "HitDie", "Initiative", "Insight", "Intelligence", "IntelligenceModifier", "IntelligenceSave", "Intimidation", "Investigation", "Level", "MaxHitPoints", "Medicine", "Name", "Nature", "PassiveWisdom", "Perception", "Performance", "Persuasion", "ProficiencyBonus", "Race", "RaceAbilityBonusses", "Religion", "Size", "SleightOfHand", "Speed", "Stealth", "Strength", "StrengthModifier", "StrengthSave", "Survival", "Wisdom", "WisdomModifier", "WisdomSave" },
                values: new object[] { 2048576229, 2, "neutralGood", 3, 6, 2, "Sage", "4,5", 17, 3, 5, "Bard", "5", "14,17,16", "1,5", 11, 0, 0, 5, 15, 2, 4, 6, 8, 2, 3, 18, 4, 4, 3, 4, 1, 8, 3, "Marvin", 4, 13, 3, 5, 5, 2, "Human", "0,1,2,3,4,5", 4, 'm', 2, 30, 2, 15, 2, 2, 3, 16, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSheets",
                keyColumn: "Id",
                keyValue: 415872852);

            migrationBuilder.DeleteData(
                table: "CharacterSheets",
                keyColumn: "Id",
                keyValue: 2048576229);

            migrationBuilder.DropColumn(
                name: "BackgroundProficientSkills",
                table: "CharacterSheets");

            migrationBuilder.DropColumn(
                name: "ClassPrimaryAbilities",
                table: "CharacterSheets");

            migrationBuilder.DropColumn(
                name: "ClassProficientSkills",
                table: "CharacterSheets");

            migrationBuilder.DropColumn(
                name: "ClassSavingProficiencies",
                table: "CharacterSheets");

            migrationBuilder.DropColumn(
                name: "RaceAbilityBonusses",
                table: "CharacterSheets");

            migrationBuilder.InsertData(
                table: "CharacterSheets",
                columns: new[] { "Id", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Background", "Charisma", "CharismaModifier", "CharismaSave", "Class", "Constitution", "ConstitutionModifier", "ConstitutionSave", "Deception", "Dexterity", "DexterityModifier", "DexteritySave", "History", "HitDie", "Initiative", "Insight", "Intelligence", "IntelligenceModifier", "IntelligenceSave", "Intimidation", "Investigation", "Level", "MaxHitPoints", "Medicine", "Name", "Nature", "PassiveWisdom", "Perception", "Performance", "Persuasion", "ProficiencyBonus", "Race", "Religion", "Size", "SleightOfHand", "Speed", "Stealth", "Strength", "StrengthModifier", "StrengthSave", "Survival", "Wisdom", "WisdomModifier", "WisdomSave" },
                values: new object[] { 526055437, 2, "neutralGood", 3, 6, 2, "Sage", 17, 3, 5, "Bard", 11, 0, 0, 5, 15, 2, 4, 6, 8, 2, 3, 18, 4, 4, 3, 4, 1, 8, 3, "Marvin", 4, 13, 3, 5, 5, 2, "Human", 4, 'm', 2, 30, 2, 15, 2, 2, 3, 16, 3, 3 });
        }
    }
}
