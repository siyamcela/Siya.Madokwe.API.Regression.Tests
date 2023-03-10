using Boa.Constrictor.RestSharp;
using RestSharp;

namespace Siya.Madokwe.RestAPI.API
{
    public class IngredientsDbAPI : AbstractRestSharpAbility
    {
        public const string BaseUrl = "https://www.thecocktaildb.com/";

        private IngredientsDbAPI(RestClient client) :
            base(client)
        { }

        public static IngredientsDbAPI UsingBaseUrl() =>
            new IngredientsDbAPI(new RestClient(BaseUrl));
    }
}