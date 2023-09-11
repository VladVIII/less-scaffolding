using LessScaffolding.Domain;
using File = System.IO.File;

namespace LessScaffolding.Tests
{
    public class PrototypeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Prototyping()
        {
            var read = File.ReadAllText("Sample.yaml");

            var parser = new DirectoryManager(new LessConfig()
            {
                BaseDirectory = "C:\\Repos\\LessScaffolding\\LessScaffolding.Output\\Less"
            });

            parser.ParseYamlAndCreateStructure(read);
        }
    }
}