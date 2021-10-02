using System.Threading.Tasks;

namespace PicturesCompare.Domain.PhotoComparisonServices
{
    public interface IPhotoComparisonService
    {
        Task<bool> CompareAsync(string filePathImageA, string filePathImageB);
    }
}