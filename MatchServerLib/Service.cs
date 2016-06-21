using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace MatchServerLib {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MatchService : IService {
        private static MatchData matchD = new MatchData();

        public TeamStatus[] InitDic(string matchname) {
            matchD.renew();
            DataTable teamnames = DBhelper.GetTeamsDBByMatchName(matchname);
            foreach (string teamname in teamnames.Rows) {                
                DataTable persons = DBhelper.GetPersonsDB(matchname, teamname);
                TeamData td = new TeamData();
                foreach(DataRow prow in persons.Rows){
                    PersonData pd = new PersonData();
                    pd.Num = prow["num"].ToString();
                    pd.Name = prow["name"].ToString();
                    pd.DrawResult = prow["drawreslut"].ToString();
                    td.personD.Add(prow["num"].ToString(), pd);
                }
                matchD.AddTeam(teamname, td);
            }

            return matchD.GetTeamStatus(matchD.GetVer());
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
            LoginIn(teamname);
            return teamname;
        }

        public void SetDraw(string teamname, TeamData drawdata) {
            matchD.SetTeamData(teamname, drawdata);
        }

        public TeamData GetDraw(string teamname) {
            return matchD.GetTeamData(teamname);
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite) {
        //    if (composite == null) {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue) {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public teaminfodb[] GetTeams() {
            DataTable teamstb = DBhelper.GetTeamsDB();
            teaminfodb[] teams = new teaminfodb[teamstb.Rows.Count];
            for(int i = 0; i < teamstb.Rows.Count; ++i){
                teams[i].Name = teamstb.Rows[i]["name"].ToString();
                teams[i].Description = teamstb.Rows[i]["description"].ToString();
                teams[i].Loginname = teamstb.Rows[i]["loginname"].ToString();
                teams[i].Password = teamstb.Rows[i]["password"].ToString();
            }
            return teams;
        }


        public int AddTeam(teaminfodb team) {
            if (team.Name == null || team.Name.Trim().Length == 0)
                return 3;

            DataTable teamdt = DBhelper.GetTeamsDBByName(team.Name);
            if (teamdt.Rows.Count > 0)
                return 2;

            teamdt = DBhelper.GetTeamsDBByLoginName(team.Loginname);
            if (teamdt.Rows.Count > 0)
                return 4;

            DBhelper.AddTeamDB(team);
            return 1; 
        }


        public void DelTeam(string teamname) {
            DBhelper.DelTeamDB(teamname);
        }


        //public int AddMatch(matchinfodb match) {
        //    if (match.Name == null || match.Name.Trim().Length == 0)
        //        return 3;

        //    DataTable matchdt = DBhelper.GetMatchDB(match.Name);
        //    if (matchdt.Rows.Count > 0)
        //        return 2;

        //    DBhelper.AddMatchDB(match);
        //    return 1; 
        //}


        //public void AddMatchTeam(string matchn, string teamn) {
        //    DBhelper.AddMatchTeam(matchn, teamn);
        //}


        public matchinfodb[] GetMatchs() {
            DataTable matchstb = DBhelper.GetMatchDB();
            matchinfodb[] matchs = new matchinfodb[matchstb.Rows.Count];
            for (int i = 0; i < matchstb.Rows.Count; ++i)
                matchs[i].Name = matchstb.Rows[i]["name"].ToString();

            return matchs;
        }


        public teaminfodb[] GetMatchTeams(string matchname) {
            DataTable teamstb = DBhelper.GetMatchTeamDB(matchname);
            teaminfodb[] teams = new teaminfodb[teamstb.Rows.Count];
            for (int i = 0; i < teamstb.Rows.Count; ++i) {
                teams[i].Name = teamstb.Rows[i]["teamname"].ToString();
                teams[i].MatchName = teamstb.Rows[i]["matchname"].ToString();
            }
            return teams;
        }

        //public void SaveMatchTeams(teaminfodb[] teamarray) {
        //    foreach (teaminfodb teamdb in teamarray) {
        //        DBhelper.SaveMatchTeamsDB(teamdb);
        //    }
        //}
        
        public void UpDateTeam(teaminfodb team) {
            DBhelper.UpDateTeamDB(team);
        }


        //public ServerStatus GetServerStatus() {
        //    return matchD.ToTransferData();
        //}


        public void AddPerson(string matchname, string teamname, PersonData perdata) {
            SQLiteParameter[] p = { new SQLiteParameter("@num", perdata.Num),
                                      new SQLiteParameter("@name", perdata.Name),
                                      new SQLiteParameter("@sex", perdata.Sex),
                                      new SQLiteParameter("@matchname", matchname),
                                      new SQLiteParameter("@teamname", teamname)};
            DBhelper.ExecuteSQL("delete from match_team_person where pernum=@num and matchname=@matchname", p);
            DBhelper.ExecuteSQL(@"insert into match_team_person(matchname,teamname,pernum,pername,persex) 
                       values (@matchname,@teamname,@num,@name,@sex)", p);
        }

        public void RemovePerson(string matchname, string teamname, PersonData perdata) {
            if (perdata == null) {
                SQLiteParameter[] p = { new SQLiteParameter("@matchname", matchname),
                                      new SQLiteParameter("@teamname", teamname)};
                DBhelper.ExecuteSQL("delete from match_team_person where matchname=@matchname and teamname=@teamname", p);
                return;
            }

            SQLiteParameter[] p1 = { new SQLiteParameter("@matchname", matchname),
                                      new SQLiteParameter("@num", perdata.Num),
                                      new SQLiteParameter("@teamname", teamname)};
            DBhelper.ExecuteSQL(@"delete from match_team_person where matchname=@matchname and teamname=@teamname
                             and pernum=@num", p1);
        }
    }
}
