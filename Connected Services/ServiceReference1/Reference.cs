﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPNETExcelByNPOI.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/WCFService.Common")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string customerAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string customerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string customerNameField;
        
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
        public string customerAddress {
            get {
                return this.customerAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.customerAddressField, value) != true)) {
                    this.customerAddressField = value;
                    this.RaisePropertyChanged("customerAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string customerID {
            get {
                return this.customerIDField;
            }
            set {
                if ((object.ReferenceEquals(this.customerIDField, value) != true)) {
                    this.customerIDField = value;
                    this.RaisePropertyChanged("customerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string customerName {
            get {
                return this.customerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.customerNameField, value) != true)) {
                    this.customerNameField = value;
                    this.RaisePropertyChanged("customerName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomer", ReplyAction="http://tempuri.org/IService/GetCustomerResponse")]
        ASPNETExcelByNPOI.ServiceReference1.Customer[] GetCustomer(string customerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomer", ReplyAction="http://tempuri.org/IService/GetCustomerResponse")]
        System.Threading.Tasks.Task<ASPNETExcelByNPOI.ServiceReference1.Customer[]> GetCustomerAsync(string customerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomerByJSon", ReplyAction="http://tempuri.org/IService/GetCustomerByJSonResponse")]
        string GetCustomerByJSon(string customerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCustomerByJSon", ReplyAction="http://tempuri.org/IService/GetCustomerByJSonResponse")]
        System.Threading.Tasks.Task<string> GetCustomerByJSonAsync(string customerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SetCustomer", ReplyAction="http://tempuri.org/IService/SetCustomerResponse")]
        void SetCustomer(string customerName, string customerAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SetCustomer", ReplyAction="http://tempuri.org/IService/SetCustomerResponse")]
        System.Threading.Tasks.Task SetCustomerAsync(string customerName, string customerAddress);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ASPNETExcelByNPOI.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ASPNETExcelByNPOI.ServiceReference1.IService>, ASPNETExcelByNPOI.ServiceReference1.IService {
        
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
        
        public ASPNETExcelByNPOI.ServiceReference1.Customer[] GetCustomer(string customerID) {
            return base.Channel.GetCustomer(customerID);
        }
        
        public System.Threading.Tasks.Task<ASPNETExcelByNPOI.ServiceReference1.Customer[]> GetCustomerAsync(string customerID) {
            return base.Channel.GetCustomerAsync(customerID);
        }
        
        public string GetCustomerByJSon(string customerID) {
            return base.Channel.GetCustomerByJSon(customerID);
        }
        
        public System.Threading.Tasks.Task<string> GetCustomerByJSonAsync(string customerID) {
            return base.Channel.GetCustomerByJSonAsync(customerID);
        }
        
        public void SetCustomer(string customerName, string customerAddress) {
            base.Channel.SetCustomer(customerName, customerAddress);
        }
        
        public System.Threading.Tasks.Task SetCustomerAsync(string customerName, string customerAddress) {
            return base.Channel.SetCustomerAsync(customerName, customerAddress);
        }
    }
}