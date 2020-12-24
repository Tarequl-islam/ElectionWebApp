using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ElectionWebApp.Models;

namespace ElectionWebApp.Gateway
{
    public class VoterGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public VoterGateway()
        {
            connectionString = WebConfigurationManager.
                    ConnectionStrings["ElectionDD"].
                    ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(Voter voter)
        {
            string query = "INSERT INTO Voter(Name, VoterNID) VALUES(@Name, @VoterId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", voter.Name);
            command.Parameters.AddWithValue("@VoterId", voter.VoterId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsExist(int id)
        {
            string query = "SELECT * FROM Voter WHERE VoterNID = @VoterId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VoterId", id);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }
    }
}