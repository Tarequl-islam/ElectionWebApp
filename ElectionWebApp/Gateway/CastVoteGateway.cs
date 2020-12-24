using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ElectionWebApp.Models;

namespace ElectionWebApp.Gateway
{
    public class CastVoteGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public CastVoteGateway()
        {
            connectionString = WebConfigurationManager.
                    ConnectionStrings["ElectionDD"].
                    ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public List<CastVote> GetAllCandidates()
        {
            string query = "SELECT * FROM Candidate";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<CastVote> candidateList = new List<CastVote>();
            while (reader.Read())
            {
                CastVote candidate = new CastVote();
                candidate.SymbolId = Convert.ToInt32(reader["Id"]);
                candidate.SymbolName = reader["Symbol"].ToString();
                candidateList.Add(candidate);

            }
            connection.Close();
            return candidateList;
        }
        public int Save(CastVote castVote)
        {
            string query = "INSERT INTO VoteResult(VoterId, SymbolId) VALUES(@VoterId, @SymbolId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VoterId", castVote.VoterId);
            command.Parameters.AddWithValue("@SymbolId", castVote.SymbolId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsVoted(int id)
        {
            string query = "SELECT * FROM VoteResult WHERE VoterId = @VoterId";
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