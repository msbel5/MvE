using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvE.DAL.Models;
using MvE.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MvE.DAL.Data
{
    public class DBContext : DbContext
    {        
        public static bool _created = false;

        public DbSet<CharacterSheet> CharacterSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\MvE.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSheet>().HasKey(c => c.Id);
            modelBuilder.Entity<CharacterSheet>().Property(c=>c.Name);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Race);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Class);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Background);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Alignment);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Level);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ProficiencyBonus);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Initiative);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Speed);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Size);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.MaxHitPoints);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.HitDie);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Strength);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.StrengthModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.StrengthSave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Dexterity);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.DexterityModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.DexteritySave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Constitution);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ConstitutionModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ConstitutionSave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Intelligence);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.IntelligenceModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.IntelligenceSave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Wisdom);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.WisdomModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.WisdomSave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Charisma);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.CharismaModifier);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.CharismaSave);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Acrobatics);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.AnimalHandling);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Arcana);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Athletics);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Deception);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.History);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Insight);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Intimidation);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Investigation);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Medicine);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Nature);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Perception);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Performance);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Persuasion);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Religion);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.SleightOfHand);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Stealth);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.Survival);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.PassiveWisdom);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.RaceAbilityBonusses);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ClassPrimaryAbilities);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ClassProficientSkills);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.ClassSavingProficiencies);
            modelBuilder.Entity<CharacterSheet>().Property(c => c.BackgroundProficientSkills);

            EAbilities[] abilities = new EAbilities[] { EAbilities.Strength, EAbilities.Dexterity, EAbilities.Constitution, EAbilities.Intelligence, EAbilities.Wisdom, EAbilities.Charisma };
            Race human = new Race("Human", 30, abilities, 'm');
            EAbilities[] primaryAbilities = new EAbilities[] { EAbilities.Charisma };
            EAbilities[] saves = new EAbilities[] { EAbilities.Dexterity, EAbilities.Charisma };
            ESkills[] classProficency = new ESkills[] { ESkills.Deception, ESkills.Persuasion, ESkills.Performance };
            Class bard = new Class("Bard", 8, primaryAbilities, saves, classProficency);
            Background sage = new Background("Sage", new ESkills[] { ESkills.Arcana, ESkills.History });
            int[] abilityPoints_SDCIWC = new int[6] { 14, 14, 10, 17, 15, 16 };
            Character MarvinTheHumanBard = new Character("Marvin", abilityPoints_SDCIWC, human, bard, EAlignment.neutralGood, sage);
            CharacterSheet Marvin = new CharacterSheet(MarvinTheHumanBard);
            Character DarwinTheHumanScientiest = new Character("Darwin", abilityPoints_SDCIWC, human, bard, EAlignment.lawfulGood, sage);
            CharacterSheet Darwin = new CharacterSheet(MarvinTheHumanBard);

            modelBuilder.Entity<CharacterSheet>().HasData(Marvin);
            modelBuilder.Entity<CharacterSheet>().HasData(Darwin);


        }



        public DBContext() : base()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }

        }

    }
}
