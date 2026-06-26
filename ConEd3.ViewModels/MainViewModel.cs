using CommunityToolkit.Mvvm.ComponentModel;
using ConEd3.ViewModels.PayMyBillViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConEd3.ViewModels {

    public partial class MainViewModel : ObservableObject {
        private static readonly Lazy<MainViewModel> _instance = new(() => new MainViewModel());
        public static MainViewModel Instance => _instance.Value;

        protected MainViewModel() { } // Protected constructor for unit testing and to prevent external instantiation
        public ContactUsMenuViewModel ContactUsMenuViewModel => field ??= new ();
        public ManageMenuViewModel ManageMenuViewModel => field ??= new ();
        public OutageMenuViewModel OutageMenuViewModel => field ??= new ();
        public PayMyBillMenuViewModel PayMyBillMenuViewModel => field ??= new();
        public UsageMenuViewModel UsageMenuViewModel => field ??= new();

    }

}
