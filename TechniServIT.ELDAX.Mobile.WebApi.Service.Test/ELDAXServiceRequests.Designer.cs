﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Test {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ELDAXServiceRequests {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ELDAXServiceRequests() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TechniServIT.ELDAX.Mobile.WebApi.Service.Test.ELDAXServiceRequests", typeof(ELDAXServiceRequests).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;soapenv:Envelope xmlns:soapenv=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot; xmlns:tec=&quot;https://www.techniserv-it.cz&quot; xmlns:tec1=&quot;http://schemas.datacontract.org/2004/07/TechniServIT.ELDAX.Service.ProxyClasses&quot;&gt;
        ///   &lt;soapenv:Header/&gt;
        ///   &lt;soapenv:Body&gt;
        ///      &lt;tec:AuthenticateEx&gt;
        ///         &lt;!--Optional:--&gt;
        ///         &lt;tec:ctx&gt;
        ///            &lt;!--Optional:--&gt;
        ///            &lt;tec1:ApplicationLogin&gt;?&lt;/tec1:ApplicationLogin&gt;
        ///            &lt;!--Optional:--&gt;
        ///            &lt;tec1:AuthenticationMessage&gt;?&lt;/tec1:Authentication [rest of string was truncated]&quot;;.
        /// </summary>
        public static string AuthenticateEx {
            get {
                return ResourceManager.GetString("AuthenticateEx", resourceCulture);
            }
        }
    }
}
