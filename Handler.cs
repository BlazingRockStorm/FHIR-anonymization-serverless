using System;
using System.Net.Http;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

[assembly:LambdaSerializer(
  typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp{
  public class Function
  {
    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest proxyRequest)
    {
      return new APIGatewayProxyResponse
      {
        Body = proxyRequest.Body,
        StatusCode = 200,
      };
    }
  }
}
