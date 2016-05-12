﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Cpas.WebServiceLocal {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AutentificarSoap", Namespace="http://tempuri.org/")]
    public partial class Autentificar : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ValidarOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerProyectosListadosTricelOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerDocumentosOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerNotificacionesOperationCompleted;
        
        private System.Threading.SendOrPostCallback ObtenerRendicionesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Autentificar() {
            this.Url = "http://localhost:17020/WebService/Autentificar.asmx";
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
        public event ValidarCompletedEventHandler ValidarCompleted;
        
        /// <remarks/>
        public event ObtenerProyectosListadosTricelCompletedEventHandler ObtenerProyectosListadosTricelCompleted;
        
        /// <remarks/>
        public event ObtenerDocumentosCompletedEventHandler ObtenerDocumentosCompleted;
        
        /// <remarks/>
        public event ObtenerNotificacionesCompletedEventHandler ObtenerNotificacionesCompleted;
        
        /// <remarks/>
        public event ObtenerRendicionesCompletedEventHandler ObtenerRendicionesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Validar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Validar(string usuario, string clave) {
            object[] results = this.Invoke("Validar", new object[] {
                        usuario,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ValidarAsync(string usuario, string clave) {
            this.ValidarAsync(usuario, clave, null);
        }
        
        /// <remarks/>
        public void ValidarAsync(string usuario, string clave, object userState) {
            if ((this.ValidarOperationCompleted == null)) {
                this.ValidarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidarOperationCompleted);
            }
            this.InvokeAsync("Validar", new object[] {
                        usuario,
                        clave}, this.ValidarOperationCompleted, userState);
        }
        
        private void OnValidarOperationCompleted(object arg) {
            if ((this.ValidarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidarCompleted(this, new ValidarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerProyectosListadosTricel", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerProyectosListadosTricel(string instId, string usuId) {
            object[] results = this.Invoke("ObtenerProyectosListadosTricel", new object[] {
                        instId,
                        usuId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerProyectosListadosTricelAsync(string instId, string usuId) {
            this.ObtenerProyectosListadosTricelAsync(instId, usuId, null);
        }
        
        /// <remarks/>
        public void ObtenerProyectosListadosTricelAsync(string instId, string usuId, object userState) {
            if ((this.ObtenerProyectosListadosTricelOperationCompleted == null)) {
                this.ObtenerProyectosListadosTricelOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerProyectosListadosTricelOperationCompleted);
            }
            this.InvokeAsync("ObtenerProyectosListadosTricel", new object[] {
                        instId,
                        usuId}, this.ObtenerProyectosListadosTricelOperationCompleted, userState);
        }
        
        private void OnObtenerProyectosListadosTricelOperationCompleted(object arg) {
            if ((this.ObtenerProyectosListadosTricelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerProyectosListadosTricelCompleted(this, new ObtenerProyectosListadosTricelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerDocumentos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerDocumentos(string instId) {
            object[] results = this.Invoke("ObtenerDocumentos", new object[] {
                        instId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerDocumentosAsync(string instId) {
            this.ObtenerDocumentosAsync(instId, null);
        }
        
        /// <remarks/>
        public void ObtenerDocumentosAsync(string instId, object userState) {
            if ((this.ObtenerDocumentosOperationCompleted == null)) {
                this.ObtenerDocumentosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerDocumentosOperationCompleted);
            }
            this.InvokeAsync("ObtenerDocumentos", new object[] {
                        instId}, this.ObtenerDocumentosOperationCompleted, userState);
        }
        
        private void OnObtenerDocumentosOperationCompleted(object arg) {
            if ((this.ObtenerDocumentosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerDocumentosCompleted(this, new ObtenerDocumentosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerNotificaciones", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerNotificaciones(string instId, string usuId) {
            object[] results = this.Invoke("ObtenerNotificaciones", new object[] {
                        instId,
                        usuId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerNotificacionesAsync(string instId, string usuId) {
            this.ObtenerNotificacionesAsync(instId, usuId, null);
        }
        
        /// <remarks/>
        public void ObtenerNotificacionesAsync(string instId, string usuId, object userState) {
            if ((this.ObtenerNotificacionesOperationCompleted == null)) {
                this.ObtenerNotificacionesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerNotificacionesOperationCompleted);
            }
            this.InvokeAsync("ObtenerNotificaciones", new object[] {
                        instId,
                        usuId}, this.ObtenerNotificacionesOperationCompleted, userState);
        }
        
        private void OnObtenerNotificacionesOperationCompleted(object arg) {
            if ((this.ObtenerNotificacionesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerNotificacionesCompleted(this, new ObtenerNotificacionesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ObtenerRendiciones", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ObtenerRendiciones(string instId) {
            object[] results = this.Invoke("ObtenerRendiciones", new object[] {
                        instId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ObtenerRendicionesAsync(string instId) {
            this.ObtenerRendicionesAsync(instId, null);
        }
        
        /// <remarks/>
        public void ObtenerRendicionesAsync(string instId, object userState) {
            if ((this.ObtenerRendicionesOperationCompleted == null)) {
                this.ObtenerRendicionesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnObtenerRendicionesOperationCompleted);
            }
            this.InvokeAsync("ObtenerRendiciones", new object[] {
                        instId}, this.ObtenerRendicionesOperationCompleted, userState);
        }
        
        private void OnObtenerRendicionesOperationCompleted(object arg) {
            if ((this.ObtenerRendicionesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ObtenerRendicionesCompleted(this, new ObtenerRendicionesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ValidarCompletedEventHandler(object sender, ValidarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ValidarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ObtenerProyectosListadosTricelCompletedEventHandler(object sender, ObtenerProyectosListadosTricelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerProyectosListadosTricelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerProyectosListadosTricelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ObtenerDocumentosCompletedEventHandler(object sender, ObtenerDocumentosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerDocumentosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerDocumentosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ObtenerNotificacionesCompletedEventHandler(object sender, ObtenerNotificacionesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerNotificacionesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerNotificacionesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ObtenerRendicionesCompletedEventHandler(object sender, ObtenerRendicionesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ObtenerRendicionesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ObtenerRendicionesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591