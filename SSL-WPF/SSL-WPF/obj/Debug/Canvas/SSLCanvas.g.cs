﻿#pragma checksum "..\..\..\Canvas\SSLCanvas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A89572214147FB337DBCBDB7727586C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SSL_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace SSL_WPF {
    
    
    /// <summary>
    /// SSLCanvas
    /// </summary>
    public partial class SSLCanvas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Canvas\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer SSLScroller;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Canvas\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasSSL;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Canvas\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dragSelect;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Canvas\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SSL_WPF.Wire dragWire;
        
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
            System.Uri resourceLocater = new System.Uri("/SSL-WPF;component/canvas/sslcanvas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Canvas\SSLCanvas.xaml"
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
            this.SSLScroller = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 7 "..\..\..\Canvas\SSLCanvas.xaml"
            this.SSLScroller.SizeChanged += new System.Windows.SizeChangedEventHandler(this.SSLScroller_SizeChanged);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Canvas\SSLCanvas.xaml"
            this.SSLScroller.LayoutUpdated += new System.EventHandler(this.SSLScroller_LayoutUpdated);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\Canvas\SSLCanvas.xaml"
            this.SSLScroller.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.SSLScroller_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CanvasSSL = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.dragSelect = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.dragWire = ((SSL_WPF.Wire)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

