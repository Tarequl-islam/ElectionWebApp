using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ElectionWebApp.Models;

namespace ElectionWebApp.Gateway
{
    public class CandidateGateway
    {
            private string connectionString;
            private SqlConnection connection;
            private SqlDataReader reader;

            public CandidateGateway()
            {
                connectionString = WebConfigurationManager.
                        ConnectionStrings["ElectionDD"].
                        ConnectionString;
                connection = new SqlConnection(connectionString);
            }
            public int Save(Candidate candidate)
            {
                string query = "INSERT INTO Candidate(Name, Symbol) VALUES(@Name, @Symbol)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", candidate.Name);
                command.Parameters.AddWithValue("@Symbol", candidate.Symbol);
                connection.Open();
                int rowAffect = command.ExecuteNonQuery();
                connection.Close();
                return rowAffect;
            }
            public bool IsExist(string name , string symbol)
            {
                string query = "SELECT * FROM Candidate WHERE Name = @Name OR  Symbol = @Symbol";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Symbol", symbol);
                connection.Open();
                reader = command.ExecuteReader();
                bool isExist = reader.HasRows;
                connection.Close();
                return isExist;
            }


            public List<Candidate> GetResultCandidates()
            {
                string query = "SELECT Candidate.Name, Candidate.Symbol, COUNT(*)Vote FROM VoteResult INNER JOIN Candidate ON Candidate.Id=VoteResult.SymbolId GROUP BY Candidate.Name, Candidate.Symbol ORDER BY COUNT(*) DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                reader = command.ExecuteReader();
                List<Candidate> candidateList = new List<Candidate>();
                while (reader.Read())
                {
                    Candidate candidate = new Candidate();
                    candidate.Name = reader["Name"].ToString();
                    candidate.Symbol = reader["Symbol"].ToString();
                    candidate.Vote = Convert.ToInt32(reader["Vote"]);
                    candidateList.Add(candidate);
                }
                connection.Close();
                return candidateList;
            }

    }
}