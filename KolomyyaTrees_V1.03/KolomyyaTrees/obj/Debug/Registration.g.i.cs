﻿#pragma checksum "..\..\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FC4B5BD070068E03ADEEF4E40EC69FA492DCCA5E87D5796F8ADE67338854B80E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KolomyyaTrees;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KolomyyaTrees {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homeButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesListButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreeAddButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesMapButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSurname;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLogin;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRegistration;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTreesKPD;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KolomyyaTrees;component/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registration.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\Registration.xaml"
            ((KolomyyaTrees.Registration)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.homeButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Registration.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.homeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Registration.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TreesListButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Registration.xaml"
            this.TreesListButton.Click += new System.Windows.RoutedEventHandler(this.TreesListButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TreeAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Registration.xaml"
            this.TreeAddButton.Click += new System.Windows.RoutedEventHandler(this.TreeAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TreesMapButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Registration.xaml"
            this.TreesMapButton.Click += new System.Windows.RoutedEventHandler(this.TreesMapButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\Registration.xaml"
            this.textBoxName.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxName_GotFocus);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Registration.xaml"
            this.textBoxName.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\Registration.xaml"
            this.textBoxSurname.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxSurname_GotFocus);
            
            #line default
            #line hidden
            
            #line 34 "..\..\Registration.xaml"
            this.textBoxSurname.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxSurname_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.textBoxLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\Registration.xaml"
            this.textBoxLogin.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxLogin_GotFocus);
            
            #line default
            #line hidden
            
            #line 35 "..\..\Registration.xaml"
            this.textBoxLogin.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxLogin_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textBoxPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\Registration.xaml"
            this.textBoxPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Registration.xaml"
            this.textBoxPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 38 "..\..\Registration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.buttonRegistration = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Registration.xaml"
            this.buttonRegistration.Click += new System.Windows.RoutedEventHandler(this.buttonRegistration_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.labelTreesKPD = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

