using System;
using System.Linq;
using SlnParser.Contracts;

namespace SlnParser
{
    /// <summary>
    /// Ejemplo de uso de SolutionParser para obtener proyectos de una solución.
    /// </summary>
    public static class ExampleUsage
    {
        /// <summary>
        /// Ejecuta el ejemplo usando la ruta de la solución.
        /// </summary>
        public static void Run(string solutionPath)
        {
            var parser = new SolutionParser();
            var parsedSolution = parser.Parse(solutionPath);

            // Flat list of all projects/solution folders
            var flat = parsedSolution.AllProjects;
            Console.WriteLine("Flat list of all projects and solution folders:");
            foreach (IProject project in flat)
                Console.WriteLine($"- {project.Name} [{project.Type}]");

            // Structured list (excluding solution folders)
            var structured = parsedSolution.Projects;
            Console.WriteLine("\nStructured list (excluding solution folders):");
            foreach (IProject project in structured)
                Console.WriteLine($"- {project.Name} [{project.Type}]");

            // Projects that are not solution folders
            var noFolders = parsedSolution.AllProjects.Where(p => p.Type != ProjectType.SolutionFolder);
            Console.WriteLine("\nProjects that are not solution folders:");
            foreach (IProject project in noFolders)
                Console.WriteLine($"- {project.Name} [{project.Type}]");

            // Projects of type CSharpClassLibrary
            var csharpProjects = parsedSolution.AllProjects.Where(project => project.Type == ProjectType.CSharp);
            Console.WriteLine("\nC# Class Library projects:");
            foreach (IProject project in csharpProjects)
                Console.WriteLine($"- {project.Name} [{project.Type}]");
        }
    }
}
