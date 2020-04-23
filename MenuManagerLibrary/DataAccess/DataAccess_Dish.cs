using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace MenuManagerLibrary.DataAccess
{
    public class DataAccess_Dish
    {
        public List<Dish> DishToDB(List<Dish> dishes) 
        {
           //Connecting to SQL server
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DataAccess.CnnVal("RestaurantDB"))) 
            {
                var output = connection.Query<Dish>($"select * from allDishes").ToList();
                return output;
            }
        }
    }
}
