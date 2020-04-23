using System;
using MenuManagerLibrary;
using System.Collections.Generic;

namespace MenuManagerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            FoodMenu menu = new FoodMenu("A la Carte - menu ");
            //menu.SetPresetCategories();
            List<Dish> dishes = new List<Dish>();
            //menu.Categories[1].ListOfDishes.Add(new Dish("Haggis", "I dare you", 15));
            //menu.Categories[1].ListOfDishes.Add(new Dish("vodka", "I dare you", 6.7));
            //menu.Categories[1].ListOfDishes.Add(new Dish("Maggara", "I dare you", 14.54));
            //menu.Categories[3].ListOfDishes.Add(new Dish("sgwgwgw", "I dare you", 43));
            //menu.Categories[0].ListOfDishes.Add(new Dish("sushi", "I dare you", 3));


            List<Dish> fullListOfDishes = menu.CombineCategoriesToList();
            FoodMenu.PrintMenuAlphabeticalOrder(fullListOfDishes);
            Console.WriteLine("================");
            FoodMenu.PrintMenuPriceOrder(fullListOfDishes);
            Console.WriteLine("================");
            menu.PrintMenuCategoryOrder();
        }
    }
}
