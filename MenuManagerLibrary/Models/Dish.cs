using System;
using System.Collections.Generic;
//using System.Text;
//using Caliburn.Micro;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class Dish
    {
        private string _name;
        private string _description;
        private double _price;
        private List<Allergen> _allergens;

        public List<Allergen> Allergens
        {
            get { return _allergens; }
            set { _allergens = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        
        public Dish(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Allergens = new List<Allergen>();
        }

        public string AllDishesInfo 
        {
            get 
            {
                return $"{ Name } { Description } { Price }";
            }
        }
       
        
        public override string ToString()
        {
            return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if(!(obj is Dish))
            {
                return false;
            }

            if (this.Name == ((Dish)obj).Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
