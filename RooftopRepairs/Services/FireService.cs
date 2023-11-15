using Google.Cloud.Firestore;
using RooftopRepairs.Interfaces;
using RooftopRepairs.Models;
using System.Linq.Expressions;

namespace RooftopRepairs.Firestore
{
    public sealed class FireService : IFireService
    {
        private static readonly FireService _instance = new FireService();
        private FirestoreDb? _db;
        private static List<ImageModel>? roofs;
        private static List<ImageModel>? waterproofing;
        private static List<ImageModel>? building;
        private static List<ImageModel>? home;
        private static List<ImageModel>? aboutUs;
        private static bool loaded;
        public static FireService instance
        {
            get { return _instance; }
        }    
        static FireService()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"teslarooftoprepair-firebase.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            instance._db = FirestoreDb.Create("teslarooftoprepair");

            roofs = new List<ImageModel>();
            waterproofing = new List<ImageModel>();
            building = new List<ImageModel>();
            home = new List<ImageModel>();
            aboutUs = new List<ImageModel>();

            instance.Fire();
        }
        public async Task Fire()
        {
            home = await getImagesFrom("Home");
            roofs = await getImagesFrom("Roofs");
            waterproofing = await getImagesFrom("Waterproofing");
            building = await getImagesFrom("Building");
            loaded = true;
        }

        public async Task<List<ImageModel>> getImagesFrom(string collection)
        {
            CollectionReference collRef = instance._db.Collection("Tesla").Document("Images").Collection(collection);
            QuerySnapshot collSnap = await collRef.GetSnapshotAsync();
            List<ImageModel> imgList = new List<ImageModel>(); 

            foreach (DocumentSnapshot snap in collSnap)
            {
                if (snap.Exists)
                {
                    ImageModel img = new ImageModel();
                    Dictionary<string, object> image = snap.ToDictionary();
                    foreach(var item in image)
                    {
                        if (item.Key == "url") img.setUrl(item.Value.ToString());
                        if (item.Key == "desc") img.setDesc(item.Value.ToString());
                    }
                    imgList.Add(img);
                } else throw new ArgumentNullException("Document snapshot is null");
            }
            if (collection != "Home" && collection != "AboutUs")
                return imgList.OrderBy(x => Random.Shared.Next()).ToList();
            else return imgList;
        }

        public List<ImageModel>? getRoofImgs()
        {
            return roofs;
        }
        public List<ImageModel>? getWaterproofingImgs()
        {
            return waterproofing;
        }
        public List<ImageModel>? getBuildingImgs()
        {
            return building;
        }
        public List<ImageModel>? getHomeImgs()
        {
            return home;
        }
        public List<ImageModel>? getAboutUsImgs()
        {
            return aboutUs;
        }

        public bool Loaded() { return loaded; }

        public bool isNull()
        {
            return instance._db == null;
        }
    }
}
