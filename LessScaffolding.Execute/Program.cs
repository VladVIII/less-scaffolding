// See https://aka.ms/new-console-template for more information

using LessScaffolding.Domain;
using File = System.IO.File;

Console.WriteLine("Hello, World!");

var read = File.ReadAllText("Sample.yaml");

var parser = new DirectoryManager();

parser.ParseYamlAndCreateStructure(read);