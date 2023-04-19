using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Race
    {
        public string Office;
        public List<Candidate> Candidates;
        public bool IsOpen;

        public Race(string office)
        {
            Office = office;
            Candidates = new List<Candidate>();
            IsOpen = true;
        }

        public void RegisterCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public bool GetIsOpen()
        {
            return IsOpen;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public dynamic GetWinner()
        {
            Candidate winner = new Candidate("No Votes", "No Party");
            if (IsOpen)
            {
                return false;
            }
            else
            {
                foreach(var candidate in Candidates)
                {
                    if(candidate.Votes > winner.Votes)
                    {
                        winner = candidate;
                    }
                }
                return winner;
            }
        }

        public bool IsTie()
        {
            int count = 0;
            Candidate winner = GetWinner();
            foreach(var candidate in Candidates)
            {
                if (winner.Votes == candidate.Votes) count++;
            }
            if (count >= 2)
            {
                return true;
            }
            else return false;
        }




    }

    
}
