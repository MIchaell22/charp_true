using WebApplication1.Interfaces;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.DataAccess
{
    public class PassengersDataAccessLayer : IPassengers
    {
        private string connectionString;
        public PassengersDataAccessLayer(IConfiguration configuration)
        {
            //connectionString = configuration["ConnectionStrings:DefaultConnection"];
            connectionString = myConnection.connectionString;
        }


        //працює виведення
        public IEnumerable<Passengers> GetAllPassengers()
        {
            try
            {
                List<Passengers> lstpassengers = new List<Passengers>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string sqlQuery = "dbo.GetAllPassengers";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                   
                  
                        while (rdr.Read())
                    {

                        Passengers passengers = new Passengers();

                        passengers.IdDeparture = Convert.ToInt32(rdr["ID_departure"]);
                        passengers.IdPassenger = Convert.ToInt32(rdr["ID_passenger"]);
                        passengers.ServiceClass = rdr["Service_class"].ToString();
                        passengers.PassengerLastname = rdr["Passenger_lastname"].ToString();
                        passengers.PassengerName = rdr["Passenger_name"].ToString();

                        lstpassengers.Add(passengers);
                    }
                    con.Close();
                }
                return lstpassengers;
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record 
        public int AddPassengers(Passengers passengers)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sqlQuery = "dbo.AddPassengers";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_departure", passengers.IdDeparture);
                    cmd.Parameters.AddWithValue("@ID_passenger", passengers.IdPassenger);
                    cmd.Parameters.AddWithValue("@Service_class", passengers.ServiceClass);
                    cmd.Parameters.AddWithValue("@Passenger_lastname", passengers.PassengerLastname);
                    cmd.Parameters.AddWithValue("@Passenger_name", passengers.PassengerName);

                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee
        public int UpdatePassengers(Passengers passengers)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sqlQuery = "dbo.UpdatePassengers";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_departure", passengers.IdDeparture);
                    cmd.Parameters.AddWithValue("@ID_passenger", passengers.IdPassenger);
                    cmd.Parameters.AddWithValue("@Service_class", passengers.ServiceClass);
                    cmd.Parameters.AddWithValue("@Passenger_lastname", passengers.PassengerLastname);
                    cmd.Parameters.AddWithValue("@Passenger_name", passengers.PassengerName);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Працює select id
        public Passengers SelectID_departure(int id)
        {
            try
            {
                Passengers passengers = new Passengers();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                   
                    string sqlQuery = "dbo.SelectID_departure";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID",id));

                    SqlDataReader rdr = cmd.ExecuteReader();
                    //https://localhost:44396/api/passengers/Details/1
                    //https://localhost:44396/api/passengers/index
                    //https://localhost:44396/api/passengers/Delete/1
                   //{ "ID_departure":4,"ID_passenger":4,"Service_class":"I","Passenger_lastname":"Панків","Passenger_name":"Олексаедр"}
                    while (rdr.Read())
                    {


                        passengers.IdDeparture = Convert.ToInt32(rdr["ID_departure"]);
                        passengers.IdPassenger = Convert.ToInt32(rdr["ID_passenger"]);
                        passengers.ServiceClass = rdr["Service_class"].ToString();
                        passengers.PassengerLastname = rdr["Passenger_lastname"].ToString();
                        passengers.PassengerName = rdr["Passenger_name"].ToString();
                    }
                }

                return passengers;
            }
            catch
            {
                throw;
            }
        }

        //працює видалення
        public int DellPassengers(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DellPassengers", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    //cmd.Parameters.AddWithValue("@ID_departure", id);

                    
                    cmd.ExecuteNonQuery();
                    //con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }

        }
    }
}

