﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OperatorOverloading.Model {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OperatorOverloading.Model.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to Currecy MisMatch Occured .
        /// </summary>
        public static string CurrencyMismatch {
            get {
                return ResourceManager.GetString("CurrencyMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string DivideByZero {
            get {
                return ResourceManager.GetString("DivideByZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please check your Amount Input .
        /// </summary>
        public static string InvalidAmountInput {
            get {
                return ResourceManager.GetString("InvalidAmountInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please check your Currency Input.
        /// </summary>
        public static string InvalidCurrency {
            get {
                return ResourceManager.GetString("InvalidCurrency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input given is Invalid.
        /// </summary>
        public static string InvalidInput {
            get {
                return ResourceManager.GetString("InvalidInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sum is beyond storage.
        /// </summary>
        public static string InvalidSum {
            get {
                return ResourceManager.GetString("InvalidSum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object pased is null object.
        /// </summary>
        public static string ObjectNull {
            get {
                return ResourceManager.GetString("ObjectNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total amount is out of range..
        /// </summary>
        public static string OutOfRange {
            get {
                return ResourceManager.GetString("OutOfRange", resourceCulture);
            }
        }
    }
}