﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatchClient.MatchService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="teaminfodb", Namespace="http://schemas.datacontract.org/2004/07/MatchServerLib")]
    [System.SerializableAttribute()]
    public partial struct teaminfodb : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GroupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MatchNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Group {
            get {
                return this.GroupField;
            }
            set {
                if ((this.GroupField.Equals(value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MatchName {
            get {
                return this.MatchNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MatchNameField, value) != true)) {
                    this.MatchNameField = value;
                    this.RaisePropertyChanged("MatchName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Order {
            get {
                return this.OrderField;
            }
            set {
                if ((this.OrderField.Equals(value) != true)) {
                    this.OrderField = value;
                    this.RaisePropertyChanged("Order");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="matchinfodb", Namespace="http://schemas.datacontract.org/2004/07/MatchServerLib")]
    [System.SerializableAttribute()]
    public partial struct matchinfodb : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GroupCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GroupCount {
            get {
                return this.GroupCountField;
            }
            set {
                if ((this.GroupCountField.Equals(value) != true)) {
                    this.GroupCountField = value;
                    this.RaisePropertyChanged("GroupCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MatchServerLib")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MatchService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTeams", ReplyAction="http://tempuri.org/IService/GetTeamsResponse")]
        MatchClient.MatchService.teaminfodb[] GetTeams();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetMatchTeams", ReplyAction="http://tempuri.org/IService/GetMatchTeamsResponse")]
        MatchClient.MatchService.teaminfodb[] GetMatchTeams(string matchname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SaveMatchTeams", ReplyAction="http://tempuri.org/IService/SaveMatchTeamsResponse")]
        void SaveMatchTeams(MatchClient.MatchService.teaminfodb[] teamarray);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetMatchs", ReplyAction="http://tempuri.org/IService/GetMatchsResponse")]
        MatchClient.MatchService.matchinfodb[] GetMatchs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddTeam", ReplyAction="http://tempuri.org/IService/AddTeamResponse")]
        int AddTeam(MatchClient.MatchService.teaminfodb team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMatch", ReplyAction="http://tempuri.org/IService/AddMatchResponse")]
        int AddMatch(MatchClient.MatchService.matchinfodb match);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMatchTeam", ReplyAction="http://tempuri.org/IService/AddMatchTeamResponse")]
        void AddMatchTeam(string matchn, string teamn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DelTeam", ReplyAction="http://tempuri.org/IService/DelTeamResponse")]
        void DelTeam(string teamname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        MatchClient.MatchService.CompositeType GetDataUsingDataContract(MatchClient.MatchService.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : MatchClient.MatchService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<MatchClient.MatchService.IService>, MatchClient.MatchService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public MatchClient.MatchService.teaminfodb[] GetTeams() {
            return base.Channel.GetTeams();
        }
        
        public MatchClient.MatchService.teaminfodb[] GetMatchTeams(string matchname) {
            return base.Channel.GetMatchTeams(matchname);
        }
        
        public void SaveMatchTeams(MatchClient.MatchService.teaminfodb[] teamarray) {
            base.Channel.SaveMatchTeams(teamarray);
        }
        
        public MatchClient.MatchService.matchinfodb[] GetMatchs() {
            return base.Channel.GetMatchs();
        }
        
        public int AddTeam(MatchClient.MatchService.teaminfodb team) {
            return base.Channel.AddTeam(team);
        }
        
        public int AddMatch(MatchClient.MatchService.matchinfodb match) {
            return base.Channel.AddMatch(match);
        }
        
        public void AddMatchTeam(string matchn, string teamn) {
            base.Channel.AddMatchTeam(matchn, teamn);
        }
        
        public void DelTeam(string teamname) {
            base.Channel.DelTeam(teamname);
        }
        
        public MatchClient.MatchService.CompositeType GetDataUsingDataContract(MatchClient.MatchService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
    }
}
