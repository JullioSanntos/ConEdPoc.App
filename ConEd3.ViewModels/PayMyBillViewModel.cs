using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConEd3.ViewModels {
    public partial class PayMyBillViewModel : ObservableObject {

        // The source generator creates a public property named 'SwitchTabCommand'
        [RelayCommand]
        private void SwitchTab(string tabName) {
            // Logic to swap the ActiveViewModel based on tabName
            System.Diagnostics.Debug.WriteLine($"Switched to tab: {tabName}");
        }
    }
}
