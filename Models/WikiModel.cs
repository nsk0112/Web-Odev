namespace yeto.Models
{
    public class WikiModel
    {
        //public int age { get; set; }
        //public int count { get; set; }
        //public string name { get; set; }

        public string batchcomplete { get; set; }
        public Query query { get; set; }

        public class Query
        {
            public List<Normalized> normalized { get; set; }
            public Dictionary<string, Page> pages { get; set; }
        }

        public class Normalized
        {
            public string from { get; set; }
            public string to { get; set; }
        }

        public class Page
        {
            public string extract { get; set; }
        }

    }
}
