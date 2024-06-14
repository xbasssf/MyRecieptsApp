using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRecieptsApp.Classes
{
    public class IngredientManager
    {
        private static IngredientManager _instance;
        private static readonly object _lock = new object();

        public static IngredientManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new IngredientManager();
                    }
                    return _instance;
                }
            }
        }

        public List<Ingredient> Ingredients { get; private set; }

        private IngredientManager()
        {
            // Initial ingredients can be loaded here or from a persistent storage
            Ingredients = new List<Ingredient>
            {
                new Ingredient(){ Name = "Сливки", Count = 18, Dimension = "шт.", Price = 5, DimensionPrice = 1 },
                new Ingredient(){ Name = "Ягоды", Count = 28, Dimension = "гр.", Price = 10, DimensionPrice = 1 },
                new Ingredient(){ Name = "Котлеты", Count = 1, Dimension = "шт.", Price = 200, DimensionPrice = 1 },
                new Ingredient(){ Name = "Картофель", Count = 4, Dimension = "шт.", Price = 5, DimensionPrice = 1 },
            };
        }

        public bool AddIngredient(Ingredient ingredient)
        {
            foreach (var i in Ingredients)
            {
                if (i.Name == ingredient.Name)
                {
                    MessageBox.Show("Такой ингредиент уже существует!");
                    return false;
                }
            }
            Ingredients.Add(ingredient);
            return true;
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        public void UpdateIngredient(Ingredient oldIngredient, Ingredient newIngredient)
        {
            var index = Ingredients.IndexOf(oldIngredient);
            if (index != -1)
            {
                Ingredients[index] = newIngredient;
            }
        }
    }
}
