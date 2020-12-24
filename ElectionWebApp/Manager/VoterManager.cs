using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectionWebApp.Gateway;
using ElectionWebApp.Models;

namespace ElectionWebApp.Manager
{
    public class VoterManager
    {
        VoterGateway voterGateway = new VoterGateway();

        public string Save(Voter voter)
        {
            if (voterGateway.IsExist(voter.VoterId))
            {
                return "Voter ID is already Exist. Please Retry...";
            }
            else
            {
                int rowEffect = voterGateway.Save(voter);
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
    }
}