//using System;
using System.Collections.Generic;
using System.Windows;
//using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerLibrary.Models;

namespace MenuManagerWpfUi.ViewModels
{
	public class AllergensViewModel : Conductor<object>
	{
		private MenuManager _selectedMenuManager;
		private FoodMenu _selectedMenu;
		private Dish _selectedDish;
		private BindableCollection<AllergenBoolCombination> _allergenBoolCombinations;

		public BindableCollection<AllergenBoolCombination> AllergenBoolCombinations
		{
			get { return _allergenBoolCombinations; }
			set { _allergenBoolCombinations = value; }
		}


		public Dish SelectedDish
		{
			get { return _selectedDish; }
			set { _selectedDish = value; }
		}

		public FoodMenu SelectedMenu
		{
			get { return _selectedMenu; }
			set { _selectedMenu = value; }
		}

		public MenuManager SelectedMenuManager
		{
			get { return _selectedMenuManager; }
			set { _selectedMenuManager = value; }
		}


		// Constructor for AllergensViewModel
		public AllergensViewModel(MenuManager menuManager, FoodMenu menu, Dish dish)
		{
			this.SelectedDish = dish;
			this.SelectedMenu = menu;
			this.SelectedMenuManager = menuManager;
			this.AllergenBoolCombinations = new BindableCollection<AllergenBoolCombination>(DataHandler.CombineAllergenAndBool(SelectedMenuManager, SelectedDish.Allergens));
		}


		// Buttons

		public void SaveChanges()
		{
			DataHandler.UpdateDishAllergens(new List<AllergenBoolCombination>(AllergenBoolCombinations), SelectedDish);
			MessageBox.Show("Changes saved");
		}

	}
}
