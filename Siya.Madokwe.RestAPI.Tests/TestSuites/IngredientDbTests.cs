

using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using NUnit.Framework;
using RestSharp;
using static Siya.Madokwe.RestAPI.Services.CocktailDbService;
using FluentAssertions;
using System.Net;
using Siya.Madokwe.RestAPI.Models;
using Siya.Madokwe.RestAPI.Tests.Models;
using Siya.Madokwe.RestAPI.API;
using static Siya.Madokwe.RestAPI.Tests.Services.IngredientsDbService;
using Siya.Madokwe.RestAPI.Tests.Services;

namespace Siya.Madokwe.RestAPI.TestSuites
{

  public  class IngredientDbTests
    {
        private IActor Actor;

        [SetUp]
        public void InitializeScreenplay()
        {
            Actor = new Actor(name: "Andy", logger: new ConsoleLogger());
            Actor.Can(TheCocktailDbAPI.UsingBaseUrl());
           
        }
        [Test]
        public void GetIngredientByName()
        {

            string cocktail = "water";
            var request = IngredientsDbRequests.GetIngredientByName(cocktail);
            var response = Actor.Calls(Rest<TheCocktailDbAPI>.Request<IngredientResponse>(request));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
       
    }
}
