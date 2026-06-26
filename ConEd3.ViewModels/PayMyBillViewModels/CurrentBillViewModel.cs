using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConEd3.ViewModels.PayMyBillViewModels {
    public partial class CurrentBillViewModel : BaseViewModel {
        [RelayCommand]
#pragma warning disable CA1822 // Mark members as static
        public async Task PayBill() {
            await Task.CompletedTask; // placeholder until the real payment call goes here
            MainViewModel.Instance.PayMyBillMenuViewModel.ActiveViewModel 
                = MainViewModel.Instance.PayMyBillMenuViewModel.PayBillVm; 


        }
#pragma warning restore CA1822 // Mark members as static
    }
}
