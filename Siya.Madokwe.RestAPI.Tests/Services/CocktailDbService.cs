using RestSharp;
using System;
using System.Threading.Tasks;

namespace Siya.Madokwe.RestAPI.Services
{
    public class CocktailDbService 
    {
       
        public static class CocktailDbRequests
        {

            public static IRestRequest GetCocktailsByName(string name) =>
              new RestRequest("api/json/v1/1/search.php?s="+name, Method.GET);
        }
       
    }
}
