﻿#pragma checksum "..\..\..\..\View\Home.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95A26CF8A78911C353B5E603C6AD0B2CD280E1BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AccountingSoftware;
using ScottPlot.WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AccountingSoftware {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackLeft;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button home;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addAccount;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button viewAccount;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button journalEntry;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sfp;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sci;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logout;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackRight;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WPF.WpfPlot WpfPlot1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AccountingSoftware;component/view/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Home.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.stackLeft = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.home = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\View\Home.xaml"
            this.home.Click += new System.Windows.RoutedEventHandler(this.home_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.addAccount = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\View\Home.xaml"
            this.addAccount.Click += new System.Windows.RoutedEventHandler(this.addAccount_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.viewAccount = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\View\Home.xaml"
            this.viewAccount.Click += new System.Windows.RoutedEventHandler(this.viewAccount_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.journalEntry = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\View\Home.xaml"
            this.journalEntry.Click += new System.Windows.RoutedEventHandler(this.journalEntry_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sfp = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\View\Home.xaml"
            this.sfp.Click += new System.Windows.RoutedEventHandler(this.sfp_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sci = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\View\Home.xaml"
            this.sci.Click += new System.Windows.RoutedEventHandler(this.sci_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.logout = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\View\Home.xaml"
            this.logout.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.stackRight = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.WpfPlot1 = ((ScottPlot.WPF.WpfPlot)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

