using RooftopRepairs.Models;

namespace RooftopRepairs.Firestore
{
    public interface IFireService
    {
        public List<ImageModel>? getRoofImgs();
        public List<ImageModel>? getWaterproofingImgs();
        public List<ImageModel>? getBuildingImgs();
        public List<ImageModel>? getHomeImgs();
        public List<ImageModel>? getAboutUsImgs();
        public bool Loaded();
    }
}
