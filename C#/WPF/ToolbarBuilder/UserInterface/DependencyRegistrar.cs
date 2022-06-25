using Microsoft.Extensions.DependencyInjection;

using ToolbarBuilder.UserInterface.Core;

namespace ToolbarBuilder.UserInterface
{
    /// <summary>
    /// Responsible for registering the dependencies to the DI container.
    /// </summary>
    public sealed  class DependencyRegistrar
    {
        /// <summary>
        /// Registers the types to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="container">The container to register.</param>
        public void Register(IServiceCollection container) 
        {
            container.AddTransient<IModuleInitializer, ModuleInitializer>();

            container.AddSingleton<IWindowFactory, WindowFactory>();
        }
    }
}
