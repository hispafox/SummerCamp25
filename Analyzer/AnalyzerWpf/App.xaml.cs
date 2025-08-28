using Serilog;
using System;
using System.Windows;

namespace AnalyzerWpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // Ruta absoluta al proyecto fuente AnalyzerWpf
                var projectDir = @"C:\w\repos\SummerCamp25\Analyzer\AnalyzerWpf";
                var logDir = System.IO.Path.Combine(projectDir, "logs");
                if (!System.IO.Directory.Exists(logDir))
                    System.IO.Directory.CreateDirectory(logDir);
                var logPath = System.IO.Path.Combine(logDir, "wpf.log");
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                Log.Information("Aplicación WPF iniciada");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando Serilog: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.Information("Aplicación WPF finalizada");
            Log.CloseAndFlush();
            base.OnExit(e);
        }
    }
}
