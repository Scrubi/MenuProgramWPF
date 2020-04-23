//using System;
//using System.Collections.Generic;
//using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerLibrary.DataAccess;
using System.Collections.Generic;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private MenuManager _menuManager;
        private FoodMenu _selectedMenu;
        private BindableCollection<FoodMenu> _menusBinded;
        public List<Dish> allDishes = new List<Dish>();

        public BindableCollection<FoodMenu> MenusBinded
        {
            get { return _menusBinded; }
            set { _menusBinded = value; }
        }

        public MenuManager menuManager
        {
            get { return _menuManager; }
            set { _menuManager = value; }
        }

        public FoodMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                NotifyOfPropertyChange(() => SelectedMenu);
                if(value == null)
                {
                    return;
                }
                else
                {
                    ShowMenu();
                }
            }
        }

        // Constructor for ShellViewModel
        public ShellViewModel()
        {
            menuManager = new MenuManager();
            DataHandler.FillDishesWithDemoData(menuManager);
            DataHandler.CreatePresetAllergens(menuManager);
            MenusBinded = new BindableCollection<FoodMenu>(menuManager.allMenus);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[0]);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[1]);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[2]);
            //DataAccess_Dish dbDish = new DataAccess_Dish();
            //dbDish.DishToDB(name.Text);
            
        }


        // Buttons

        public void ShowMenu()
        {
            MenuViewModel menuViewModel = new MenuViewModel(menuManager, SelectedMenu);
            ActivateItemAsync(menuViewModel, System.Threading.CancellationToken.None);
        }

        public void ShowDishes()
        {
            DataAccess_Dish dbDish = new DataAccess_Dish();
            allDishes = dbDish.DishToDB(menuManager.AllDishes.ToString());
            
            SelectedMenu = null;
            ActivateItemAsync(new DishViewModel(menuManager), System.Threading.CancellationToken.None);
        }
    }
}
