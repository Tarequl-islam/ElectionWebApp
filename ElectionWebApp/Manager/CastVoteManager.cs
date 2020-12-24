using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectionWebApp.Gateway;
using ElectionWebApp.Models;

namespace ElectionWebApp.Manager
{
    public class CastVoteManager
    {
        CastVoteGateway castVoteGateway = new CastVoteGateway();
        VoterGateway voterGateway = new VoterGateway();
        public List<CastVote> GetAllCandidates()
        {
            return castVoteGateway.GetAllCandidates();
        }

        public List<SelectListItem> GetAllCandidatesForDropdown()
        {
            List<CastVote> candidates = GetAllCandidates();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (CastVote candidate in candidates)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = candidate.SymbolName;
                selectListItem.Value = candidate.SymbolId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        public string Save(CastVote castVote)
        {
            if (voterGateway.IsExist(castVote.VoterId))
            {
                if (castVoteGateway.IsVoted(castVote.VoterId))
                {
                    return "Already Voted By this Id.";
                }
                else
                {
                    int rowEffect = castVoteGateway.Save(castVote);
                    if (rowEffect > 0)
                    {
                        return "Cast Successful";
                    }
                    else
                    {
                        return "Cast Failed";
                    }
                }
            }
            else
            {
                return "Voter ID doesn't Exist. Please Retry...";
            }
        }
    }
}