﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Этот исходный текст был создан автоматически: Microsoft.VSDesigner, версия: 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace FakeHttpServerTests.SoapServerManagerWebRef {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServerManagerSoap", Namespace="http://tempuri.org/")]
    public partial class ServerManager : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback TryUpServerOperationCompleted;
        
        private System.Threading.SendOrPostCallback ShutDownServerOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateReceivedConditionalOperationCompleted;
        
        private System.Threading.SendOrPostCallback TheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted;
        
        private System.Threading.SendOrPostCallback ForTheConditionalResponseBodyShouldBeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetReceiveHistoryForFakeServerOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServerManager() {
            this.Url = global::FakeHttpServerTests.Properties.Settings.Default.FakeHttpServerTests_SoapServerManagerWebRef_ServerManager;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event TryUpServerCompletedEventHandler TryUpServerCompleted;
        
        /// <remarks/>
        public event ShutDownServerCompletedEventHandler ShutDownServerCompleted;
        
        /// <remarks/>
        public event CreateReceivedConditionalCompletedEventHandler CreateReceivedConditionalCompleted;
        
        /// <remarks/>
        public event TheConditionalShouldBeExpectPostWithRquestBodyCompletedEventHandler TheConditionalShouldBeExpectPostWithRquestBodyCompleted;
        
        /// <remarks/>
        public event ForTheConditionalResponseBodyShouldBeCompletedEventHandler ForTheConditionalResponseBodyShouldBeCompleted;
        
        /// <remarks/>
        public event GetReceiveHistoryForFakeServerCompletedEventHandler GetReceiveHistoryForFakeServerCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TryUpServer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public long TryUpServer(string ListnedUrl) {
            object[] results = this.Invoke("TryUpServer", new object[] {
                        ListnedUrl});
            return ((long)(results[0]));
        }
        
        /// <remarks/>
        public void TryUpServerAsync(string ListnedUrl) {
            this.TryUpServerAsync(ListnedUrl, null);
        }
        
        /// <remarks/>
        public void TryUpServerAsync(string ListnedUrl, object userState) {
            if ((this.TryUpServerOperationCompleted == null)) {
                this.TryUpServerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTryUpServerOperationCompleted);
            }
            this.InvokeAsync("TryUpServer", new object[] {
                        ListnedUrl}, this.TryUpServerOperationCompleted, userState);
        }
        
        private void OnTryUpServerOperationCompleted(object arg) {
            if ((this.TryUpServerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TryUpServerCompleted(this, new TryUpServerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ShutDownServer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ShutDownServer(long ServerId) {
            this.Invoke("ShutDownServer", new object[] {
                        ServerId});
        }
        
        /// <remarks/>
        public void ShutDownServerAsync(long ServerId) {
            this.ShutDownServerAsync(ServerId, null);
        }
        
        /// <remarks/>
        public void ShutDownServerAsync(long ServerId, object userState) {
            if ((this.ShutDownServerOperationCompleted == null)) {
                this.ShutDownServerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnShutDownServerOperationCompleted);
            }
            this.InvokeAsync("ShutDownServer", new object[] {
                        ServerId}, this.ShutDownServerOperationCompleted, userState);
        }
        
        private void OnShutDownServerOperationCompleted(object arg) {
            if ((this.ShutDownServerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ShutDownServerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CreateReceivedConditional", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public long CreateReceivedConditional(long ServerId, int ReciverConditionalType) {
            object[] results = this.Invoke("CreateReceivedConditional", new object[] {
                        ServerId,
                        ReciverConditionalType});
            return ((long)(results[0]));
        }
        
        /// <remarks/>
        public void CreateReceivedConditionalAsync(long ServerId, int ReciverConditionalType) {
            this.CreateReceivedConditionalAsync(ServerId, ReciverConditionalType, null);
        }
        
        /// <remarks/>
        public void CreateReceivedConditionalAsync(long ServerId, int ReciverConditionalType, object userState) {
            if ((this.CreateReceivedConditionalOperationCompleted == null)) {
                this.CreateReceivedConditionalOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateReceivedConditionalOperationCompleted);
            }
            this.InvokeAsync("CreateReceivedConditional", new object[] {
                        ServerId,
                        ReciverConditionalType}, this.CreateReceivedConditionalOperationCompleted, userState);
        }
        
        private void OnCreateReceivedConditionalOperationCompleted(object arg) {
            if ((this.CreateReceivedConditionalCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateReceivedConditionalCompleted(this, new CreateReceivedConditionalCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TheConditionalShouldBeExpectPostWithRquestBody", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void TheConditionalShouldBeExpectPostWithRquestBody(long ServerId, long ConditionalId, string ExpectedRequestBody) {
            this.Invoke("TheConditionalShouldBeExpectPostWithRquestBody", new object[] {
                        ServerId,
                        ConditionalId,
                        ExpectedRequestBody});
        }
        
        /// <remarks/>
        public void TheConditionalShouldBeExpectPostWithRquestBodyAsync(long ServerId, long ConditionalId, string ExpectedRequestBody) {
            this.TheConditionalShouldBeExpectPostWithRquestBodyAsync(ServerId, ConditionalId, ExpectedRequestBody, null);
        }
        
        /// <remarks/>
        public void TheConditionalShouldBeExpectPostWithRquestBodyAsync(long ServerId, long ConditionalId, string ExpectedRequestBody, object userState) {
            if ((this.TheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted == null)) {
                this.TheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted);
            }
            this.InvokeAsync("TheConditionalShouldBeExpectPostWithRquestBody", new object[] {
                        ServerId,
                        ConditionalId,
                        ExpectedRequestBody}, this.TheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted, userState);
        }
        
        private void OnTheConditionalShouldBeExpectPostWithRquestBodyOperationCompleted(object arg) {
            if ((this.TheConditionalShouldBeExpectPostWithRquestBodyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TheConditionalShouldBeExpectPostWithRquestBodyCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ForTheConditionalResponseBodyShouldBe", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ForTheConditionalResponseBodyShouldBe(long ServerId, long ConditionalId, string ExpectedResponseBody, string[] responseHeaders) {
            this.Invoke("ForTheConditionalResponseBodyShouldBe", new object[] {
                        ServerId,
                        ConditionalId,
                        ExpectedResponseBody,
                        responseHeaders});
        }
        
        /// <remarks/>
        public void ForTheConditionalResponseBodyShouldBeAsync(long ServerId, long ConditionalId, string ExpectedResponseBody, string[] responseHeaders) {
            this.ForTheConditionalResponseBodyShouldBeAsync(ServerId, ConditionalId, ExpectedResponseBody, responseHeaders, null);
        }
        
        /// <remarks/>
        public void ForTheConditionalResponseBodyShouldBeAsync(long ServerId, long ConditionalId, string ExpectedResponseBody, string[] responseHeaders, object userState) {
            if ((this.ForTheConditionalResponseBodyShouldBeOperationCompleted == null)) {
                this.ForTheConditionalResponseBodyShouldBeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnForTheConditionalResponseBodyShouldBeOperationCompleted);
            }
            this.InvokeAsync("ForTheConditionalResponseBodyShouldBe", new object[] {
                        ServerId,
                        ConditionalId,
                        ExpectedResponseBody,
                        responseHeaders}, this.ForTheConditionalResponseBodyShouldBeOperationCompleted, userState);
        }
        
        private void OnForTheConditionalResponseBodyShouldBeOperationCompleted(object arg) {
            if ((this.ForTheConditionalResponseBodyShouldBeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ForTheConditionalResponseBodyShouldBeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetReceiveHistoryForFakeServer", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetReceiveHistoryForFakeServer(long ServerId) {
            object[] results = this.Invoke("GetReceiveHistoryForFakeServer", new object[] {
                        ServerId});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetReceiveHistoryForFakeServerAsync(long ServerId) {
            this.GetReceiveHistoryForFakeServerAsync(ServerId, null);
        }
        
        /// <remarks/>
        public void GetReceiveHistoryForFakeServerAsync(long ServerId, object userState) {
            if ((this.GetReceiveHistoryForFakeServerOperationCompleted == null)) {
                this.GetReceiveHistoryForFakeServerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetReceiveHistoryForFakeServerOperationCompleted);
            }
            this.InvokeAsync("GetReceiveHistoryForFakeServer", new object[] {
                        ServerId}, this.GetReceiveHistoryForFakeServerOperationCompleted, userState);
        }
        
        private void OnGetReceiveHistoryForFakeServerOperationCompleted(object arg) {
            if ((this.GetReceiveHistoryForFakeServerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetReceiveHistoryForFakeServerCompleted(this, new GetReceiveHistoryForFakeServerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void TryUpServerCompletedEventHandler(object sender, TryUpServerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TryUpServerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TryUpServerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public long Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ShutDownServerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void CreateReceivedConditionalCompletedEventHandler(object sender, CreateReceivedConditionalCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateReceivedConditionalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateReceivedConditionalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public long Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void TheConditionalShouldBeExpectPostWithRquestBodyCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ForTheConditionalResponseBodyShouldBeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetReceiveHistoryForFakeServerCompletedEventHandler(object sender, GetReceiveHistoryForFakeServerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetReceiveHistoryForFakeServerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetReceiveHistoryForFakeServerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591