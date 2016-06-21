using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Runtime.Serialization;

namespace MatchServerLib {
    public static class DBhelper {
        private static SQLiteConnection sqlconn = null;
        private static SQLiteCommand sqlcmd;
        private static object lockobj = new object();

        static DBhelper() {
            if (sqlconn != null) return;
            sqlconn = new SQLiteConnection("Data Source=e:\\MYCPP\\MatchServer\\matchdb.db;Password=zhqing");
            //sqlconn = new SQLiteConnection("Data Source=D:\\WorkStation\\MatchServer\\matchdb.db;Password=zhqing");
            sqlconn.Open();
            sqlcmd = sqlconn.CreateCommand();
        }

        public static string GetConfiguration(string key) {
            DataTable data = ExecuteDataTable(
                "select value from configuration where key='" + key + "'", null);
            if (data.Rows.Count == 0) return null;
            return data.Rows[0][0].ToString();
        }

        public static void SetConfiguration(string key, string value) {
            ExecuteSQL("update configuration set value='" +
                value + "' where key='" + key + "'");
        }

        public static int userlogin(string name, string psw) {
            DataTable data = ExecuteDataTable(
                "select issuper from institution where loginname='" + name + "' and password='" + psw + "'", null);
            if (data.Rows.Count == 0) return -1;
            return Int32.Parse(data.Rows[0][0].ToString());
        }



        //public static void SaveCpuMemOccupy(Host h, List<ResourcesUtilization> cpuo, List<ResourcesUtilization> memo) {
        //    DateTime now = DateTime.Now;
        //    for (int i = 0; i < cpuo.Count; ++i) {
        //        SQLiteParameter[] p = {new SQLiteParameter("@ip", h.ipaddress)
        //                             , new SQLiteParameter("@sn", cpuo[i].slotname)
        //                             , new SQLiteParameter("@cpu", cpuo[i].s5)
        //                             , new SQLiteParameter("@mem", memo[i].max)
        //                             , new SQLiteParameter("@tt", "m")
        //                             , new SQLiteParameter("@st", now.ToString("yyyy-MM-dd HH:mm:ss"))};
        //        DBhelper.ExecuteSQL("insert into resourceoccupy " + 
        //            "(ipaddress, slotname, cpu, mem, timetype, savetime)" +
        //            "values (@ip, @sn, @cpu, @mem, @tt, @st)", p);
        //    }

        //    LevelUpOccupy(h.ipaddress, cpuo, now, false);
        //    LevelUpOccupy(h.ipaddress, cpuo, now, true);            
        //}

        //private static void LevelUpOccupy(string ip, List<ResourcesUtilization> cpuo, DateTime now, bool today) {
        //    DateTime qt = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

        //    SQLiteParameter[] p1 = new SQLiteParameter[3];
        //    p1[0].ParameterName = "@ip";
        //    p1[0].Value = ip;
        //    p1[1].ParameterName = "@st";
        //    p1[1].Value = qt.ToString("yyyy-MM-dd HH:mm:ss");
        //    string timetype = today ? "h" : "m";

        //    foreach (ResourcesUtilization ru in cpuo) {
        //        p1[0].ParameterName = "@sl";
        //        p1[0].Value = ru.slotname;
        //        DataTable reso = DBhelper.ExecuteDataTable("select * from resourceoccupy where ipaddress=@ip " +
        //            "and slotname=@sl and timetype ='" + timetype + "' and savetime<@st", p1);
        //        if (reso.Rows.Count == 0) continue;
        //        int cpuoccupy = 0, memoccupy = 0;
        //        foreach (DataRow row in reso.Rows) {
        //            cpuoccupy += Int32.Parse(row["cpu"].ToString());
        //            memoccupy += Int32.Parse(row["mem"].ToString());
        //        }

        //        DBhelper.ExecuteSQL("delete from resourceoccupy where ipaddress=@ip " +
        //            "and slotname=@sl and timetype ='" + timetype + "' and savetime<@st", p1);

