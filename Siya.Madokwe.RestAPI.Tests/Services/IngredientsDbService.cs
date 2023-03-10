using RestSharp;
using Siya.Madokwe.RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siya.Madokwe.RestAPI.Tests.Services
{
    public class IngredientsDbService
    {
        public static class IngredientsDbRequests
        {
            public static IRestRequest GetIngredientByName(string name) =>
              new RestRequest("api/json/v1/1/search.php?i="+name, Method.GET);
        }
    }
}
