﻿#pragma checksum "..\..\..\Pages\AddReceptionPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E1273F2D742634F126234260F942E77E888EAD9252E75A67B9F9BAF7152D18E7"
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
    /// AddReceptionPage
    /// </summary>
    public partial class AddReceptionPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbAddMedRecToReception;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxAddComplaintsToReception;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxAddAdditionsToDiagnoseToReception;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxAddAppointmentToReception;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbAddDiagnoseToReception;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveAddPatient;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Pages\AddReceptionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPreviousPage;
        
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
            System.Uri resourceLocater = new System.Uri("/Hospital_WPF;component/pages/addreceptionpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddReceptionPage.xaml"
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
            this.CmbAddMedRecToReception = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.TxtBoxAddComplaintsToReception = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtBoxAddAdditionsToDiagnoseToReception = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtBoxAddAppointmentToReception = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CmbAddDiagnoseToReception = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.BtnSaveAddPatient = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Pages\AddReceptionPage.xaml"
            this.BtnSaveAddPatient.Click += new System.Windows.RoutedEventHandler(this.BtnSaveAddPatient_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnPreviousPage = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\Pages\AddReceptionPage.xaml"
            this.BtnPreviousPage.Click += new System.Windows.RoutedEventHandler(this.BtnPreviousPage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

