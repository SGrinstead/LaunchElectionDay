using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchElectionDay.UnitTests
{
    public class RaceTest
    {
        [Fact]
        public void Race_Constructor_CreatesRaceObject()
        {
            Race denverMayoral = new Race("Denver");

            Assert.Equal("Denver", denverMayoral.Office);
            Assert.Equal(new List<Candidate>(), denverMayoral.Candidates);
            Assert.True(denverMayoral.IsOpen);
        }

        [Fact]
        public void Race_RegisterCandidate()
        {
            Candidate diana = new Candidate("Diana", "Democrat");
            Race denverMayoral = new Race("Denver");

            denverMayoral.RegisterCandidate(diana);

            Assert.Equal(diana, denverMayoral.Candidates[0]);

        }

        [Fact]
        public void Race_Close_SetsIsOpenToFalse()
        {
            Race denverMayoral = new Race("Denver");
            denverMayoral.Close();
            Assert.False(denverMayoral.IsOpen);
        }

        [Fact]
        public void Race_GetWinner_ReturnsFalseOrCandidate()
        {
            Race denverMayoral = new Race("Denver");
            Candidate diana = new Candidate("Diana", "Democrat");
            Candidate john = new Candidate("John Governor", "Government");
            diana.VoteFor();
            diana.VoteFor();
            john.VoteFor();
            denverMayoral.RegisterCandidate(diana);
            denverMayoral.RegisterCandidate(john);

            Assert.False(denverMayoral.GetWinner());

            denverMayoral.Close();
            Assert.Equal(diana, denverMayoral.GetWinner());
        }

        [Fact]
        public void Race_IsTie_ReturnsBoolOfTie()
        {
            Race denverMayoral = new Race("Denver");
            Candidate diana = new Candidate("Diana", "Democrat");
            Candidate john = new Candidate("John Governor", "Government");
            diana.VoteFor();
            diana.VoteFor();
            john.VoteFor();
            denverMayoral.RegisterCandidate(diana);
            denverMayoral.RegisterCandidate(john);
            denverMayoral.Close();

            Assert.False(denverMayoral.IsTie());
            denverMayoral.Candidates[1].VoteFor();
            Assert.True(denverMayoral.IsTie());
        }










    }
}
