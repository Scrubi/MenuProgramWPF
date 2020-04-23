//using System;
//using System.Collections.Generic;
//using System.Text;
using System.Windows;
using Caliburn.Micro;
using MenuManagerLibrary;
//using MenuManagerLibrary.Models;
//using MenuManagerWpfUi.Views;
//using System.Windows.Controls;

namespace MenuManagerWpfUi.ViewModels
{
    public class DishViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
        private BindableCollection<Dish> _dishesBinded;
        public AllergensViewModel allergensViewModel { get; set; }



        private string _dishName;
        public double DishPrice { get; set; }
        public string DishDescription { get; set; }

        public string DishName
        {
            get { return _dishName; }
            set
            {
                _dishName = value;
            }
        }

        public BindableCollection<Dish> DishesBinded
        {
            get 
            {
                return _dishesBinded; 
            }
            set
            {
                _dishesBinded = value;
            }
        }

        public Dish SelectedDish
        {
            get {  return _selectedDish; }
            set
            {
                _selectedDish = value;
                if(value == null)
                {
                    return;
                }
                else
                {
                    ShowAllergens();
                }
                
            }
        }

        public FoodMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
            }
        }

        public MenuManager SelectedMenuManager
        {
            get { return _selecterMenuManager; }
            set
            {
                _selecterMenuManager = value;
            }
        }



        // Constructor for DishViewModel
        public DishViewModel(MenuManager menuManager)
        {
            SelectedMenuManager = menuManager;
            //SelectedMenu = menu;
            DishesBinded = new BindableCollection<Dish>(menuManager.AllDishes);
        }       



        // Buttons

        public void ShowAllergens()
        {
            allergensViewModel = new AllergensViewModel(this.SelectedMenuManager, this.SelectedMenu, this.SelectedDish);
            ActivateItemAsync(allergensViewModel, System.Threading.CancellationToken.None);
        }

        public void AddDishButton()
        {
            if (Utilities.CheckNameValidity(DishName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }

            DishName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(DishName));
            Dish newDish = new Dish(DishName, DishDescription, DishPrice);

            if (SelectedMenuManager.AllDishes.Contains(newDish))
            {
                MessageBox.Show("The dish is already in the list");
            }
            else
            {
                this.DishesBinded.Add(newDish);
                DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
            }
            

        }

        public bool CanRemoveDishButton()
        {
            if(this.DishesBinded.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveDishButton()
        {
            
            SelectedMenuManager.AllDishes.Remove(SelectedDish);
            DishesBinded.Remove(SelectedDish);
            DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
        }
    }
}
