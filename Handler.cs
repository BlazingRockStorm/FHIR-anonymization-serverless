using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Health.Fhir.Anonymizer.Core;

[assembly:LambdaSerializer(
  typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp{
  public class Function
  {
    public APIGatewayProxyResponse HandlerR4(APIGatewayProxyRequest proxyRequest)
    {
      AnonymizerEngine engine = new AnonymizerEngine("r4-configuration-sample.json");

      var output = engine.AnonymizeJson(proxyRequest.Body, null);

      return new APIGatewayProxyResponse
      {
        Body = output,
        StatusCode = 200,
      };
    }
  }
}
