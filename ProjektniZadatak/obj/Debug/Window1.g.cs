﻿#pragma checksum "..\..\Window1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EFC23E5A5E1A24D8ADB534687FD8A6AD9B1F1C6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjektniZadatak;
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


namespace ProjektniZadatak {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTutorial;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnM;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAS;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjektniZadatak;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            
            #line 29 "..\..\Window1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnTutorial = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Window1.xaml"
            this.btnTutorial.MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverT);
            
            #line default
            #line hidden
            
            #line 32 "..\..\Window1.xaml"
            this.btnTutorial.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoverTLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnM = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Window1.xaml"
            this.btnM.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            
            #line 38 "..\..\Window1.xaml"
            this.btnM.MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverM);
            
            #line default
            #line hidden
            
            #line 38 "..\..\Window1.xaml"
            this.btnM.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoverMLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAS = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Window1.xaml"
            this.btnAS.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            
            #line 44 "..\..\Window1.xaml"
            this.btnAS.MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverAS);
            
            #line default
            #line hidden
            
            #line 44 "..\..\Window1.xaml"
            this.btnAS.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoverASLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\Window1.xaml"
            this.btnHelp.MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverH);
            
            #line default
            #line hidden
            
            #line 50 "..\..\Window1.xaml"
            this.btnHelp.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoverHLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

