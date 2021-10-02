namespace PicturesCompare.Domain.HashServices
{
    internal sealed class AverageHashService : IHashService
    {
        public int CalculateHash(string image)
        {
            return image.GetHashCode();
        }
    }
}