using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MatchServerLib {
    [DataContract]
    public class PersonData {
        string name;
        string num;
        string sex;
        string drawresult;

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Num {
            get { return num; }
            set { num = value; }
        }

        [DataMember]
        public string Sex {
            get { return sex; }
            set { sex = value; }
        }

        [DataMember]
        public string DrawResult {
            get { return drawresult; }
            set { drawresult = value; }
        }
    }

    [DataContract]
    public struct TeamStatus {
        //team登录状态
        string teamname;
        bool islogined;

        [DataMember]
        public string TeamName {
            get { return teamname; }
            set { teamname = value; }
        }

        [DataMember]
        public bool Islogined {
            get { return islogined; }
            set { islogined = value; }
        }
    }

    [DataContract]
    public class TeamData {
        public string teamname;
        public int status;  //0：等待；1：主控已发出抽签请求；2：抽签完毕。
        public bool islogined;
        public Dictionary<string, PersonData> personD;
        //string: 身份证号
        //int: 抽签结果　为#号时未分组 对应cardD

        public string[] cardD;  //卡签号卡面信息 
        public string cardInfo;  //卡签其它信息

        public TeamData(int sta = 0, bool login = false) {
            status = sta;
            islogined = login;
            personD = new Dictionary<string, PersonData>();
        }

        [DataMember]
        public Dictionary<string, PersonData> DrawInfo {
            get { return personD; }
            set { personD = value; }
        }

        [DataMember]
        public string[] CardD {
            get { return cardD; }
            set { cardD = value; }
        }

        [DataMember]
        public string CardInfo {
            get { return cardInfo; }
            set { cardInfo = value; }
        }

        [DataMember]
        public string TeamName {
            get { return teamname; }
            set { teamname = value; }
        }
    }

    public class MatchData {
        Dictionary<string, TeamData> teamD;
        uint ver;

        public MatchData() {
            teamD = new Dictionary<string, TeamData>();
            ver = 0;
        }

        public void UpdateVer() { ++ver; }

        public uint GetVer() { return ver; }

        public void renew() {
            teamD.Clear();
            ver = 0;
        }

        public void AddTeam(string teamname, TeamData d) {
            teamD.Add(teamname, d);
        }

        public void AddTeam(string teamname) {
            TeamData d = new TeamData();
            teamD.Add(teamname, d);
        }

        public TeamData GetTeamData(string teamname) {
            if (!teamD.ContainsKey(teamname))
                return null;
            return teamD[teamname];
        }

        public void SetTeamData(string teamname, TeamData td) {
            teamD[teamname].personD = td.personD;
            teamD[teamname].cardD = td.cardD;
            teamD[teamname].cardInfo = td.cardInfo;
        }

        public bool SetLogin(string teamname, bool log) {
            if (!teamD.ContainsKey(teamname))
                return false;
            teamD[teamname].islogined = log;
            UpdateVer();
            return true;
        }       

        public bool IsLogined(string teamname) {
            if(!teamD.ContainsKey(teamname))
                return false;
            return teamD[teamname].islogined;
        }

        public TeamStatus[] GetTeamStatus(uint _ver) {
            if (ver == _ver) return null;
            TeamStatus[] teams = new TeamStatus[teamD.Count];
            int i = 0;
            foreach (string teamname in teamD.Keys) {
                teams[i].TeamName = teamname;
                teams[i].Islogined = teamD[teamname].islogined;
                ++i;
            }
            return teams;
        }
    }
}
