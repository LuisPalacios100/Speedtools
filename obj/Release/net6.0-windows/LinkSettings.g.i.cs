﻿#pragma checksum "..\..\..\LinkSettings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0656BA142D7625E344926DC0D99E16C91891DA4F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Speedtools;
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


namespace Speedtools {
    
    
    /// <summary>
    /// LinkSettings
    /// </summary>
    public partial class LinkSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\LinkSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LinkLocationtxt;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\LinkSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LinkSaveBtn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\LinkSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LinkCancelBtn;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\LinkSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LinkTemplateBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\LinkSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LinkSearchBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Speedtools;component/linksettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LinkSettings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LinkLocationtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.LinkSaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\LinkSettings.xaml"
            this.LinkSaveBtn.Click += new System.Windows.RoutedEventHandler(this.LinkSaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LinkCancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\LinkSettings.xaml"
            this.LinkCancelBtn.Click += new System.Windows.RoutedEventHandler(this.LinkCancelBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LinkTemplateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\LinkSettings.xaml"
            this.LinkTemplateBtn.Click += new System.Windows.RoutedEventHandler(this.LinkTemplateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LinkSearchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\LinkSettings.xaml"
            this.LinkSearchBtn.Click += new System.Windows.RoutedEventHandler(this.LinkSearchBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