        //        SQLiteParameter[] p2 = {new SQLiteParameter("@ip", ip)
        //                              , new SQLiteParameter("@sn", ru.slotname)
        //                              , new SQLiteParameter("@cpu", cpuoccupy / reso.Rows.Count)
        //                              , new SQLiteParameter("@mem", memoccupy / reso.Rows.Count)
        //                              , new SQLiteParameter("@tt", today ? "d" : "h")
        //                              , new SQLiteParameter("@st", now.ToString("yyyy-MM-dd HH:mm:ss"))};
        //        DBhelper.ExecuteSQL("insert into resourceoccupy " +
        //            "(ipaddress, slotname, cpu, mem, timetype, savetime)" +
        //            "values (@ip, @sn, @cpu, @mem, @tt, @st)", p2);
        //    }
        //}

        public static DataTable GetCpuMemOccupy( DateTime begintime, DateTime endtime) {
            SQLiteParameter[] p = {new SQLiteParameter("@bt", begintime.ToString("yyyy-MM-dd HH:mm:ss"))
                                      , new SQLiteParameter("@et", endtime.ToString("yyyy-MM-dd HH:mm:ss"))};
            DataTable reso = DBhelper.ExecuteDataTable("select * from resourceoccupy where ipaddress=@ip " +
                    "and timetype ='d' and savetime>=@bt and savetime<@et", p);
            reso.TableName = "CpuMemOccupy";
            return reso;
        }

        public static void SaveDeviceConfiguration(string conf) {
            SQLiteParameter[] p = {new SQLiteParameter("@conf", conf)};

            DataTable deconf = ExecuteDataTable(
                "select max(savetime) from deviceconfiguration where ipaddress=@ip and configuration=@conf", p);
            DateTime savedate = DateTime.Now;
            DateTime checkdate = DateTime.Now;

            if (deconf.Rows.Count == 0) {
                SQLiteParameter[] p1 = {new SQLiteParameter("@st", savedate.ToString("yyyy-MM-dd HH:mm:ss"))
                                      , new SQLiteParameter("@co", conf)};
                DBhelper.ExecuteSQL("insert into deviceconfiguration (ipaddress, savetime, configuration) values (@ip, @st, @co)", p1);
            }
            else {
                savedate = (DateTime)(deconf.Rows[0][0]);
            }

            SQLiteParameter[] p2 = {new SQLiteParameter("@st", savedate.ToString("yyyy-MM-dd HH:mm:ss"))
                                       , new SQLiteParameter("@ct", checkdate.ToString("yyyy-MM-dd HH:mm:ss"))};
            DBhelper.ExecuteSQL("insert into devconfdate (ipaddress, savedate, checkdate) values (@ip, @st, @ct)", p2);
        }

        public static DataTable GetMatchTeamDB(string matchname) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", matchname) };
            return ExecuteDataTable(@"select matchname,teamname from match_team_person 
                       where matchname = @name group by teamname", p);
        }

        //public static void SaveMatchTeamsDB(teaminfodb team) {
        //    SQLiteParameter[] p = { new SQLiteParameter("@tn", team.Name),
        //                          new SQLiteParameter("@mn", team.MatchName),
        //                          new SQLiteParameter("@or", team.Order),
        //                          new SQLiteParameter("@gr", team.Group)};
        //    ExecuteSQL("update matchteam set ordernum=@or, groupnum=@gr where matchname=@mn and teamname=@tn", p);
        //}

        public static DataTable GetTeamsDBByMatchName(string mname) {
            SQLiteParameter[] p = { new SQLiteParameter("@mname", mname) };
            return ExecuteDataTable("select teamname from match_team_person where matchname = @mname group by teamname", p);
        }

        public static DataTable GetPersonsDB(string mname, string tname) {
            SQLiteParameter[] p = { new SQLiteParameter("@mname", mname),
                                  new SQLiteParameter("@tname", tname)};
            return ExecuteDataTable(@"select b.num as num,b.name as name,a.drawreslut as drawreslut
                      from match_team_person a,persons b
                      where a.pernum=b.num and a.matchname=@mname and a.teamname=@tname", p);
        }

        public static DataTable GetTeamsDBByName(string name) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", name) };
            return ExecuteDataTable("select * from teams where name = @name", p);
        }

