using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            DataWrite = citydata.summary;
            Scores = citydata.categories;
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
