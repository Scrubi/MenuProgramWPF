//using System;
//using System.Collections.Generic;
//using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using System.Windows;

namespace MenuManagerWpfUi.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Category _selectedCategory;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
        public string CategoryName { get; set; }
        private BindableCollection<Category> _categoriesBinded;
        private BindableCollection<Dish> _allDishesBinded;
        private BindableCollection<Dish> _menuDishesBinded;

        public BindableCollection<Dish> AllDishesBinded
        {
            get { return _allDishesBinded; }
            set { _allDishesBinded = value; }
        }

        public BindableCollection<Dish> MenuDishesBinded
        {
            get { return _menuDishesBinded; }
            set 
            {
                _menuDishesBinded = value;
                NotifyOfPropertyChange(() => MenuDishesBinded);
            }
        }

        public BindableCollection<Category> CategoriesBinded
        {
            get { return _categoriesBinded; }
            set
            {
                _categoriesBinded = value;
                NotifyOfPropertyChange(() => CategoriesBinded);
            }
        }

        public Dish SelectedDish
        {
            get 
            {
                return _selectedDish; 
            }
            set { _selectedDish = value; }
        }

        public FoodMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set { _selectedMenu = value; }
        }

        public MenuManager SelectedMenuManager
        {
            get { return _selecterMenuManager; }
            set{ _selecterMenuManager = value; }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            { 
                if(value == null)
                {
                    return;
                }
               
                _selectedCategory = value;
                

                if (SelectedCategory == SelectedMenu.Categories[0])
                {
                    SelectedMenu.Categories[0].ListOfDishes = DataHandler.UpdateMenuDishList(SelectedMenu);
                }

                MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(value.ListOfDishes);
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }



        // Constructor for DishViewModel
        public MenuViewModel(MenuManager menuManager, FoodMenu menu)
        {
            SelectedMenuManager = menuManager;
            SelectedMenu = menu;
            AllDishesBinded = new BindableCollection<Dish>(SelectedMenuManager.AllDishes);
            MenuDishesBinded = new BindableCollection<Dish>(DataHandler.UpdateMenuDishList(SelectedMenu));
            CategoriesBinded = new BindableCollection<Category>(SelectedMenu.Categories);
            SelectedCategory = SelectedMenu.Categories[0];
        }
        

        // Buttons

        public void AddDishToCategory()
        {
            if(SelectedCategory == null)
            {
                MessageBox.Show("Please, select a category");
                return;
            } 
            
            if (SelectedCategory.ListOfDishes.Contains(SelectedDish))
            {
                MessageBox.Show("The dish is already in the list");
                return;
            }

            if (SelectedMenu.Categories[0].ListOfDishes.Contains(SelectedDish) == false)
            {
                SelectedMenu.Categories[0].ListOfDishes.Add(SelectedDish);
            }

            if(SelectedCategory != SelectedMenu.Categories[0])
            {
                SelectedCategory.ListOfDishes.Add(SelectedDish);
            }

            MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);

        }

        public void RemoveDishFromCategory()
        {
            Dish SelectedDishCopy = SelectedDish;

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                foreach (Category category in SelectedMenu.Categories)
                {
                    category.ListOfDishes.Remove(SelectedDish);  
                }

                MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);
                SelectedDish = SelectedDishCopy;
                return;
            }

            if (SelectedCategory.ListOfDishes.Contains(SelectedDish))
            {
                SelectedCategory.ListOfDishes.Remove(SelectedDish);
                MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);
                SelectedDish = SelectedDishCopy;
                return;
            }


            MessageBox.Show("The dish is not in the list");
        }

        public void AddCategory()
        {
            if (Utilities.CheckNameValidity(CategoryName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }

            CategoryName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(CategoryName));
            Category newCategory = new Category(CategoryName);

            if (SelectedMenu.Categories.Contains(newCategory))
            {
                MessageBox.Show("The category already exists");
            }
            else
            {
                this.CategoriesBinded.Add(newCategory);
                DataHandler.UpdateAllCategories(SelectedMenu, CategoriesBinded);
            }
        }

        public void RemoveCategory()
        {
            if(SelectedCategory == null)
            {
                return;
            }

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                MessageBox.Show("Can't remove this category");
                return;
            }

            CategoriesBinded.Remove(SelectedCategory);
            DataHandler.UpdateAllCategories(SelectedMenu, CategoriesBinded);
            SelectedCategory = SelectedMenu.Categories[0];
        }

        public void EditCategory()
        {
            if (Utilities.CheckNameValidity(CategoryName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }

            foreach (Category category in SelectedMenu.Categories)
            {
                if (category.Name == CategoryName)
                {
                    MessageBox.Show("The category already exists");
                    return;
                }
            }

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                MessageBox.Show("Can't edit this category");
                return;
            }

            SelectedCategory.Name = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(CategoryName));
            CategoriesBinded.Clear();
            CategoriesBinded = new BindableCollection<Category>(SelectedMenu.Categories);
        }
    }
}

