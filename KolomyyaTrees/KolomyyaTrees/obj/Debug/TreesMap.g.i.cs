﻿#pragma checksum "..\..\TreesMap.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1DA1DA9ABB84E9D20294433C5B5E8B35239E5A897C3356E82E0EC47DF40BDA5"
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
    /// TreesMap
    /// </summary>
    public partial class TreesMap : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\TreesMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homeButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TreesMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\TreesMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesListButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TreesMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreeAddButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TreesMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TreesMapButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\TreesMap.xaml"
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
            System.Uri resourceLocater = new System.Uri("/KolomyyaTrees;component/treesmap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TreesMap.xaml"
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
            
            #line 21 "..\..\TreesMap.xaml"
            this.homeButton.Click += new System.Windows.RoutedEventHandler(this.homeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\TreesMap.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.exitButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TreesListButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\TreesMap.xaml"
            this.TreesListButton.Click += new System.Windows.RoutedEventHandler(this.TreesListButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TreeAddButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\TreesMap.xaml"
            this.TreeAddButton.Click += new System.Windows.RoutedEventHandler(this.TreeAddButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TreesMapButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\TreesMap.xaml"
            this.TreesMapButton.Click += new System.Windows.RoutedEventHandler(this.TreesMapButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelTreesKPD = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

