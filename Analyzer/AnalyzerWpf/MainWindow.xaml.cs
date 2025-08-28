using AnalyzerWpf.ViewModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Serilog;
using SlnParser.Contracts;
using System.Collections.Generic;

namespace AnalyzerWpf
{
    public partial class MainWindow : Window
    {
        private string selectedFilePath = "";
        private readonly SolutionViewModel solutionViewModel = new SolutionViewModel();

        public MainWindow()
        {
            InitializeComponent();
            TreeStructure.ItemsSource = solutionViewModel.Projects;
        }

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Solución o Proyecto|*.sln;*.csproj",
                Title = "Selecciona un archivo .sln o .csproj"
            };
            if (dialog.ShowDialog() == true)
            {
                selectedFilePath = dialog.FileName;
                TxtSelectedFile.Text = $"Archivo seleccionado: {selectedFilePath}";
                solutionViewModel.LoadSolution(selectedFilePath);
                TreeStructure.ItemsSource = solutionViewModel.Projects;
                ProjectFilesList.ItemsSource = null;
            }
        }

        private void TreeStructure_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedProject = TreeStructure.SelectedItem as IProject;
            if (selectedProject != null)
            {
                List<string> files = solutionViewModel.GetProjectFiles(selectedProject);
                ProjectFilesList.ItemsSource = files;
            }
            else
            {
                ProjectFilesList.ItemsSource = null;
            }
        }
    }
}
