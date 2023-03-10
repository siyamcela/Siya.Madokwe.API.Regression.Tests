using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using FluentAssertions;
using Siya.Madokwe.RestAPI.API;
using Siya.Madokwe.RestAPI.Models;
using Siya.Madokwe.RestAPI.Tests.Constansts;
using System.Net;
using TechTalk.SpecFlow;
using static Siya.Madokwe.RestAPI.Services.CocktailDbService;

namespace Siya.Madokwe.RestAPI.Tests.Steps
{
    [Binding]
    public class CocktailStepDefinitions
    {
        private readonly Actor _actor;
        private readonly FeatureContext _featureContext;
        public CocktailStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _actor = (Actor)featureContext[StepConstants.ActorInstance];
        }

        [Given(@"I search cocktail using '([^']*)'")]
        public void GivenIWantToSearchCocktailUsing(string vodka)
        {

            var request = CocktailDbRequests.GetCocktailsByName(vodka);
            var response = _actor.Calls(Rest<TheCocktailDbAPI>.Request<CocktailDbResponse>(request));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _featureContext[StepConstants.Name] = vodka;
            _featureContext[StepConstants.CocktailDbResponse] = response.Data;

        }

        [Then(@"I verify cocktail search result match search")]
        public void GivenIVerifySearchResultMatch()
        {
            var name = _featureContext[StepConstants.Name].ToString();
            var cocktailDbResponse = (CocktailDbResponse)_featureContext[StepConstants.CocktailDbResponse];
            (cocktailDbResponse.drinks.Count >= 1).Should().BeTrue();
            foreach (var drink in cocktailDbResponse.drinks)
            {
                (drink.strDrink.ToLower().Contains(name.ToLower())).Should().BeTrue();
            }
        }

        [Then(@"I verify search does not exit")]
        public void ThenIVerifySearchDoesNotExit()
        {
            var name = _featureContext[StepConstants.Name].ToString();
            var cocktailDbResponse = (CocktailDbResponse)_featureContext[StepConstants.CocktailDbResponse];
            cocktailDbResponse.drinks.Should().BeNullOrEmpty();
        }

    }
}
