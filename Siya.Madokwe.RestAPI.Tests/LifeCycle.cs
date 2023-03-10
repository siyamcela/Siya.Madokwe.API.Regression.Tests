using Boa.Constrictor.Screenplay;
using Siya.Madokwe.RestAPI.API;
using Siya.Madokwe.RestAPI.Tests.Constansts;
using TechTalk.SpecFlow;

namespace Siya.Madokwe.RestAPI.Tests
{
    [Binding]
    public class LifeCycle
    {

        [BeforeFeature()]
        public static void Setup(FeatureContext featureContext)
        {
            var logger = new ConsoleLogger();
            var url = string.Empty;

            try
            {
                var actor = new Actor(name: "Andy", logger: new ConsoleLogger());
                actor.Can(TheCocktailDbAPI.UsingBaseUrl());

                featureContext[StepConstants.ActorInstance] = actor;
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to setup test: {ex.Message}");

                // Throw the exception to continue as previously to ensure it is logged correctly.
                throw;
            }
        }
    }
}