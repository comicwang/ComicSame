﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComicSame.SSO.SSOValidate {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SSOToken", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SSOToken : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DomainField;
        
        private System.DateTime AuthTimeField;
        
        private int TimeOutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ComicSame.SSO.SSOValidate.SSOUser UserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Domain {
            get {
                return this.DomainField;
            }
            set {
                if ((object.ReferenceEquals(this.DomainField, value) != true)) {
                    this.DomainField = value;
                    this.RaisePropertyChanged("Domain");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public System.DateTime AuthTime {
            get {
                return this.AuthTimeField;
            }
            set {
                if ((this.AuthTimeField.Equals(value) != true)) {
                    this.AuthTimeField = value;
                    this.RaisePropertyChanged("AuthTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public int TimeOut {
            get {
                return this.TimeOutField;
            }
            set {
                if ((this.TimeOutField.Equals(value) != true)) {
                    this.TimeOutField = value;
                    this.RaisePropertyChanged("TimeOut");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public ComicSame.SSO.SSOValidate.SSOUser User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string LoginID {
            get {
                return this.LoginIDField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginIDField, value) != true)) {
                    this.LoginIDField = value;
                    this.RaisePropertyChanged("LoginID");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SSOUser", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SSOUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccountField;
        
        private System.DateTime RegistDateField;
        
        private System.DateTime ModyfyDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrginField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Account {
            get {
                return this.AccountField;
            }
            set {
                if ((object.ReferenceEquals(this.AccountField, value) != true)) {
                    this.AccountField = value;
                    this.RaisePropertyChanged("Account");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.DateTime RegistDate {
            get {
                return this.RegistDateField;
            }
            set {
                if ((this.RegistDateField.Equals(value) != true)) {
                    this.RegistDateField = value;
                    this.RaisePropertyChanged("RegistDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.DateTime ModyfyDate {
            get {
                return this.ModyfyDateField;
            }
            set {
                if ((this.ModyfyDateField.Equals(value) != true)) {
                    this.ModyfyDateField = value;
                    this.RaisePropertyChanged("ModyfyDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Department {
            get {
                return this.DepartmentField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentField, value) != true)) {
                    this.DepartmentField = value;
                    this.RaisePropertyChanged("Department");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Orgin {
            get {
                return this.OrginField;
            }
            set {
                if ((object.ReferenceEquals(this.OrginField, value) != true)) {
                    this.OrginField = value;
                    this.RaisePropertyChanged("Orgin");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SSOValidate.AuthTokenServiceSoap")]
    public interface AuthTokenServiceSoap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 tokenID 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateToken", ReplyAction="*")]
        ComicSame.SSO.SSOValidate.ValidateTokenResponse ValidateToken(ComicSame.SSO.SSOValidate.ValidateTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ValidateToken", ReplyAction="*")]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.ValidateTokenResponse> ValidateTokenAsync(ComicSame.SSO.SSOValidate.ValidateTokenRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 tokenID 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KeepToken", ReplyAction="*")]
        ComicSame.SSO.SSOValidate.KeepTokenResponse KeepToken(ComicSame.SSO.SSOValidate.KeepTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KeepToken", ReplyAction="*")]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.KeepTokenResponse> KeepTokenAsync(ComicSame.SSO.SSOValidate.KeepTokenRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 userName 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetToken", ReplyAction="*")]
        ComicSame.SSO.SSOValidate.GetTokenResponse GetToken(ComicSame.SSO.SSOValidate.GetTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetToken", ReplyAction="*")]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.GetTokenResponse> GetTokenAsync(ComicSame.SSO.SSOValidate.GetTokenRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateToken", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.ValidateTokenRequestBody Body;
        
        public ValidateTokenRequest() {
        }
        
        public ValidateTokenRequest(ComicSame.SSO.SSOValidate.ValidateTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string tokenID;
        
        public ValidateTokenRequestBody() {
        }
        
        public ValidateTokenRequestBody(string tokenID) {
            this.tokenID = tokenID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ValidateTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ValidateTokenResponse", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.ValidateTokenResponseBody Body;
        
        public ValidateTokenResponse() {
        }
        
        public ValidateTokenResponse(ComicSame.SSO.SSOValidate.ValidateTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ComicSame.SSO.SSOValidate.SSOToken ValidateTokenResult;
        
        public ValidateTokenResponseBody() {
        }
        
        public ValidateTokenResponseBody(ComicSame.SSO.SSOValidate.SSOToken ValidateTokenResult) {
            this.ValidateTokenResult = ValidateTokenResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class KeepTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="KeepToken", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.KeepTokenRequestBody Body;
        
        public KeepTokenRequest() {
        }
        
        public KeepTokenRequest(ComicSame.SSO.SSOValidate.KeepTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class KeepTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string tokenID;
        
        public KeepTokenRequestBody() {
        }
        
        public KeepTokenRequestBody(string tokenID) {
            this.tokenID = tokenID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class KeepTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="KeepTokenResponse", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.KeepTokenResponseBody Body;
        
        public KeepTokenResponse() {
        }
        
        public KeepTokenResponse(ComicSame.SSO.SSOValidate.KeepTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class KeepTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool KeepTokenResult;
        
        public KeepTokenResponseBody() {
        }
        
        public KeepTokenResponseBody(bool KeepTokenResult) {
            this.KeepTokenResult = KeepTokenResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetToken", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.GetTokenRequestBody Body;
        
        public GetTokenRequest() {
        }
        
        public GetTokenRequest(ComicSame.SSO.SSOValidate.GetTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public GetTokenRequestBody() {
        }
        
        public GetTokenRequestBody(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTokenResponse", Namespace="http://tempuri.org/", Order=0)]
        public ComicSame.SSO.SSOValidate.GetTokenResponseBody Body;
        
        public GetTokenResponse() {
        }
        
        public GetTokenResponse(ComicSame.SSO.SSOValidate.GetTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetTokenResult;
        
        public GetTokenResponseBody() {
        }
        
        public GetTokenResponseBody(string GetTokenResult) {
            this.GetTokenResult = GetTokenResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AuthTokenServiceSoapChannel : ComicSame.SSO.SSOValidate.AuthTokenServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthTokenServiceSoapClient : System.ServiceModel.ClientBase<ComicSame.SSO.SSOValidate.AuthTokenServiceSoap>, ComicSame.SSO.SSOValidate.AuthTokenServiceSoap {
        
        public AuthTokenServiceSoapClient() {
        }
        
        public AuthTokenServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthTokenServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthTokenServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthTokenServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ComicSame.SSO.SSOValidate.ValidateTokenResponse ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.ValidateToken(ComicSame.SSO.SSOValidate.ValidateTokenRequest request) {
            return base.Channel.ValidateToken(request);
        }
        
        public ComicSame.SSO.SSOValidate.SSOToken ValidateToken(string tokenID) {
            ComicSame.SSO.SSOValidate.ValidateTokenRequest inValue = new ComicSame.SSO.SSOValidate.ValidateTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.ValidateTokenRequestBody();
            inValue.Body.tokenID = tokenID;
            ComicSame.SSO.SSOValidate.ValidateTokenResponse retVal = ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).ValidateToken(inValue);
            return retVal.Body.ValidateTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.ValidateTokenResponse> ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.ValidateTokenAsync(ComicSame.SSO.SSOValidate.ValidateTokenRequest request) {
            return base.Channel.ValidateTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.ValidateTokenResponse> ValidateTokenAsync(string tokenID) {
            ComicSame.SSO.SSOValidate.ValidateTokenRequest inValue = new ComicSame.SSO.SSOValidate.ValidateTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.ValidateTokenRequestBody();
            inValue.Body.tokenID = tokenID;
            return ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).ValidateTokenAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ComicSame.SSO.SSOValidate.KeepTokenResponse ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.KeepToken(ComicSame.SSO.SSOValidate.KeepTokenRequest request) {
            return base.Channel.KeepToken(request);
        }
        
        public bool KeepToken(string tokenID) {
            ComicSame.SSO.SSOValidate.KeepTokenRequest inValue = new ComicSame.SSO.SSOValidate.KeepTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.KeepTokenRequestBody();
            inValue.Body.tokenID = tokenID;
            ComicSame.SSO.SSOValidate.KeepTokenResponse retVal = ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).KeepToken(inValue);
            return retVal.Body.KeepTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.KeepTokenResponse> ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.KeepTokenAsync(ComicSame.SSO.SSOValidate.KeepTokenRequest request) {
            return base.Channel.KeepTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.KeepTokenResponse> KeepTokenAsync(string tokenID) {
            ComicSame.SSO.SSOValidate.KeepTokenRequest inValue = new ComicSame.SSO.SSOValidate.KeepTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.KeepTokenRequestBody();
            inValue.Body.tokenID = tokenID;
            return ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).KeepTokenAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ComicSame.SSO.SSOValidate.GetTokenResponse ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.GetToken(ComicSame.SSO.SSOValidate.GetTokenRequest request) {
            return base.Channel.GetToken(request);
        }
        
        public string GetToken(string userName, string password) {
            ComicSame.SSO.SSOValidate.GetTokenRequest inValue = new ComicSame.SSO.SSOValidate.GetTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.GetTokenRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            ComicSame.SSO.SSOValidate.GetTokenResponse retVal = ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).GetToken(inValue);
            return retVal.Body.GetTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.GetTokenResponse> ComicSame.SSO.SSOValidate.AuthTokenServiceSoap.GetTokenAsync(ComicSame.SSO.SSOValidate.GetTokenRequest request) {
            return base.Channel.GetTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<ComicSame.SSO.SSOValidate.GetTokenResponse> GetTokenAsync(string userName, string password) {
            ComicSame.SSO.SSOValidate.GetTokenRequest inValue = new ComicSame.SSO.SSOValidate.GetTokenRequest();
            inValue.Body = new ComicSame.SSO.SSOValidate.GetTokenRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            return ((ComicSame.SSO.SSOValidate.AuthTokenServiceSoap)(this)).GetTokenAsync(inValue);
        }
    }
}
