//using System;
using System.Collections.Generic;
//using System.Text;
//using MenuManagerLibrary;
using Caliburn.Micro;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class DataHandler
    {
        //public static List<Dish> BindableListToDishList(BindableCollection<Dish> dishesBindable)
        //{
        //    return new List<Dish>(dishesBindable);
        //}

        //public static List<Category> BindableListToCategoriesList(BindableCollection<Category> categoriesBindable)
        //{
        //    return new List<Category>(categoriesBindable);
        //}
        //public static Dish CreateNewDish(string name, string description, double price)
        //{
        //    Dish dish = new Dish(name, description, price);
        //    return dish;
        //}

        public static void UpdateAllDishes(MenuManager menuManager, BindableCollection<Dish> dishesBinded)
        {
            menuManager.AllDishes.Clear();
            menuManager.AllDishes.AddRange(new List<Dish>(dishesBinded));
        }

        public static void UpdateAllCategories(FoodMenu menu, BindableCollection<Category> categoriesBinded)
        {
            menu.Categories.Clear();
            menu.Categories.AddRange(new List<Category>(categoriesBinded));
        }

        public static BindableCollection<Dish> UpdateBindableCollectionDish(List<Dish> list)
        {
            BindableCollection<Dish> output = new BindableCollection<Dish>(list);
            return output;
        }

        //public static BindableCollection<Category> UpdateBindableCollectionCategory(List<Category> list)
        //{
        //    BindableCollection<Category> output = new BindableCollection<Category>(list);
        //    return output;
        //}

        public static List<Dish> UpdateMenuDishList(FoodMenu menu)
        {
            List<Dish> output = new List<Dish>();

            foreach (Category category in menu.Categories)
            {
                foreach (Dish dish in category.ListOfDishes)
                {
                    if(output.Contains(dish) == false)
                    {
                        output.Add(dish);
                    }
                }
            }

            return output;
        }

        public static void AddDish(MenuManager menuManager, FoodMenu menu, Dish dish)
        {
            if (menu.Categories[0].ListOfDishes.Contains(dish) == false)
            {
                menu.Categories[0].ListOfDishes.Add(dish);
            }


            if (menuManager.AllDishes.Contains(dish) == false)
            {
                menuManager.AllDishes.Add(dish);
            }
        }

        public static void FillDishesWithDemoData(MenuManager menuManager)
        {

            menuManager.allMenus.Add(new FoodMenu("A la Carte"));
            menuManager.allMenus.Add(new FoodMenu("Dinner"));
            menuManager.allMenus.Add(new FoodMenu("Drinks"));
            menuManager.allMenus[0].Categories.Add(new Category("Appetizers"));
            menuManager.allMenus[0].Categories.Add(new Category("Main Courses"));
            menuManager.allMenus[0].Categories.Add(new Category("Desserts"));
            menuManager.allMenus[1].Categories.Add(new Category("Main Courses"));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Haggis", "I dare you", 15));
            AddDish(menuManager, menuManager.allMenus[2], new Dish("Vodka", "I dare you", 6.7));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Maggara", "I dare you", 4.7));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Sushi", "I dare you", 9.50));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Nakit ja muusi", "I dare you", 8.0));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Vodka", "I dare you", 6.7));
            menuManager.allMenus[0].Categories[0].ListOfDishes.Add(menuManager.AllDishes[0]);
            menuManager.allMenus[0].Categories[1].ListOfDishes.Add(menuManager.AllDishes[1]);
            menuManager.allMenus[0].Categories[2].ListOfDishes.Add(menuManager.AllDishes[2]);
        }

        public static void CreatePresetAllergens(MenuManager menuManager)
        {
            menuManager.allAllergens.Add(new Allergen("Lactose"));
            menuManager.allAllergens.Add(new Allergen("Fish"));
            menuManager.allAllergens.Add(new Allergen("Nuts"));
        }

        public static List<AllergenBoolCombination> CombineAllergenAndBool(MenuManager menuManager, List<Allergen> allergens)
        {
            List<AllergenBoolCombination> outputList = new List<AllergenBoolCombination>();

            foreach (Allergen allergen in menuManager.allAllergens)
            {
                AllergenBoolCombination allergenBoolCombination = new AllergenBoolCombination();
                allergenBoolCombination.allergen = allergen;

                if (allergens.Contains(allergen))
                {
                    allergenBoolCombination.hasAllergen = true;
                }
                else
                {
                    allergenBoolCombination.hasAllergen = false;
                }

                outputList.Add(allergenBoolCombination);
            }

            return outputList;
        }

        public static void UpdateDishAllergens(List<AllergenBoolCombination> combinationList, Dish dish)
        {
            List<Allergen> dishAllergensUpdated = new List<Allergen>();

            foreach (AllergenBoolCombination allergenBool in combinationList)
            {
                if (allergenBool.hasAllergen == true)
                {
                    dishAllergensUpdated.Add(allergenBool.allergen);
                }
            }

            dish.Allergens = dishAllergensUpdated;
        }
       
            
        
    }
}
