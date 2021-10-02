namespace PicturesCompare.Cli
{
    public record CompareOptions
    {
        public const string Section = "Compare";
        
        public string ImageA { get; init; }
        
        public string ImageB { get; init; }
    }
}