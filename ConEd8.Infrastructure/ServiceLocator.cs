namespace ConEd8.Infrastructure;

public class ServiceLocator {
    // The static backing field for the singleton instance
    private static ServiceLocator? _instance;

    // Now readonly and strictly non-nullable. No more compiler warnings!
    private readonly IServiceProvider _serviceProvider;

    // 1. Private constructor guarantees the provider is set upon instantiation
    private ServiceLocator(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    // 2. The Static Factory Method
    public static void Initialize(IServiceProvider serviceProvider) {
        _instance = new ServiceLocator(serviceProvider);
    }

    // 3. The safe accessor for the Singleton instance
    public static ServiceLocator Current =>
        _instance ?? throw new InvalidOperationException("ServiceLocator has not been initialized. Call Initialize() in MauiProgram.cs.");

    // 4. The instance-level resolution method
    public T GetService<T>() where T : notnull {
        return _serviceProvider.GetRequiredService<T>();
    }
}
