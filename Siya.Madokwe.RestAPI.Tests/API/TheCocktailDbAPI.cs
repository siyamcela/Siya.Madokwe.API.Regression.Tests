using Boa.Constrictor.RestSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siya.Madokwe.RestAPI.API
{
   public class TheCocktailDbAPI : AbstractRestSharpAbility
    {
        public const string BaseUrl = "https://www.thecocktaildb.com/";

        private TheCocktailDbAPI(RestClient client) :
            base(client)
        { }

        public static TheCocktailDbAPI UsingBaseUrl() =>
            new TheCocktailDbAPI(new RestClient(BaseUrl));
    }
}
