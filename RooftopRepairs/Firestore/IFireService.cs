using RooftopRepairs.Models;

namespace RooftopRepairs.Firestore
{
    public interface IFireService
    {
        public List<ImageModel>? getRoofImgs();
        public List<ImageModel>? getWaterproofingImgs();
        public List<ImageModel>? getBuildingImgs();
    }
}
