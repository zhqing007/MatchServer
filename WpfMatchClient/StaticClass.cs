using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfMatchClient.MatchService;

namespace WpfMatchClient {
    class StaticClass {
        public static ServiceClient serviceClient = new ServiceClient();
    }

    public class teaminfo {
        string name;
        string matchname;
        int order;
        int group;
        string description;

        public teaminfo(teaminfodb tinfodb) {
            name = tinfodb.Name;
            matchname = tinfodb.MatchName;
            order = tinfodb.Order;
            group = tinfodb.Group;
            description = tinfodb.Description;
        }

        public teaminfodb ToDB() {
            teaminfodb teamdb = new teaminfodb();
            teamdb.Name = name;
            teamdb.MatchName = matchname;
            teamdb.Order = order;
            teamdb.Group = group;
            return teamdb;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string MatchName {
            get { return matchname; }
            set { matchname = value; }
        }

        public int Order {
            get { return order; }
            set { order = value; }
        }

        public int Group {
            get { return group; }
            set { group = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public override string ToString() {
            return name;
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
