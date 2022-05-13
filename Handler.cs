using System;
using System.IO;
using System.Text;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Health.Fhir.Anonymizer.Core;
using Microsoft.Health.Fhir.Anonymizer.Core.AnonymizerConfigurations;
using Newtonsoft.Json;

[assembly:LambdaSerializer(
  typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp{
  public class Function
  {
    public APIGatewayProxyResponse HandlerR4(APIGatewayProxyRequest proxyRequest)
    {
      var configContext = File.ReadAllText("r4-configuration.json", Encoding.UTF8);
      LambdaLogger.Log("r4-configuration.json: " + JsonConvert.SerializeObject(configContext));

      AnonymizerEngine.InitializeFhirPathExtensionSymbols();

      var configurationManager = AnonymizerConfigurationManager.CreateFromSettingsInJson(configContext);
      var engine = new AnonymizerEngine(configurationManager);
      var output = engine.AnonymizeJson(proxyRequest.Body);

      return new APIGatewayProxyResponse
      {
        Body = output,
        StatusCode = 200,
      };
    }
  }
}
