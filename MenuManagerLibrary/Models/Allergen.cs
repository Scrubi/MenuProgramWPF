//using System;
//using System.Collections.Generic;
//using System.Text;

namespace MenuManagerLibrary.Models
{
    public class Allergen
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Allergen(string name)
		{
			this.Name = name;
		}


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Allergen))
            {
                return false;
            }

            if (this.Name == ((Allergen)obj).Name)
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
