using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay
{
    public class Election
    {
        public string Year;
        public List<Race> Races;

        public Election(string year)
        {
            Year = year;
            Races = new List<Race>();
        }

        public List<Race> GetRaces()
        {
            return Races;
        }

        public void AddRace(Race race)
        {
            Races.Add(race);
        }

        public List<Candidate> GetAllCandidates()
        {
            List<Candidate> candidates = new List<Candidate>();
            foreach(var race in Races)
            {
                candidates.AddRange(race.Candidates);
            }
            return candidates;
        }

        public Dictionary<string,int> GetVoteCounts()
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();
            List<Candidate> totalCandidates = GetAllCandidates();
            foreach(var candidate in totalCandidates)
            {
                votes.Add(candidate.Name, candidate.Votes);
            }
            return votes;
        }
    }
}
