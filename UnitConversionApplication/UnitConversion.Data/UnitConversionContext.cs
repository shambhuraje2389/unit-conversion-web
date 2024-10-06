using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion.Models.Data;

namespace UnitConversion.Data
{

    public class UnitConversionContext : DbContext
    {
        public UnitConversionContext(DbContextOptions<UnitConversionContext> options) : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }

        public DbSet<ConversionRate> ConversionRates { get; set; }

        public DbSet<ConversionHistory> ConversionHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                // Length Catergory units
                new Unit { Id = 1, Name = "Kilometer", Type = Catergory.Length, CreatedDate = DateTime.Now },
                new Unit { Id = 2, Name = "Meter", Type = Catergory.Length, CreatedDate = DateTime.Now },
                new Unit { Id = 3, Name = "Centimeter", Type = Catergory.Length, CreatedDate = DateTime.Now },
                new Unit { Id = 4, Name = "Mile", Type = Catergory.Length, CreatedDate = DateTime.Now },
                new Unit { Id = 5, Name = "Foot", Type = Catergory.Length, CreatedDate = DateTime.Now },
                new Unit { Id = 6, Name = "Inch", Type = Catergory.Length, CreatedDate = DateTime.Now },

                // Weight Catergory units
                new Unit { Id = 7, Name = "Gram", Type = Catergory.Weight, CreatedDate = DateTime.Now },
                new Unit { Id = 8, Name = "Kilogram", Type = Catergory.Weight, CreatedDate = DateTime.Now },
                new Unit { Id = 9, Name = "Miligram", Type = Catergory.Weight, CreatedDate = DateTime.Now },
                new Unit { Id = 10, Name = "Pound", Type = Catergory.Weight, CreatedDate = DateTime.Now },

