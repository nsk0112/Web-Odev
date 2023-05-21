namespace yeto.Models
{
    public class CityModel
    {
        public List<Category> categories { get; set; }
        public string summary { get; set; }

        public class Category
        {
            public string color { get; set; }
            public string name { get; set; }
            public double score_out_of_10 { get; set; }
        }

        public class UaImages
        {
            public string href { get; set; }
        }

        public class Links
        {
            public UaImages uaimages { get; set; }
        }
    }
}
