using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionWebApp.Gateway;
using ElectionWebApp.Models;

namespace ElectionWebApp.Manager
{
    public class CandidateManager
    {
        CandidateGateway candidateGateway =new CandidateGateway();

        public string Save(Candidate candidate)
        {
            if (candidateGateway.IsExist(candidate.Name , candidate.Symbol))
            {
                return "Candidate or Symbol is already Exist. Please Retry...";
            }
            else
            {
                int rowEffect = candidateGateway.Save(candidate);
                if (rowEffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }
        public List<Candidate> GetResultCandidates()
        {
            return candidateGateway.GetResultCandidates();
        }

    }
}