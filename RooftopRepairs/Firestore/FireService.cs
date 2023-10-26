using Google.Cloud.Firestore;
using RooftopRepairs.Models;

namespace RooftopRepairs.Firestore
{
    public sealed class FireService : IFireService
    {
        private static readonly FireService _instance = new FireService();
        private FirestoreDb? _db;
        private static List<ImageModel>? roofs;
        private static List<ImageModel>? waterproofing;
        private static List<ImageModel>? building;
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

            instance.Fire();
        }
        public async void Fire()
        {
            roofs = await getImagesFrom("Roofs");
            waterproofing = await getImagesFrom("Waterproofing");
            building = await getImagesFrom("Building");
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
                    Console.WriteLine(img.getUrl());
                    imgList.Add(img);
                } else throw new ArgumentNullException("Document snapshot is null");
            }

            return imgList;
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

        public bool isNull()
        {
            return instance._db == null;
        }
    }
}
