﻿#pragma checksum "..\..\..\Utilities\SSLCanvas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F3B62760827B35493B7F2122CB548B92"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace LaneSimulator.Utilities {
    
    
    /// <summary>
    /// SSLCanvas
    /// </summary>
    public partial class SSLCanvas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Utilities\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroller;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Utilities\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GC;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Utilities\SSLCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dragSelect;
        
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
            System.Uri resourceLocater = new System.Uri("/LaneSimulator;component/utilities/sslcanvas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Utilities\SSLCanvas.xaml"
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
            this.Scroller = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 7 "..\..\..\Utilities\SSLCanvas.xaml"
            this.Scroller.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Scroller_SizeChanged);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Utilities\SSLCanvas.xaml"
            this.Scroller.LayoutUpdated += new System.EventHandler(this.Scroller_LayoutUpdated);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Utilities\SSLCanvas.xaml"
            this.Scroller.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.Scroller_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GC = ((System.Windows.Controls.Canvas)(target));
            
            #line 10 "..\..\..\Utilities\SSLCanvas.xaml"
            this.GC.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SSLCanvas_MouseDown);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\Utilities\SSLCanvas.xaml"
            this.GC.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SSLCanvas_MouseUp);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\Utilities\SSLCanvas.xaml"
            this.GC.MouseMove += new System.Windows.Input.MouseEventHandler(this.SSLCanvas_MouseMove);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dragSelect = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
