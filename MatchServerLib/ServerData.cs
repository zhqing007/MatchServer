using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchServerLib {
    public class TeamData {
        public int gronum;
        public bool islogined;

        public TeamData(int num = -1, bool login = false) {
            gronum = num;
            islogined = login;
        }
    }

    public class MatchData {
        private static Dictionary<string, TeamData> matchD;

        public MatchData() {
            matchD = new Dictionary<string, TeamData>();
        }

        public void renew() {
            matchD.Clear();
        }

        public void AddTeam(string teamname, TeamData d) {
            matchD.Add(teamname, d);
        }

        public void AddTeam(string teamname) {
            TeamData d = new TeamData();
            matchD.Add(teamname, d);
        }

        public bool SetGroNum(string teamname, int num) {
            if (!matchD.ContainsKey(teamname))
                return false;
            matchD[teamname].gronum = num;
            return true;
        }

        public bool SetLogin(string teamname, bool log) {
            if (!matchD.ContainsKey(teamname))
                return false;
            matchD[teamname].islogined = log;
            return true;
        }

        public TeamData GetTeam(string teamname) {
            if (!matchD.ContainsKey(teamname))
                return null;
            return matchD[teamname];
        }

        public bool IsLogined(string teamname) {
            if(!matchD.ContainsKey(teamname))
                return false;
            return matchD[teamname].islogined;
        }

        public int GetGroNum(string teamname) {
            if (!matchD.ContainsKey(teamname))
                return -1;
            return matchD[teamname].gronum;
        }

        public Dictionary<string, int> GetGroNum() {
            Dictionary<string, int> numDic = new Dictionary<string, int>();
            foreach (string key in matchD.Keys) {
                numDic.Add(key, matchD[key].gronum);
            }

            return numDic;
        }

    }


}
