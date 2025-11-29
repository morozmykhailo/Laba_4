using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4.Classes_Laba4
{
    public class Vegetable : FoodProduct
    {
        public string CultivationMethod { get; set; }

        public Vegetable() : base()
        {
            CultivationMethod = "Unknown";
        }

        public Vegetable(string name, double calories, DateTime expiration, string method)
            : base(name, calories, expiration)
        {
            CultivationMethod = method;
        }

        public override double GetCalories()
        {
            return CaloriesPer100g;
        }

        public override string GetBzhvInfo()
        {
            return "Б: 1.2г, Ж: 0.1г, В: 5г (орієнтовно для овочів)";
        }

        public override string GetNutritionInfo()
        {
            return $"{Name} (овоч, вирощування: {CultivationMethod}), {CaloriesPer100g} ккал/100г";
        }

        // Додатковий метод: вміст вітамінів
        public string GetVitaminContent()
        {
            return "Вітаміни A, C, K (типово для овочів)";
        }
        public override string ToString()
        {
            return $"{Name} (овоч) — Ккал: {CaloriesPer100g}, Вирощування: {CultivationMethod}, Придатний до: {ExpirationDate.ToShortDateString()}";
        }
    }
}
