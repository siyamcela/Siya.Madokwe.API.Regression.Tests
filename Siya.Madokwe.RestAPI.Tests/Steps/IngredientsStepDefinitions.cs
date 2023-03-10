using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using FluentAssertions;
using Siya.Madokwe.RestAPI.API;
using Siya.Madokwe.RestAPI.Models;
using Siya.Madokwe.RestAPI.Tests.Constansts;
using Siya.Madokwe.RestAPI.Tests.Models;
using System.Net;
using TechTalk.SpecFlow;
using static Siya.Madokwe.RestAPI.Tests.Services.IngredientsDbService;

namespace Siya.Madokwe.RestAPI.Tests.Steps
{
    [Binding]
    public class IngredientsStepDefinitions
    {
        private readonly Actor _actor;
        private readonly FeatureContext _featureContext;
        public IngredientsStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _actor = (Actor)featureContext[Constants.ActorInstance];
        }

        [Given(@"I search ingredient using '([^']*)'")]
        public void GivenISearchIngredientUsing(string ingredient)
        {
            var request = IngredientsDbRequests.GetIngredientByName(ingredient);
            var response = _actor.Calls(Rest<TheCocktailDbAPI>.Request<IngredientResponse>(request));
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _featureContext[Constants.Name] = ingredient;
            _featureContext[Constants.IngredientResponse] = response.Data;
        }
        [When(@"I verify ingridien search result match search")]
        public void ThenIVerifyIngridienSearchResultMatchSearch()
        {
            var name = _featureContext[Constants.Name].ToString();
            var ingredientResponse = (IngredientResponse)_featureContext[Constants.IngredientResponse];
            (ingredientResponse.ingredients.Count >= 1).Should().BeTrue();
            foreach (var drink in ingredientResponse.ingredients)
            {
                _featureContext[Constants.Ingredient] = drink;
                (drink.strIngredient.ToLower().Contains(name.ToLower())).Should().BeTrue();
            }
        }
        [Then(@"I want to verify if ingredient is non alcholic")]
        public void ThenIWantToVerifyIfIngredientIsNonAlcholic()
        {
            var isAlcholic = IsAcholic();
            isAlcholic.Should().BeFalse();
        }

        [Then(@"I want to verify if ingredient is alcholic")]
        public void ThenIWantToVerifyIfIngredientIsAlcholic()
        {

            var isAlcholic = IsAcholic();
            isAlcholic.Should().BeTrue();
        }
        private bool IsAcholic()
        {
            var ingredient = (Ingredient)_featureContext[Constants.Ingredient];
            bool IsAlcholic = false;

            if (ingredient.strAlcohol.ToLower() == Constants.Yes.ToLower() && !string.IsNullOrEmpty(ingredient.strABV.ToString()))
                IsAlcholic = true;
            return IsAlcholic;
        }
    }
}
