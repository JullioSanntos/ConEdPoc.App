using CommunityToolkit.Mvvm.ComponentModel;
using ConEd8.Infrastructure;

namespace ConEd3.ViewModels;

public abstract class BaseViewModel : ObservableObject {
    // Ambient context: accessible to all derived VMs, resolved via Locator
    protected MainViewModel MainState => ServiceLocator.Current.GetService<MainViewModel>();

    // You could also add protected ILogger Logger => ServiceLocator.GetService<ILogger>();
}
