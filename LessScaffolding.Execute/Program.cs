using LessScaffolding.Domain;
using File = System.IO.File;

if (args.Length < 1)
{
    throw new ArgumentException("You have to specify at least Open API specification source parameter.");
}

var currentDirectory = System.IO.Directory.GetCurrentDirectory();
var openApiSpecificationSource = args[0];
var baseOutputDirectory = (args.Length == 2 && !string.IsNullOrEmpty(args[1])) ? args[1] : $"{currentDirectory}/Less";

var directoryManager = new DirectoryManager(new LessConfig()
{
    BaseDirectory = baseOutputDirectory
});

if (Uri.IsWellFormedUriString(openApiSpecificationSource, UriKind.Absolute))
{
    var httpClient = new HttpClient();
    var openApiString = await httpClient.GetStringAsync(args[0]);
    directoryManager.ParseYamlAndCreateStructure(openApiString);

    return;
}

if (File.Exists(openApiSpecificationSource))
{
    var openApiString = File.ReadAllText(args[0]);
    directoryManager.ParseYamlAndCreateStructure(openApiString);

    return;
}

throw new ArgumentException("Parameters are not valid.");




