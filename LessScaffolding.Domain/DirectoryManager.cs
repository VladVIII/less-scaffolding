using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using SharpYaml.Model;

namespace LessScaffolding.Domain
{
    public class DirectoryManager
    {
        private const string BaseDirectory = "C:\\Repos\\LessScaffolding\\LessScaffolding.Output\\Less";

        public void ParseYamlAndCreateStructure(string yamlString)
        {
            var openApiStringReader = new OpenApiStringReader();
            var openApiDocument = openApiStringReader.Read(yamlString, out _);

            var listOfDirectories = new List<LessDirectory>();

            foreach (var path in openApiDocument.Paths)
            { 
                var directory = new LessDirectory()
                {
                    Name = path.Key.Contains('{') ? $"/{path.Key.Split("/")[1]}" : path.Key
                };
                 
                var directories = new List<LessDirectory>();

                if (path.Key.Contains('{'))
                {
                    directories.Add(new LessDirectory()
                    {
                        Name = $"{directory.Name}/{{id}}",
                        Files = new List<LessFile>()
                        {
                           new()
                           {
                               Name = $"{directory.Name}/{{id}}/index.js"
                           } 
                        }
                    });
                }
                else
                {
                    //directories = path.Value.Operations.Select(o => new Directory() { Name = o.Key.ToString() })
                    //    .ToList();
                }

                directory.Files.Add(new LessFile()
                {
                    Name = $"${directory.Name}/index.js"
                });

                directory.Directories = directories;

                listOfDirectories.Add(directory);
            }

            foreach (var directory in listOfDirectories)
            {
                RecursiveDirectoryCreator(directory);
            }
        }

        public void RecursiveDirectoryCreator(LessDirectory lessDirectory)
        {
            var directoryPath = $"{BaseDirectory}{lessDirectory.Name}";
           

            Directory.CreateDirectory(directoryPath);

            foreach (var lessFile in lessDirectory.Files)
            {
                var templateString = File.ReadAllText("Templates/index.js");

                var filePath = $"{BaseDirectory}{lessFile.Name}";

                if (!File.Exists(filePath))
                {
                    File.WriteAllText($"{directoryPath}/index.js", templateString);
                }
            }

            if (lessDirectory.Directories.Count == 0) return;

            foreach (var directory in lessDirectory.Directories)
            {
                RecursiveDirectoryCreator(directory);
            }
        }

    }
}
