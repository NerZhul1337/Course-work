﻿#pragma checksum "..\..\..\Pages\ViewEmployeePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F4DFD669820BA0C155D5FC945DE1297AEBACB863CA30B31F639930F89AB2EFC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Hospital_WPF.Pages;
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


namespace Hospital_WPF.Pages {
    
    
    /// <summary>
    /// ViewEmployeePage
    /// </summary>
    public partial class ViewEmployeePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 37 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SrcSurnameDoctorTxtBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SrcSpecializationTxtBox;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LstBoxAnalyticsData;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NavToAddEmployeePageBtn;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelEmployeeBtn;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NavToMainViewPage;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Pages\ViewEmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LstViewEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/Hospital_WPF;component/pages/viewemployeepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ViewEmployeePage.xaml"
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
            
            #line 10 "..\..\..\Pages\ViewEmployeePage.xaml"
            ((Hospital_WPF.Pages.ViewEmployeePage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SrcSurnameDoctorTxtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Pages\ViewEmployeePage.xaml"
            this.SrcSurnameDoctorTxtBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SrcSurnameDoctorTxtBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SrcSpecializationTxtBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\Pages\ViewEmployeePage.xaml"
            this.SrcSpecializationTxtBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SrcSpecializationTxtBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LstBoxAnalyticsData = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.NavToAddEmployeePageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\Pages\ViewEmployeePage.xaml"
            this.NavToAddEmployeePageBtn.Click += new System.Windows.RoutedEventHandler(this.NavToAddEmployeePageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DelEmployeeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\Pages\ViewEmployeePage.xaml"
            this.DelEmployeeBtn.Click += new System.Windows.RoutedEventHandler(this.DelEmployeeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NavToMainViewPage = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\Pages\ViewEmployeePage.xaml"
            this.NavToMainViewPage.Click += new System.Windows.RoutedEventHandler(this.NavToMainViewPage_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LstViewEmployee = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 163 "..\..\..\Pages\ViewEmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavToEditEmployeePagebtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

