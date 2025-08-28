using System.Collections.Generic;
using SlnParser;
using SlnParser.Contracts;

namespace SlnEasyParser
{
    public class SolutionParser
    {
        private readonly SlnParser.SolutionParser _parser = new SlnParser.SolutionParser();

        public ParsedSolution Parse(string solutionPath)
        {
            var parsed = _parser.Parse(solutionPath);
            return new ParsedSolution(parsed);
        }
    }

    public class ParsedSolution
    {
        private readonly ISolution _solution;
        public ParsedSolution(ISolution solution)
        {
            _solution = solution;
        }
        public IReadOnlyList<IProject> AllProjects => new List<IProject>(_solution.AllProjects);
        public IReadOnlyList<IProject> Projects => new List<IProject>(_solution.Projects);
    }
}

/*
// Ejemplo de uso:
var parser = new SlnEasyParser.SolutionParser();
var parsedSolution = parser.Parse("path/to/your/solution.sln");
var flat = parsedSolution.AllProjects;
var structured = parsedSolution.Projects;
var noFolders = parsedSolution.AllProjects.Where(p => p.Type != ProjectType.SolutionFolder);
var csharpProjects = parsedSolution.AllProjects.Where(project => project.Type == ProjectType.CSharp);
*/
