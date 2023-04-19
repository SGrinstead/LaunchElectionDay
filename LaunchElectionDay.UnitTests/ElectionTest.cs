using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class ElectionTest
    {
        [Fact]
        public void Election_Constructor_MakesObject()
        {
            Election colorado = new Election("2023");

            Assert.Equal("2023", colorado.Year);
            Assert.Equal(new List<Race>(), colorado.Races);
        }

        [Fact]
        public void Election_GetRaces_ReturnsListOfRaces()
        {
            Election colorado = new Election("2023");
            Race denverMayoral = new Race("Denver");
            Race denverGubernatorial = new Race("Governer");
            colorado.AddRace(denverMayoral);
            colorado.AddRace(denverGubernatorial);

            Assert.Equal(2, colorado.GetRaces().Count);
        }

        [Fact]
        public void Election_GetAllCandidates_ReturnsListOfCandidates()
        {
            Election colorado = new Election("2023");
            Race denverMayoral = new Race("Denver");
            denverMayoral.RegisterCandidate(new Candidate("Diana D", "Democrat"));
            Race denverGubernatorial = new Race("Governer");
            denverGubernatorial.RegisterCandidate(new Candidate("John Governor", "Government"));
            colorado.AddRace(denverMayoral);
            colorado.AddRace(denverGubernatorial);

            var candidates = colorado.GetAllCandidates();
            Assert.Equal(2, candidates.Count);
        }

        [Fact]
        public void Election_GetVoteCounts_ReturnsDictionaryWithNamesAndVotes()
        {
            Election colorado = new Election("2023");
            Race denverMayoral = new Race("Denver");

            Candidate diana = new Candidate("Diana D", "Democrat");
            diana.VoteFor();
            diana.VoteFor();

            denverMayoral.RegisterCandidate(diana);
            Race denverGubernatorial = new Race("Governer");

            Candidate john = new Candidate("John Governor", "Government");
            john.VoteFor();

            denverGubernatorial.RegisterCandidate(john);
            colorado.AddRace(denverMayoral);
            colorado.AddRace(denverGubernatorial);

            var voteCounts = colorado.GetVoteCounts();

            Assert.Equal(2, voteCounts["Diana D"]);
            Assert.Equal(1, voteCounts["John Governor"]);
        }
    }
}