        public static DataTable GetTeamsDBByLoginName(string loginame) {
            SQLiteParameter[] p = { new SQLiteParameter("@login", loginame) };
            return ExecuteDataTable("select * from teams where loginname = @login", p);
        }

        public static DataTable GetTeamsDB() {
            return ExecuteDataTable("select * from teams", null);
        }

        public static DataTable GetMatchDB(string name) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", name) };
            return ExecuteDataTable("select * from matchinfo where name = @name", p);
        }

        public static DataTable GetMatchDB() {
            return ExecuteDataTable("select matchname as name from match_team_person group by matchname", null);
        }

        public static void AddTeamDB(teaminfodb team) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", team.Name),
                                      new SQLiteParameter("@desc", team.Description),
                                      new SQLiteParameter("@login", team.Loginname),
                                      new SQLiteParameter("@pw", team.Password)};
            ExecuteSQL("insert into teams (name,description,loginname,password) values (@name,@desc,@login,@pw)", p);
        }

        public static void UpDateTeamDB(teaminfodb team) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", team.Name),
                                      new SQLiteParameter("@desc", team.Description),
                                      new SQLiteParameter("@login", team.Loginname),
                                      new SQLiteParameter("@pw", team.Password)};
            ExecuteSQL("update teams set description=@desc,loginname=@login,password=@pw where name=@name", p);
        }

        //public static void AddMatchDB(matchinfodb match) {
        //    SQLiteParameter[] p = { new SQLiteParameter("@name", match.Name),
        //                              new SQLiteParameter("@gc", match.GroupCount)};
        //    ExecuteSQL("insert into matchinfo (name, groupcount) values (@name, @gc)", p);
        //}

        //public static void AddMatchTeam(string matchname, string teamname) {
        //    SQLiteParameter[] p = { new SQLiteParameter("@mn", matchname),
        //                              new SQLiteParameter("@tn", teamname)};
        //    ExecuteSQL("insert into matchteam (matchname, teamname) values (@mn, @tn)", p);
        //}

        public static void DelTeamDB(string teamname) {
            SQLiteParameter[] p = { new SQLiteParameter("@name", teamname)};
            ExecuteSQL("delete from teams where name = @name", p);
        }

        public static void SetDefaultUpLoadServer(string ser) {
            SetConfiguration("default_upload_server", ser);
        }

        public static void ExecuteSQL(string sql) {
            ExecuteSQL(sql, null);
        }

        public static void ExecuteSQL(string sql, SQLiteParameter[] parameters) {
            lock (lockobj) {
                sqlcmd.CommandText = sql;
                if (parameters != null) {
                    sqlcmd.Parameters.AddRange(parameters);
                }
                sqlcmd.ExecuteNonQuery();
            }
        }

        public static SQLiteDataReader ExecuteReader(string sql, SQLiteParameter[] parameters) {
            lock (lockobj) {
                sqlcmd.CommandText = sql;
                if (parameters != null) {
                    sqlcmd.Parameters.AddRange(parameters);
                }
                return sqlcmd.ExecuteReader();
            }
        }

        public static DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters) {
            lock (lockobj) {
                sqlcmd.CommandText = sql;
                if (parameters != null) {
                    sqlcmd.Parameters.AddRange(parameters);
                }
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlcmd);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        //internal static DataTable GetPersonByNum(string pernum) {
        //    SQLiteParameter[] p = { new SQLiteParameter("@num", pernum) };
        //    return ExecuteDataTable("select * from persons where num = @num", p);
        //}

        internal static void AddPerson(PersonData perdata) {
            SQLiteParameter[] p = { new SQLiteParameter("@num", perdata.Num),
                                      new SQLiteParameter("@name", perdata.Name),
                                      new SQLiteParameter("@sex", perdata.Sex)};
            ExecuteSQL("insert into persons (num,name,sex) values (@num,@name,@sex)", p);
        }
    }
}
