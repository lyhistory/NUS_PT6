﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRSClient.CourseRegistrationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Registration", Namespace="http://schemas.datacontract.org/2004/07/nus.iss.crs.dm.Registration")]
    [System.SerializableAttribute()]
    public partial class Registration : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CourseRegistrationService.ICourseRegistrationService")]
    public interface ICourseRegistrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseRegistrationService/DoWork", ReplyAction="http://tempuri.org/ICourseRegistrationService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseRegistrationService/DoWork", ReplyAction="http://tempuri.org/ICourseRegistrationService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseRegistrationService/RegistrateCourse", ReplyAction="http://tempuri.org/ICourseRegistrationService/RegistrateCourseResponse")]
        void RegistrateCourse(CRSClient.CourseRegistrationService.Registration reg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourseRegistrationService/RegistrateCourse", ReplyAction="http://tempuri.org/ICourseRegistrationService/RegistrateCourseResponse")]
        System.Threading.Tasks.Task RegistrateCourseAsync(CRSClient.CourseRegistrationService.Registration reg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICourseRegistrationServiceChannel : CRSClient.CourseRegistrationService.ICourseRegistrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CourseRegistrationServiceClient : System.ServiceModel.ClientBase<CRSClient.CourseRegistrationService.ICourseRegistrationService>, CRSClient.CourseRegistrationService.ICourseRegistrationService {
        
        public CourseRegistrationServiceClient() {
        }
        
        public CourseRegistrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CourseRegistrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CourseRegistrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CourseRegistrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public void RegistrateCourse(CRSClient.CourseRegistrationService.Registration reg) {
            base.Channel.RegistrateCourse(reg);
        }
        
        public System.Threading.Tasks.Task RegistrateCourseAsync(CRSClient.CourseRegistrationService.Registration reg) {
            return base.Channel.RegistrateCourseAsync(reg);
        }
    }
}
