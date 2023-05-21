using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Text.RegularExpressions;
using yeto.Models;
using yeto.Services;

namespace yeto.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty]
        public string PokemonName { get; set; }




        [BindProperty]
        public string Term { get; set; }

        WikiModel wikidata { get; set; }

        [BindProperty]
        public string Data { get; set; }

        public void OnPostWikiRequest(JsonWikiService jsonWikiService)
        {

            Console.WriteLine(Term);
            wikidata = jsonWikiService.GetWikiModel(Term);

            Data = wikidata.query.pages.Values.FirstOrDefault().extract;
        }





        CityModel citydata { get; set; }
        ImageModel imagedata { get; set; }

        [BindProperty]
        public string ImgLink { get; set; }

        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string DataWrite { get; set; }

        [BindProperty]
        public List<CityModel.Category> Scores { get; set; }
        public void OnPostCityRequest(JsonWikiService jsonWikiService)
        {
            Console.WriteLine($"City: {City}");

            citydata = jsonWikiService.GetCityModel(City);
            var doc = new HtmlParser();
            var val = Regex.Replace(citydata.summary, @"<[^>]*>", String.Empty);
            DataWrite = val;
            Scores = citydata.categories;

            imagedata = jsonWikiService.GetImageModel(City);
            ImgLink = imagedata.photos[0].image.web;
        }





        [BindProperty]
        public string photoPath { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = "Misafir";
            }
        }

        public void OnPostPokemonRequest()
        {
            photoPath = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + PokemonName + ".png";
        }
    }
}
