using Microsoft.EntityFrameworkCore.Migrations;

namespace MvE.DAL.Migrations
{
    public partial class CreateMvEdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Background = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true),
                    ProficiencyBonus = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Initiative = table.Column<int>(nullable: false),
                    PassiveWisdom = table.Column<int>(nullable: false),
                    MaxHitPoints = table.Column<int>(nullable: false),
                    HitDie = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    StrengthModifier = table.Column<int>(nullable: false),
                    StrengthSave = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    DexterityModifier = table.Column<int>(nullable: false),
                    DexteritySave = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    ConstitutionModifier = table.Column<int>(nullable: false),
                    ConstitutionSave = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    IntelligenceModifier = table.Column<int>(nullable: false),
                    IntelligenceSave = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    WisdomModifier = table.Column<int>(nullable: false),
                    WisdomSave = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false),
                    CharismaModifier = table.Column<int>(nullable: false),
                    CharismaSave = table.Column<int>(nullable: false),
                    Acrobatics = table.Column<int>(nullable: false),
                    AnimalHandling = table.Column<int>(nullable: false),
                    Arcana = table.Column<int>(nullable: false),
                    Athletics = table.Column<int>(nullable: false),
                    Deception = table.Column<int>(nullable: false),
                    History = table.Column<int>(nullable: false),
                    Insight = table.Column<int>(nullable: false),
                    Intimidation = table.Column<int>(nullable: false),
                    Investigation = table.Column<int>(nullable: false),
                    Medicine = table.Column<int>(nullable: false),
                    Nature = table.Column<int>(nullable: false),
                    Perception = table.Column<int>(nullable: false),
                    Performance = table.Column<int>(nullable: false),
                    Persuasion = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    SleightOfHand = table.Column<int>(nullable: false),
                    Stealth = table.Column<int>(nullable: false),
                    Survival = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CharacterSheets",
                columns: new[] { "Id", "Acrobatics", "Alignment", "AnimalHandling", "Arcana", "Athletics", "Background", "Charisma", "CharismaModifier", "CharismaSave", "Class", "Constitution", "ConstitutionModifier", "ConstitutionSave", "Deception", "Dexterity", "DexterityModifier", "DexteritySave", "History", "HitDie", "Initiative", "Insight", "Intelligence", "IntelligenceModifier", "IntelligenceSave", "Intimidation", "Investigation", "Level", "MaxHitPoints", "Medicine", "Name", "Nature", "PassiveWisdom", "Perception", "Performance", "Persuasion", "ProficiencyBonus", "Race", "Religion", "SleightOfHand", "Speed", "Stealth", "Strength", "StrengthModifier", "StrengthSave", "Survival", "Wisdom", "WisdomModifier", "WisdomSave" },
                values: new object[] { 1984196493, 2, "neutralGood", 3, 6, 2, "Sage", 17, 3, 5, "Bard", 11, 0, 0, 5, 15, 2, 4, 6, 8, 2, 3, 18, 4, 4, 3, 4, 1, 8, 3, "Marvin", 4, 13, 3, 5, 5, 2, "Human", 4, 2, 30, 2, 15, 2, 2, 3, 16, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheets");
        }
    }
}
