using ConEd.Views.Controls.AttachedProperties;
using ConEd.Views.Views.PayMyBillViews;
using ConEd3.ViewModels;
using ConEd3.ViewModels.PayMyBillViewModels;
using Microsoft.Extensions.Logging;

namespace ConEd.Views {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialDesignIconsDesktop.ttf", "MaterialIcons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Centralized UI routing manifest
            RegionManager.Register<CurrentBillViewModel, CurrentBillView>();
            RegionManager.Register<BillHistoryViewModel, BillHistoryView>();
            RegionManager.Register<PayBillViewModel, PayBillView>();

            return builder.Build();
        }
    }
}
