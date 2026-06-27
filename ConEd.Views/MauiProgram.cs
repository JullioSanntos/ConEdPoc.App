using ConEd.Views.Controls.AttachedProperties;
using ConEd.Views.Views;
using ConEd.Views.Views.PayMyBillViews;
using ConEd.Views.Views.UsageMenuViews;
using ConEd3.ViewModels;
using ConEd3.ViewModels.PayMyBillViewModels;
using ConEd3.ViewModels.UsageMenuViewModels;
using ConEd8.Infrastructure;
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
            RegionManager.Register<UsageDetailViewModel, UsageDetailView>();

            builder.Services.AddTransient<ConEd3.ViewModels.MainViewModel>();

            var app = builder.Build();

            //Pass the built service provider into your locator
            ServiceLocator.Initialize(app.Services);

            return app;
        }
    }
}
