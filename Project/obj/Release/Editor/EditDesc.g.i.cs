﻿#pragma checksum "..\..\..\Editor\EditDesc.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "328B2C322C9456D428C63F00009DAC48"
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
using Universal_Game_Configurator;


namespace Universal_Game_Configurator.Editor {
    
    
    /// <summary>
    /// EditDesc
    /// </summary>
    public partial class EditDesc : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listDesc;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTag;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImage;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtText;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNew;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Editor\EditDesc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRaw;
        
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
            System.Uri resourceLocater = new System.Uri("/Universal Game Configurator;component/editor/editdesc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Editor\EditDesc.xaml"
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
            
            #line 9 "..\..\..\Editor\EditDesc.xaml"
            ((Universal_Game_Configurator.Editor.EditDesc)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listDesc = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\..\Editor\EditDesc.xaml"
            this.listDesc.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listDesc_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\Editor\EditDesc.xaml"
            this.txtId.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtId_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtTag = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Editor\EditDesc.xaml"
            this.txtTag.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtTag_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtImage = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\Editor\EditDesc.xaml"
            this.txtImage.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtImage_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtText = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\Editor\EditDesc.xaml"
            this.txtText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtText_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDel = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Editor\EditDesc.xaml"
            this.btnDel.Click += new System.Windows.RoutedEventHandler(this.btnDel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnNew = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Editor\EditDesc.xaml"
            this.btnNew.Click += new System.Windows.RoutedEventHandler(this.btnNew_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Editor\EditDesc.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Editor\EditDesc.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnRaw = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Editor\EditDesc.xaml"
            this.btnRaw.Click += new System.Windows.RoutedEventHandler(this.btnRaw_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

