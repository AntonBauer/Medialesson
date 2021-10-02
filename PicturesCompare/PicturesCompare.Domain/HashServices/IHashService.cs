namespace PicturesCompare.Domain.HashServices
{
    internal interface IHashService
    {
        int CalculateHash(string image);
    }
}