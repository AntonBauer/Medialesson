using PicturesCompare.Domain.Enums;

namespace PicturesCompare.Domain.Options
{
    internal record HashServiceOptions
    {
        public const string Section = "PhotoComparison";
        
        public HashType HashType { get; init; }
    }
}