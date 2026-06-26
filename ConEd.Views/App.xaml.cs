using Microsoft.Extensions.DependencyInjection;

namespace ConEd.Views {
    public partial class App : Application {
        public App() {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState) {
            var window = new Window(new AppShell());

#if WINDOWS
        window.Width = 412;
        window.Height = 915;
        //window.MinimumWidth = 412;
        //window.MinimumHeight = 915;
        //window.MaximumWidth = 412;
        //window.MaximumHeight = 915;
#endif

            return window;
        }


    }
}