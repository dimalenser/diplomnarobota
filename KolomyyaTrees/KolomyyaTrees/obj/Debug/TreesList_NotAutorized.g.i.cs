﻿#pragma checksum "..\..\TreesList_NotAutorized.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C66E827FA17D128ACEAF46BC077FAFD9B33C9B85F9AEB71AAF745E1E103AFBB4"
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
    /// TreesList_NotAutorized
    /// </summary>
    public partial class TreesList_NotAutorized : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homeButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesListButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreeAddButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesMapButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTreesKPD;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\TreesList_NotAutorized.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid;
        
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
            System.Uri resourceLocater = new System.Uri("/KolomyyaTrees;component/treeslist_notautorized.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TreesList_NotAutorized.xaml"
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
            this.homeButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\TreesList_NotAutorized.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.homeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\TreesList_NotAutorized.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TreesListButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\TreesList_NotAutorized.xaml"
            this.TreesListButton.Click += new System.Windows.RoutedEventHandler(this.TreesListButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TreeAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\TreesList_NotAutorized.xaml"
            this.TreeAddButton.Click += new System.Windows.RoutedEventHandler(this.TreeAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TreesMapButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\TreesList_NotAutorized.xaml"
            this.TreesMapButton.Click += new System.Windows.RoutedEventHandler(this.TreesMapButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelTreesKPD = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.grid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\TreesList_NotAutorized.xaml"
            this.grid.Loaded += new System.Windows.RoutedEventHandler(this.grid_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

