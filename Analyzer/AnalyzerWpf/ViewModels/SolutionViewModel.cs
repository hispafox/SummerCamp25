using System.Collections.ObjectModel;
using System.Linq;
using SlnEasyParser;
using SlnParser.Contracts;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using Microsoft.Extensions.Configuration;

namespace AnalyzerWpf.ViewModels
{
    public class SolutionViewModel
    {
        public ObservableCollection<IProject> Projects { get; } = new ObservableCollection<IProject>();
        public string SolutionPath { get; set; }
        public string OpenAIApiKey { get; set; }

        public SolutionViewModel()
        {
            // Leer la API key desde appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            OpenAIApiKey = config["OpenAI:ApiKey"];
        }

        public void LoadSolution(string solutionPath)
        {
            SolutionPath = solutionPath;
            var parser = new SolutionParser();
            var parsedSolution = parser.Parse(solutionPath);
            Projects.Clear();
            foreach (var project in parsedSolution.AllProjects)
            {
                Projects.Add(project);
            }
        }

        // Devuelve la lista de archivos fuente (.cs, .xaml, etc.) de un proyecto
        public List<string> GetProjectFiles(IProject project)
        {
            var files = new List<string>();
            // Hacemos cast a SolutionProject para acceder a la propiedad File
            var solutionProject = project as SlnParser.Contracts.SolutionProject;
            if (solutionProject?.File == null || !File.Exists(solutionProject.File.FullName))
            {
                files.Add("No se encontró el archivo de proyecto o no es válido.");
                return files;
            }

            // Obtener el directorio del proyecto
            var projectDir = Path.GetDirectoryName(solutionProject.File.FullName);
            if (string.IsNullOrEmpty(projectDir) || !Directory.Exists(projectDir))
            {
                files.Add("No se encontró el directorio del proyecto.");
                return files;
            }

            // Buscar archivos relevantes en el directorio y subdirectorios
            var patterns = new[] { "*.cs", "*.xaml", "*.resx", "*.config", "*.json" };
            foreach (var pattern in patterns)
            {
                files.AddRange(Directory.GetFiles(projectDir, pattern, SearchOption.AllDirectories));
            }

            if (files.Count == 0)
                files.Add("No se encontraron archivos en el proyecto.");
            return files;
        }

        public void DebugProjectFiles()
        {
            foreach (var project in Projects)
            {
                var files = GetProjectFiles(project);
                Serilog.Log.Information($"Proyecto: {project.Name} - Archivos encontrados: {files.Count}");
                foreach (var file in files)
                {
                    Serilog.Log.Information($"    {file}");
                }
            }
        }

        // Analiza los archivos fuente de un proyecto usando OpenAI
        public async Task<string> AnalyzeProjectWithOpenAI(IProject project)
        {
            var files = GetProjectFiles(project).Where(f => File.Exists(f)).ToList();
            if (files.Count == 0)
                return "No se encontraron archivos fuente para analizar.";

            var api = new OpenAIClient(new OpenAIAuthentication(OpenAIApiKey));
            var analysisResults = new List<string>();

            foreach (var file in files)
            {
                var content = await File.ReadAllTextAsync(file);
                var prompt = $"Analiza el siguiente archivo fuente y proporciona un resumen y posibles mejoras:\n\n{content}";
                var chatRequest = new ChatRequest(
                    new[] { new Message(Role.System, prompt) },
                    model: Model.GPT4_Turbo
                );
                var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
                var result = response.FirstChoice?.Message?.Content ?? "Sin respuesta de OpenAI.";
                analysisResults.Add($"Archivo: {Path.GetFileName(file)}\n{result}\n");
            }
            return string.Join("\n---\n", analysisResults);
        }
    }
}