                // Temperature Catergory units
                new Unit { Id = 11, Name = "Celsius", Type = Catergory.Temperature, CreatedDate = DateTime.Now },
                new Unit { Id = 12, Name = "Kelvin", Type = Catergory.Temperature, CreatedDate = DateTime.Now },
                new Unit { Id = 13, Name = "Fahrenheit", Type = Catergory.Temperature, CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<ConversionRate>().HasData(
            #region Length conversion
                //Conversion Kilometer to other units
                new ConversionRate { Id = 1, SourceUnitId = 1, TargetUnitId = 2, Formula = "(inputVal*1000)" },// Meter
                new ConversionRate { Id = 2, SourceUnitId = 1, TargetUnitId = 3, Formula = "(inputVal*100000)" },// Centimeter
                new ConversionRate { Id = 3, SourceUnitId = 1, TargetUnitId = 4, Formula = "(inputVal/1.609)" },// Mile
                new ConversionRate { Id = 4, SourceUnitId = 1, TargetUnitId = 5, Formula = "(inputVal*3281)" }, // Foot
                new ConversionRate { Id = 5, SourceUnitId = 1, TargetUnitId = 6, Formula = "(inputVal/39370)" }, // Inch

                //Conversion Meter to other units
                new ConversionRate { Id = 6, SourceUnitId = 2, TargetUnitId = 1, Formula = "(inputVal/1000)" },// Kilometer
                new ConversionRate { Id = 7, SourceUnitId = 2, TargetUnitId = 3, Formula = "(inputVal*100)" }, // Centimeter
                new ConversionRate { Id = 8, SourceUnitId = 2, TargetUnitId = 4, Formula = "(inputVal/1609)" },//Mile
                new ConversionRate { Id = 9, SourceUnitId = 2, TargetUnitId = 5, Formula = "(inputVal*3.281)" },//Foot
                new ConversionRate { Id = 10, SourceUnitId = 2, TargetUnitId = 6, Formula = "(inputVal*39.37)" },//Inch

                //Conversion Centimeter to other units
                new ConversionRate { Id = 11, SourceUnitId = 3, TargetUnitId = 1, Formula = "(inputVal/100000)" },//Kilometer
                new ConversionRate { Id = 12, SourceUnitId = 3, TargetUnitId = 2, Formula = "(inputVal/100)" },//Meter
                new ConversionRate { Id = 13, SourceUnitId = 3, TargetUnitId = 4, Formula = "(inputVal/160900)" },//Mile
                new ConversionRate { Id = 14, SourceUnitId = 3, TargetUnitId = 5, Formula = "(inputVal/30.48)" },//Foot
                new ConversionRate { Id = 15, SourceUnitId = 3, TargetUnitId = 6, Formula = "(inputVal/2.54)" },//Inch

                //Conversion Mile to other units
                new ConversionRate { Id = 16, SourceUnitId = 4, TargetUnitId = 1, Formula = "(inputVal*1.609)" },//Kilometer
                new ConversionRate { Id = 17, SourceUnitId = 4, TargetUnitId = 2, Formula = "(inputVal*1609)" },//Meter
                new ConversionRate { Id = 18, SourceUnitId = 4, TargetUnitId = 3, Formula = "(inputVal*160900)" },// Centimeter
                new ConversionRate { Id = 19, SourceUnitId = 4, TargetUnitId = 5, Formula = "(inputVal*5280)" },//Foot
                new ConversionRate { Id = 20, SourceUnitId = 4, TargetUnitId = 6, Formula = "(inputVal*63360)" },//Inch

                //Conversion Foot to other units
                new ConversionRate { Id = 21, SourceUnitId = 5, TargetUnitId = 1, Formula = "(inputVal/3281)" },//Kilometer
                new ConversionRate { Id = 22, SourceUnitId = 5, TargetUnitId = 2, Formula = "(inputVal/3.281)" },//Meter
                new ConversionRate { Id = 23, SourceUnitId = 5, TargetUnitId = 3, Formula = "(inputVal*30.48)" },// Centimeter
                new ConversionRate { Id = 24, SourceUnitId = 5, TargetUnitId = 4, Formula = "(inputVal/5280)" },//Mile
                new ConversionRate { Id = 25, SourceUnitId = 5, TargetUnitId = 6, Formula = "(inputVal*12)" },//Inch

                //Conversion Inch to other units
                new ConversionRate { Id = 26, SourceUnitId = 6, TargetUnitId = 1, Formula = "(inputVal/39370)" },//Kilometer
                new ConversionRate { Id = 27, SourceUnitId = 6, TargetUnitId = 2, Formula = "(inputVal/39.37)" },//Meter
                new ConversionRate { Id = 28, SourceUnitId = 6, TargetUnitId = 3, Formula = "(inputVal*2.54)" },// Centimeter
                new ConversionRate { Id = 29, SourceUnitId = 6, TargetUnitId = 4, Formula = "(inputVal/63360)" },//Mile
                new ConversionRate { Id = 30, SourceUnitId = 6, TargetUnitId = 5, Formula = "(inputVal/12)" },//Foot
                #endregion

            #region Weight conversion
                //Conversion Gram to other units
                new ConversionRate { Id = 31, SourceUnitId = 7, TargetUnitId = 8, Formula = "(inputVal/1000)" },// Kilogram
                new ConversionRate { Id = 32, SourceUnitId = 7, TargetUnitId = 9, Formula = "(inputVal*1000)" },// Miligram
                new ConversionRate { Id = 33, SourceUnitId = 7, TargetUnitId = 10, Formula = "(inputVal/453.6)" },// Pound

                //Conversion Kilogram to other units
                new ConversionRate { Id = 34, SourceUnitId = 8, TargetUnitId = 7, Formula = "(inputVal*1000)" },// Gram
                new ConversionRate { Id = 35, SourceUnitId = 8, TargetUnitId = 9, Formula = "(inputVal*1e+6)" },// Miligram
                new ConversionRate { Id = 36, SourceUnitId = 8, TargetUnitId = 10, Formula = "(inputVal*2.205)" },// Pound

                //Conversion Miligram to other units
                new ConversionRate { Id = 37, SourceUnitId = 9, TargetUnitId = 7, Formula = "(inputVal/1000)" },// Gram
                new ConversionRate { Id = 38, SourceUnitId = 9, TargetUnitId = 8, Formula = "(inputVal/1e+6)" },// Kilogram
                new ConversionRate { Id = 39, SourceUnitId = 9, TargetUnitId = 10, Formula = "(inputVal/453600)" },// Pound

                //Conversion Pound to other units
                new ConversionRate { Id = 40, SourceUnitId = 10, TargetUnitId = 7, Formula = "(inputVal*453.6)" },// Gram
                new ConversionRate { Id = 41, SourceUnitId = 10, TargetUnitId = 8, Formula = "(inputVal/2.205)" },// Kilogram
                new ConversionRate { Id = 42, SourceUnitId = 10, TargetUnitId = 9, Formula = "(inputVal*453600)" },// Miligram

            #endregion


            #region Temperature conversion

                //Conversion Celsius to other units
                new ConversionRate { Id = 43, SourceUnitId = 11, TargetUnitId = 12, Formula = "(inputVal+273.15)" },// Kelvin
                new ConversionRate { Id = 44, SourceUnitId = 11, TargetUnitId = 13, Formula = "((inputVal*9/5) + 32)" },// Fahrenheit

                //Conversion Kelvin to other units
                new ConversionRate { Id = 45, SourceUnitId = 12, TargetUnitId = 11, Formula = "(inputVal-273.15)" },// Celsius
                new ConversionRate { Id = 46, SourceUnitId = 12, TargetUnitId = 13, Formula = "(((inputVal-273.15)*9/5) + 32)" },// Fahrenheit

                //Conversion Fahrenheit to other units
                new ConversionRate { Id = 47, SourceUnitId = 13, TargetUnitId = 11, Formula = "((inputVal-32)*5/9)" },// Celsius
                new ConversionRate { Id = 48, SourceUnitId = 13, TargetUnitId = 12, Formula = "((inputVal-32)*5/9 +273.15)" }// Kelvin

             #endregion

            );
        }
    }
}
