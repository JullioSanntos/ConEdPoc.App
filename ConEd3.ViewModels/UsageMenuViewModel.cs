using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConEd3.ViewModels.UsageMenuViewModels;

namespace ConEd3.ViewModels {
    public partial class UsageMenuViewModel: BaseViewModel {

        public const string BillingRoute = nameof(BillingRoute);
        public const string UsageDetailRoute = nameof(UsageDetailRoute);
        public const string SimilarHomesRoute = nameof(SimilarHomesRoute);

        // Child ViewModels utilizing C# 12 primary constructor / field keyword pattern
        public BillingViewModel BillingVm => field ??= new();
        public UsageDetailViewModel UsageDetailVm => field ??= new();
        public SimilarHomesViewModel SimilarHomesVm => field ??= new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsBillingActive), nameof(IsUsageDetailActive), nameof(IsSimilarHomesActive))]
        public partial object ActiveViewModel { get; set; }

        public bool IsBillingActive => ActiveViewModel == BillingVm;
        public bool IsUsageDetailActive => ActiveViewModel == UsageDetailVm;
        public bool IsSimilarHomesActive => ActiveViewModel == SimilarHomesVm;

        public UsageMenuViewModel() {
            // Defaulting to UsageDetail to match the current mockup flow
            ActiveViewModel = UsageDetailVm!;
        }

        [RelayCommand]
        private void SwitchTab(string route) {
            ActiveViewModel = route switch {
                BillingRoute => BillingVm,
                UsageDetailRoute => UsageDetailVm,
                SimilarHomesRoute => SimilarHomesVm,
                _ => UsageDetailVm
            };
        }
    }
}
