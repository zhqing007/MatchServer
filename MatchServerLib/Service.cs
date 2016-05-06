using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace MatchServerLib {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MatchService : IService {
        private static MatchData matchD = new MatchData();

        public void InitDic(Dictionary<string, int> dic) {
            matchD.renew();
            foreach (string key in dic.Keys) {
                matchD.AddTeam(key);
                matchD.SetGroNum(key, dic[key]);
            }
        }

        public void DropMatchData() {
            matchD.renew();
        }

        public bool LoginIn(string teamname) {
            return Login(teamname, true);
        }

        public bool LoginOut(string teamname) {
            return Login(teamname, false);
        }

        private bool Login(string teamname, bool flag) {
            return matchD.SetLogin(teamname, flag);
        }

        public string UserLogin(string name, string pw) {
            DataTable teamNameT = DBhelper.ExecuteDataTable(
                "select name from teams where loginname='" + name + "' and password='" + pw + "'", null);
            if (teamNameT.Rows.Count == 0) return null;
            string teamname = teamNameT.Rows[0][0].ToString();
            Login(teamname, true);
            return teamname;
        }

        public void SetDrawResult(string drawnum, int res) {
            matchD.SetGroNum(drawnum, res);
        }

        public Dictionary<string, int> GetDrawResult() {
            return matchD.GetGroNum();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public teaminfodb[] GetTeams() {
            DataTable teamstb = DBhelper.GetTeamsDB();
            teaminfodb[] teams = new teaminfodb[teamstb.Rows.Count];
            for(int i = 0; i < teamstb.Rows.Count; ++i){
                teams[i].Name = teamstb.Rows[i]["name"].ToString();
                teams[i].Description = teamstb.Rows[i]["description"].ToString();
            }
            return teams;
        }


        public int AddTeam(teaminfodb team) {
            if (team.Name == null || team.Name.Trim().Length == 0)
                return 3;

            DataTable teamdt = DBhelper.GetTeamsDB(team.Name);
            if (teamdt.Rows.Count > 0)
                return 2;

            DBhelper.AddTeamDB(team);
            return 1;               
        }


        public void DelTeam(string teamname) {
            DBhelper.DelTeamDB(teamname);
        }


        public int AddMatch(matchinfodb match) {
            if (match.Name == null || match.Name.Trim().Length == 0)
                return 3;

            DataTable matchdt = DBhelper.GetMatchDB(match.Name);
            if (matchdt.Rows.Count > 0)
                return 2;

            DBhelper.AddMatchDB(match);
            return 1; 
        }


        public void AddMatchTeam(string matchn, string teamn) {
            DBhelper.AddMatchTeam(matchn, teamn);
        }


        public matchinfodb[] GetMatchs() {
            DataTable matchstb = DBhelper.GetMatchDB();
            matchinfodb[] matchs = new matchinfodb[matchstb.Rows.Count];
            for (int i = 0; i < matchstb.Rows.Count; ++i) {
                matchs[i].Name = matchstb.Rows[i]["name"].ToString();
                matchs[i].GroupCount = Int32.Parse(matchstb.Rows[i]["groupcount"].ToString());
            }
            return matchs;
        }


        public teaminfodb[] GetMatchTeams(string matchname) {
            DataTable teamstb = DBhelper.GetMatchTeamDB(matchname);
            teaminfodb[] teams = new teaminfodb[teamstb.Rows.Count];
            for (int i = 0; i < teamstb.Rows.Count; ++i) {
                teams[i].Name = teamstb.Rows[i]["teamname"].ToString();
                teams[i].MatchName = teamstb.Rows[i]["matchname"].ToString();
                teams[i].Order = Int32.Parse(teamstb.Rows[i]["ordernum"].ToString());
                teams[i].Group = Int32.Parse(teamstb.Rows[i]["groupnum"].ToString());
            }
            return teams;
        }

        public void SaveMatchTeams(teaminfodb[] teamarray) {
            foreach (teaminfodb teamdb in teamarray) {
                DBhelper.SaveMatchTeamsDB(teamdb);
            }
        }
    }
}
