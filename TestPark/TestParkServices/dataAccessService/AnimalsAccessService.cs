using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestParkServices.Models;

namespace TestParkServices.dataAccessService
{
    public class AnimalsAccessService
    {
       /* private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IEnumerable<Animals>getAllAnimals()
        {
            List<Animals> myAnimalsList = new List<Animals>();

            string query = "Select * from Animaux ";
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Animals a = new Animals();
                    a.AId =reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.DateOfBirth = reader.GetDateTime(2);
                    myAnimalsList.Add(a);

                }
                return myAnimalsList;
            }

            
        }*/
    }
}