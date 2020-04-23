using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class MenuManager
    {
		private List<Dish> _allDishes;
		//public List<Category> allCategories;
		public List<FoodMenu> allMenus;
		public List<Allergen> allAllergens { get; set; }

		public List<Dish> AllDishes
		{
			get { return _allDishes; }
			set
			{
				_allDishes = value;
			}
		}



		// Constructor for MenuManager
		public MenuManager()
		{
			AllDishes = new List<Dish>();
			allAllergens = new List<Allergen>();
			this.allMenus = new List<FoodMenu>();
			
			//this.allMenus.Insert(0, new FoodMenu("All Foods", AllDishes));
		}
	}
}
