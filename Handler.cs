using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Health.Fhir.Anonymizer.Core;
using Microsoft.Health.Fhir.Anonymizer.Core.AnonymizerConfigurations;

[assembly:LambdaSerializer(
  typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp{
  public class Function
  {
    public APIGatewayProxyResponse HandlerR4(APIGatewayProxyRequest proxyRequest)
    {
      // from FHIR\src\Microsoft.Health.Fhir.Anonymizer.Shared.Core.UnitTests\AnonymizerEngineTests.cs
      AnonymizerEngine engine = new AnonymizerEngine("r4-configuration.json");
      var settings = new AnonymizerSettings()
        {
          IsPrettyOutput = true
        };
      var output = engine.AnonymizeJson(proxyRequest.Body, settings);

      return new APIGatewayProxyResponse
      {
        Body = output,
        StatusCode = 200,
      };
    }
  }
}
