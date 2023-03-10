

using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using FluentAssertions;
using NUnit.Framework;
using Siya.Madokwe.RestAPI.API;
using Siya.Madokwe.RestAPI.Models;
using System.Net;
using static Siya.Madokwe.RestAPI.Services.CocktailDbService;

namespace Siya.Madokwe.RestAPI.TestSuites
{

    public class CocktailDbTests
    {
        private IActor Actor;

        [SetUp]
        public void InitializeScreenplay()
        {
            Actor = new Actor(name: "Andy", logger: new ConsoleLogger());
            Actor.Can(TheCocktailDbAPI.UsingBaseUrl());

        }
        [Test]
        public void GetCocktailsByName()
        {
            string cocktail = "margarita";
            var request = CocktailDbRequests.GetCocktailsByName(cocktail);
            var response = Actor.Calls(Rest<TheCocktailDbAPI>.Request<CocktailDbResponse>(request));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
