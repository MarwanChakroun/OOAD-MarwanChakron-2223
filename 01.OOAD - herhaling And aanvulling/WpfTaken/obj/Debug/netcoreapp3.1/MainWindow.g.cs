﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94C8446D72A339FD4460EC447AE92F600A4763F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfTaken;


namespace WpfTaken {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_taak;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPrio;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtDeadline;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAdam;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbBilal;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbChelsey;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbx_taken;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Toevoegen;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_terugzetten;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_verwijderen;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblck_fouten;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfTaken;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbx_taak = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.tbx_taak.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbx_taak_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbPrio = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.dtDeadline = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.rbAdam = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbBilal = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbChelsey = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.lbx_taken = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.lbx_taken.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbx_taken_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Toevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.btn_Toevoegen.Click += new System.Windows.RoutedEventHandler(this.btn_Toevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_terugzetten = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\MainWindow.xaml"
            this.btn_terugzetten.Click += new System.Windows.RoutedEventHandler(this.btn_terugzetten_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_verwijderen = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.btn_verwijderen.Click += new System.Windows.RoutedEventHandler(this.btn_verwijderen_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tblck_fouten = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

