using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchServerLib {
    public class TeamData {
        public int gronum;
        public bool islogined;
    }

    public class MatchData {
        private static Dictionary<string, TeamData> matchD;

        public MatchData() {
            matchD = new Dictionary<string, TeamData>();
        }

        public void AddTeam(string teamname, TeamData d) {
            matchD.Add(teamname, d);
        }

        public TeamData GetTeam(string teamname) {
            return matchD[teamname];
        }

        public bool IsLogined(string teamname) {
            TeamData td = matchD[teamname];
            if (td == null) return false;
            return td.islogined;
        }

        public int GetGroNum(string teamname) {
            TeamData td = matchD[teamname];
            if (td == null) return -1;
            return td.gronum;
        }

    }


}
