using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;
using System;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {

        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT * FROM DRINK";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {

                Drink drink = new Drink()
                {
                    DrinkType = dr["DrinkType"].ToString(),
                    IsAlcoholic = (bool)dr["IsAlcoholic"],
                    Stock = (int)dr["Stock"],
                    Price = (decimal)dr["Price"]
                };
                drinks.Add(drink);

            }
            return drinks;
        }

        public string ChangeDrinkValue(string drink, string attribute , string value)
        {
            string query = $"UPDATE DRINK SET {attribute} = @value WHERE DrinkType = @drink";

            //Preventing SQL injections trough parameters
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@value", value),
                new SqlParameter("@drink", drink)
            };

            try
            {
                //Execute the update query
                ExecuteEditQuery(query, sqlParameters);
                return "Update successful";
            }
            catch (Exception e)
            {
                return "Update failed: " + e.Message;
            }
        }

        public string AddNewDrink(string drinkName, bool isAlcoholic, int stock, decimal price, int idCount)
        {
            
            string query = "INSERT INTO DRINK (DrinkID, DrinkType, IsAlcoholic, Stock, Price) VALUES (@DrinkID, @DrinkType, @IsAlcoholic, @Stock, @Price)";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@DrinkID", idCount),

            new SqlParameter("@DrinkType", drinkName),
        
            new SqlParameter("@IsAlcoholic", isAlcoholic ? 1 : 0),

            new SqlParameter("@Stock", stock),

            new SqlParameter("@Price", price)
            };

            try
            {
                //Execute the insert query
                ExecuteEditQuery(query, sqlParameters);
                return "Insert successful";
            }
            catch (Exception e)
            {
                return "Insert failed: " + e.Message;
            }
        }

        public string DeleteDrink(string drink)
        {
            string query = "DELETE FROM DRINK WHERE DrinkType = @drinkType";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@drinkType", drink)
            };

            try
            {
                // Execute the delete query
                ExecuteEditQuery(query, sqlParameters);
                return "Deletion successful";
            }
            catch (Exception e)
            {
                return "Deletion failed: " + e.Message;
            }
        }

    }
}
