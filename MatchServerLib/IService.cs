using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MatchServerLib {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService {
        [OperationContract]
        void InitDic(Dictionary<string, int> dic);

        [OperationContract]
        void DropMatchData();

        [OperationContract]
        void LoginIn(string teamname);

        [OperationContract]
        void LoginOut(string teamname);

        [OperationContract]
        void SetDrawResult(string drawnum, int res);

        [OperationContract]
        Dictionary<string, int> GetDrawResult();

        [OperationContract]
        teaminfodb[] GetTeams();

        [OperationContract]
        teaminfodb[] GetMatchTeams(string matchname);

        [OperationContract]
        void SaveMatchTeams(teaminfodb[] teamarray);

        [OperationContract]
        matchinfodb[] GetMatchs();

        [OperationContract]
        //1:成功；2：重名；3：参数非法 
        int AddTeam(teaminfodb team);

        [OperationContract]
        //1:成功；2：重名；3：参数非法 
        int AddMatch(matchinfodb match);

        [OperationContract]
        void AddMatchTeam(string matchn, string teamn);

        [OperationContract]
        void DelTeam(string teamname);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: 在此添加您的服务操作
    }

    // 使用下面示例中说明的数据协定将复合类型添加到服务操作
    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public struct teaminfodb {
        string name;
        string matchname;
        int order;
        int group;
        string description;

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string MatchName {
            get { return matchname; }
            set { matchname = value; }
        }

        [DataMember]
        public int Order {
            get { return order; }
            set { order = value; }
        }

        [DataMember]
        public int Group {
            get { return group; }
            set { group = value; }
        }

        [DataMember]
        public string Description {
            get { return description; }
            set { description = value; }
        }
    }

    [DataContract]
    public struct matchinfodb {
        string name;
        int groupcount;

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int GroupCount {
            get { return groupcount; }
            set { groupcount = value; }
        }
    }


}
