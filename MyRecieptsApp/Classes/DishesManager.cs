using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRecieptsApp.Classes
{
    public class IngredientsCount
    {
        public Ingredient ingredient { get; set; }

        public int Count { get; set; }

        public int Portition { get; set; }

        public string Price { 
            get
            {
                return $"{ingredient.Price * Count} руб.";
            }
        }

        public string Have {
            get
            {
                foreach (var ing in IngredientManager.Instance.Ingredients)
                {
                    if (ing.Name == ingredient.Name)
                    {
                        if (Count > ing.Count)
                        {
                            return "◉";//"✖";
                        }
                        else
                        {
                            return "○";//"✔";
                        }
                    }
                }
                return "◉";//"✖";
            }
        }
    }

    public class DishesManager : INotifyPropertyChanged
    {
        private Dish _selectedDish;

        public List<Dish> Dishes { get; set; }

        public Dish SelectedDish
        {
            get => _selectedDish;
            set
            {
                _selectedDish = value;
                OnPropertyChanged();
            }
        }

        public DishesManager()
        {
            LoadDishes();
        }

        private void LoadDishes()
        {
            Dishes = new List<Dish>
            {
                new Dish {
                    Name = "Мороженое ягодное",
                    Image = "/Images/dish1.jpg",
                    Description = ("1. Налить сливки в глубокую миску\n" +
                    "2. Охладить\n" +
                    "3. Взбить миксером\n" +
                    "4.Закинуть в морозилку на 2 часа\n"),
                    Category = CategoriestManager.Instance.Categories[1],
                    Time = 130,
                    Ingredients = new List<IngredientsCount>
                    {
                        new IngredientsCount { ingredient = IngredientManager.Instance.Ingredients[0], Count = 10 },
                        new IngredientsCount { ingredient = IngredientManager.Instance.Ingredients[1], Count = 10 },
                    }
                },
                new Dish
                {
                    Name = "Картофельное пюре с котлетой",
                    Image = "/Images/dish2.jpg",
                    Description = "1.Почистить и сварить картошку\n" +
                    "2.Добавить сливки и сделать пюре\n" +
                    "3.Купить в магазине и пожарить\n",
                    Category = CategoriestManager.Instance.Categories[2],
                    Time = 45,
                    Ingredients = new List<IngredientsCount>
                    {
                        new IngredientsCount { ingredient = IngredientManager.Instance.Ingredients[0], Count = 10 },
                        new IngredientsCount { ingredient = IngredientManager.Instance.Ingredients[2], Count = 1 },
                        new IngredientsCount { ingredient = IngredientManager.Instance.Ingredients[3], Count = 4 },
                    },


                }
            };
        }

        public void RemoveSelectedDish(Dish dish)
        {
            Dishes.Remove(dish);
        }

        public void AdddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void UpdateDish(Dish oldDish, Dish newDish)
        {
            var index = Dishes.IndexOf(oldDish);
            if (index != -1)
            {
                Dishes[index] = newDish;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
