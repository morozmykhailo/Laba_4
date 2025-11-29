using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4.Classes_Laba4
{
    public abstract class FoodProduct
    {
        public string Name { get; set; }
        public double CaloriesPer100g { get; set; }
        public DateTime ExpirationDate { get; set; }


        protected FoodProduct()
        {
            Name = "Unknown";
            CaloriesPer100g = 0;
            ExpirationDate = DateTime.Now;
        }


        protected FoodProduct(string name, double calories, DateTime expiration)
        {
            Name = name;
            CaloriesPer100g = calories;
            ExpirationDate = expiration;
        }

        // Отримати енергетичну цінність продукту
        public virtual double GetCalories()
        {
            return CaloriesPer100g;
        }

        // Отримати загальні БЖВ (білки/жири/вуглеводи)
        public virtual string GetBzhvInfo()
        {
            return "БЖВ не вказано.";
        }

        // Отримати інформацію про харчову цінність
        public virtual string GetNutritionInfo()
        {
            return $"{Name}: {CaloriesPer100g} ккал на 100 г";
        }
    }
}
