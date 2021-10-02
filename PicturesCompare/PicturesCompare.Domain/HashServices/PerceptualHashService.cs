namespace PicturesCompare.Domain.HashServices
{
    internal sealed class PerceptualHashService : IHashService
    {
        public int CalculateHash(string image)
        {
            return image.GetHashCode();
        }
    }
}