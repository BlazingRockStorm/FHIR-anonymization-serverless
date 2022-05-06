using Amazon.Lambda.APIGatewayEvents;

[assembly:LambdaSerializer(
  typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AwsDotnetCsharp;
public class Function
{
    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest request)
    {
      return new APIGatewayProxyResponse
      {
          Body = request.Body,
          StatusCode = 200,
      };
  }
}
