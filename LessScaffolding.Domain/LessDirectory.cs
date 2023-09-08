namespace LessScaffolding.Domain
{
    public class LessDirectory
    {
        public string? Name { get; set; }
        public List<LessFile> Files { get; set; } = new();
        public List<LessDirectory> Directories { get; set; } = new();
    }
}