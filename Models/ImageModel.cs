using static System.Net.Mime.MediaTypeNames;

namespace yeto.Models
{
    public class ImageModel
    {
        public List<Photo> photos { get; set; }

        public class Photo
        {
            public Attribution attribution { get; set; }
            public Image image { get; set; }
        }

        public class Image
        {
            public string mobile { get; set; }
            public string web { get; set; }
        }

        public class Attribution
        {
            public string license { get; set; }
            public string photographer { get; set; }
            public string site { get; set; }
            public string source { get; set; }
        }
    }
}
