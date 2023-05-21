using System.Net;
using System.Text.Json;
using yeto.Models;

namespace yeto.Services
{
    public class JsonWikiService
    {
        public WikiModel GetWikiModel(string term)
        {
            string url = string.Concat("https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=", term);
            var json = new WebClient().DownloadString(url);
            WikiModel wikidata = JsonSerializer.Deserialize<WikiModel>(json);

            return wikidata;
        }


        public CityModel GetCityModel(string city)
        {
            string formatCity = city.ToLower().Replace(",", "-");
            formatCity = formatCity.Replace(" ", "-");
            string url = "https://api.teleport.org/api/urban_areas/slug:" + formatCity + "/scores/";
            Console.WriteLine(url);
            var json = new WebClient().DownloadString(url);
            CityModel citydata = JsonSerializer.Deserialize<CityModel>(json);

            return citydata;
        }


        public ImageModel GetImageModel(string city)
        {
            string formatCity = city.ToLower().Replace(",", "-");
            formatCity = formatCity.Replace(" ", "-");
            string url = "https://api.teleport.org/api/urban_areas/slug:" + formatCity + "/images/";
            var json = new WebClient().DownloadString(url);
            ImageModel imgUrl = JsonSerializer.Deserialize<ImageModel>(json);

            return imgUrl;
        }


        public WikiModel GetAgeModel(string term)
        {
            string url = string.Concat("https://api.agify.io/?name=", term);
            var json = new WebClient().DownloadString(url);
            WikiModel wikidata = JsonSerializer.Deserialize<WikiModel>(json);

            return wikidata;
        }
    }
}
