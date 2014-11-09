﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TwitterModel", Namespace="http://schemas.datacontract.org/2004/07/restFullData")]
    [System.SerializableAttribute()]
    public partial class TwitterModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProfileImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> PublishedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string screen_nameField;
        
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
        public string AuthorName {
            get {
                return this.AuthorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorNameField, value) != true)) {
                    this.AuthorNameField = value;
                    this.RaisePropertyChanged("AuthorName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthorUrl {
            get {
                return this.AuthorUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorUrlField, value) != true)) {
                    this.AuthorUrlField = value;
                    this.RaisePropertyChanged("AuthorUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProfileImage {
            get {
                return this.ProfileImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfileImageField, value) != true)) {
                    this.ProfileImageField = value;
                    this.RaisePropertyChanged("ProfileImage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Published {
            get {
                return this.PublishedField;
            }
            set {
                if ((this.PublishedField.Equals(value) != true)) {
                    this.PublishedField = value;
                    this.RaisePropertyChanged("Published");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string screen_name {
            get {
                return this.screen_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.screen_nameField, value) != true)) {
                    this.screen_nameField = value;
                    this.RaisePropertyChanged("screen_name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTweets", ReplyAction="http://tempuri.org/IService1/GetTweetsResponse")]
        TwitterClient.ServiceReference1.TwitterModel[] GetTweets(string twitterHashTag);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TwitterClient.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TwitterClient.ServiceReference1.IService1>, TwitterClient.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TwitterClient.ServiceReference1.TwitterModel[] GetTweets(string twitterHashTag) {
            return base.Channel.GetTweets(twitterHashTag);
        }
    }
}
