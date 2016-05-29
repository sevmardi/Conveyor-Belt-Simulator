﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "88F65790A4914E54E5BC84C68DE13697"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LaneSimulator;
using LaneSimulator.Lanes;
using LaneSimulator.Models.Components;
using LaneSimulator.Utilities.Selector;
using Microsoft.Expression.Controls;
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


namespace LaneSimulator {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 115 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid1;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LaneSimulator.SSLCanvas SSLCanvas;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LaneSimulator.Utilities.Selector.ObjectSelector SSLComponents;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spZoom;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slZoom;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnActualSize;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFitToScreen;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel traysCounter;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox1_Copy1;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox total_text1;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Timer;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Timer_Lable;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbFile;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbEdit;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCut;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCopy;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCopyAsImage;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPaste;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFlatten;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlignTopLeft;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbPrinting;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrint;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveAsImage;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChart;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbIC;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar tbVis;
        
        #line default
        #line hidden
        
        
        #line 267 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btnShowHideToolbars;
        
        #line default
        #line hidden
        
        
        #line 270 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btnShowTrueFalse;
        
        #line default
        #line hidden
        
        
        #line 277 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btnUserMode;
        
        #line default
        #line hidden
        
        
        #line 290 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spAppInfo;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblAppTitle;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblAppVersion;
        
        #line default
        #line hidden
        
        
        #line 293 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblAppCopyright;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblLink;
        
        #line default
        #line hidden
        
        
        #line 296 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblInfoLine;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas adornerLayer;
        
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
            System.Uri resourceLocater = new System.Uri("/LaneSimulator;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 23 "..\..\MainWindow.xaml"
            ((System.Windows.Media.Animation.DoubleAnimationUsingPath)(target)).Completed += new System.EventHandler(this.MyStoryboardCompleted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 36 "..\..\MainWindow.xaml"
            ((System.Windows.Media.Animation.DoubleAnimationUsingPath)(target)).Completed += new System.EventHandler(this.MyStoryboardCompleted);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.SSLCanvas = ((LaneSimulator.SSLCanvas)(target));
            return;
            case 5:
            this.SSLComponents = ((LaneSimulator.Utilities.Selector.ObjectSelector)(target));
            return;
            case 6:
            this.spZoom = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.slZoom = ((System.Windows.Controls.Slider)(target));
            
            #line 137 "..\..\MainWindow.xaml"
            this.slZoom.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slZoom_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnActualSize = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\MainWindow.xaml"
            this.btnActualSize.Click += new System.Windows.RoutedEventHandler(this.btnActualSize_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnFitToScreen = ((System.Windows.Controls.Button)(target));
            
            #line 143 "..\..\MainWindow.xaml"
            this.btnFitToScreen.Click += new System.Windows.RoutedEventHandler(this.btnFitToScreen_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.traysCounter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.textBox1_Copy1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.total_text1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.Timer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.Timer_Lable = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.tbFile = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 16:
            
            #line 205 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnNew_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 208 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOpen_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 211 "..\..\MainWindow.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 214 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSave_As_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.tbEdit = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 21:
            this.btnCut = ((System.Windows.Controls.Button)(target));
            
            #line 219 "..\..\MainWindow.xaml"
            this.btnCut.Click += new System.Windows.RoutedEventHandler(this.btnCut_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.btnCopy = ((System.Windows.Controls.Button)(target));
            
            #line 222 "..\..\MainWindow.xaml"
            this.btnCopy.Click += new System.Windows.RoutedEventHandler(this.btnCopy_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.btnCopyAsImage = ((System.Windows.Controls.Button)(target));
            
            #line 225 "..\..\MainWindow.xaml"
            this.btnCopyAsImage.Click += new System.Windows.RoutedEventHandler(this.btnCopyAsImage_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.btnPaste = ((System.Windows.Controls.Button)(target));
            
            #line 228 "..\..\MainWindow.xaml"
            this.btnPaste.Click += new System.Windows.RoutedEventHandler(this.btnPaste_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            this.btnFlatten = ((System.Windows.Controls.Button)(target));
            
            #line 231 "..\..\MainWindow.xaml"
            this.btnFlatten.Click += new System.Windows.RoutedEventHandler(this.btnFlatten_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.btnAlignTopLeft = ((System.Windows.Controls.Button)(target));
            
            #line 234 "..\..\MainWindow.xaml"
            this.btnAlignTopLeft.Click += new System.Windows.RoutedEventHandler(this.btnAlignTopLeft_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.tbPrinting = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 28:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            
            #line 241 "..\..\MainWindow.xaml"
            this.btnPrint.Click += new System.Windows.RoutedEventHandler(this.btnPrint_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            this.btnSaveAsImage = ((System.Windows.Controls.Button)(target));
            
            #line 245 "..\..\MainWindow.xaml"
            this.btnSaveAsImage.Click += new System.Windows.RoutedEventHandler(this.btnSaveAsImage_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            this.btnChart = ((System.Windows.Controls.Button)(target));
            
            #line 249 "..\..\MainWindow.xaml"
            this.btnChart.Click += new System.Windows.RoutedEventHandler(this.btnChart_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            this.tbIC = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 32:
            
            #line 257 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCreateIC_Click);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 258 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 258 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 260 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnImportIC_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            this.tbVis = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 36:
            this.btnShowHideToolbars = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 267 "..\..\MainWindow.xaml"
            this.btnShowHideToolbars.Checked += new System.Windows.RoutedEventHandler(this.btnShowHideToolbars_Checked);
            
            #line default
            #line hidden
            
            #line 267 "..\..\MainWindow.xaml"
            this.btnShowHideToolbars.Unchecked += new System.Windows.RoutedEventHandler(this.btnShowHideToolbars_Unchecked);
            
            #line default
            #line hidden
            return;
            case 37:
            this.btnShowTrueFalse = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 270 "..\..\MainWindow.xaml"
            this.btnShowTrueFalse.Checked += new System.Windows.RoutedEventHandler(this.btnShowTrueFalse_Checked);
            
            #line default
            #line hidden
            
            #line 270 "..\..\MainWindow.xaml"
            this.btnShowTrueFalse.Unchecked += new System.Windows.RoutedEventHandler(this.btnShowTrueFalse_Unchecked);
            
            #line default
            #line hidden
            return;
            case 38:
            this.btnUserMode = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 277 "..\..\MainWindow.xaml"
            this.btnUserMode.Checked += new System.Windows.RoutedEventHandler(this.btnUserMode_Checked);
            
            #line default
            #line hidden
            
            #line 277 "..\..\MainWindow.xaml"
            this.btnUserMode.Unchecked += new System.Windows.RoutedEventHandler(this.btnUserMode_Unchecked);
            
            #line default
            #line hidden
            return;
            case 39:
            this.spAppInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 40:
            this.lblAppTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 41:
            this.lblAppVersion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 42:
            this.lblAppCopyright = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 43:
            this.lblLink = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 44:
            this.lblInfoLine = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 45:
            this.adornerLayer = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

