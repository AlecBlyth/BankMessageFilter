﻿#pragma checksum "..\..\MessageViewer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB011EE46A54181DA9F6A20FDC14B209C1009777"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NapierBankMessageFilter;
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


namespace NapierBankMessageFilter {
    
    
    /// <summary>
    /// MessageViewer
    /// </summary>
    public partial class MessageViewer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\MessageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button emailButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MessageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tweetButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MessageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button smsButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MessageViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateMessages;
        
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
            System.Uri resourceLocater = new System.Uri("/NapierBankMessageFilter;component/messageviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MessageViewer.xaml"
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
            this.emailButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MessageViewer.xaml"
            this.emailButton.Click += new System.Windows.RoutedEventHandler(this.emailButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tweetButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MessageViewer.xaml"
            this.tweetButton.Click += new System.Windows.RoutedEventHandler(this.tweetButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.smsButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MessageViewer.xaml"
            this.smsButton.Click += new System.Windows.RoutedEventHandler(this.smsButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCreateMessages = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MessageViewer.xaml"
            this.btnCreateMessages.Click += new System.Windows.RoutedEventHandler(this.btnCreateMessages_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
