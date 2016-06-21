using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfMatchClient.MatchService;

namespace WpfMatchClient {
    class StaticClass {
        public static ServiceClient serviceClient = new ServiceClient();
        public static bool isclosed = false;
    }

    public class teaminfo {
        teaminfodb tinfodb;

        public teaminfo(teaminfodb _tinfodb) {
            tinfodb = _tinfodb;
        }

        public teaminfodb ToDB() {
            return tinfodb;
        }

        public string Name {
            get { return tinfodb.Name; }
            set { tinfodb.Name = value; }
        }

        public string MatchName {
            get { return tinfodb.MatchName; }
            set { tinfodb.MatchName = value; }
        }

        public int Order {
            get { return tinfodb.Order; }
            set { tinfodb.Order = value; }
        }

        public int Group {
            get { return tinfodb.Group; }
            set { tinfodb.Group = value; }
        }

        public string Description {
            get { return tinfodb.Description; }
            set { tinfodb.Description = value; }
        }

        public string Loginname {
            get { return tinfodb.Loginname; }
            set { tinfodb.Loginname = value; }
        }

        public string Password {
            get { return tinfodb.Password; }
            set { tinfodb.Password = value; }
        }

        public override string ToString() {
            return tinfodb.Name;
        }
    }

    public class matchinfo {
        string name;
        int groupcount;

        public matchinfo(matchinfodb minfodb) {
            name = minfodb.Name;
            groupcount = minfodb.GroupCount;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int GroupCount {
            get { return groupcount; }
            set { groupcount = value; }
        }

        public override string ToString() {
            return name;
        }
    }
}
