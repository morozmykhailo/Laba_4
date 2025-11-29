using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4.Classes_Laba4
{
    public class Fruit : FoodProduct
    {
        public string CountryOfOrigin { get; set; }

        public Fruit() : base()
        {
            CountryOfOrigin = "Unknown";
        }

        public Fruit(string name, double calories, DateTime expiration, string country)
            : base(name, calories, expiration)
        {
            CountryOfOrigin = country;
        }

        // Перевизначення калорійності
        public override double GetCalories()
        {
            return CaloriesPer100g;
        }

        // Інформація про БЖВ
        public override string GetBzhvInfo()
        {
            return "Б: 0.5г, Ж: 0.3г, В: 14г (орієнтовно для фруктів)";
        }

        // Детальний опис
        public override string GetNutritionInfo()
        {
            return $"{Name} (фрукт, {CountryOfOrigin}), {CaloriesPer100g} ккал/100г";
        }

        // Перевірка алергії
        public bool CheckAllergy(string allergen)
        {
            allergen = allergen.ToLower();

            // Простий приклад
            if (allergen == "цитрус" && Name.ToLower().Contains("апельсин"))
                return true;

            if (allergen == "тропічні" && Name.ToLower().Contains("манго"))
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"{Name} (фрукт) — Ккал: {CaloriesPer100g}, Країна: {CountryOfOrigin}, Придатний до: {ExpirationDate.ToShortDateString()}";
        }
    }
}
