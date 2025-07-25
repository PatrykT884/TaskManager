using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;
using TaskManager.App.ViewModels;

namespace TaskManager.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            Services = services.BuildServiceProvider();

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }


        private void ConfigureServices(IServiceCollection services)
        {
            // ViewModels
            services.AddSingleton<MainViewModel>();

            // Views
            services.AddSingleton<MainWindow>();

            // Services & repositories – będą dodawane później

            // Database context
            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseSqlite("Data Source=tasks.db");
            });
        }

    }
}
