using FluentValidation.Validators;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Application.Options;

namespace ValidPeople.Application.Validators
{
    public class CpfNumberValidator : ICpfNumberValidator
    {
        private readonly string endpoint;
        private readonly HttpClient client;
        private const string validResult = "Verdadeiro";

        public CpfNumberValidator(IHttpClientFactory clientFactory, IOptions<IntegrationOptions> integrationOptions)
        {
            endpoint = integrationOptions.Value.CpfValidator4Devs.Url;
            client = clientFactory.CreateClient("CpfNumberValidator4DevsClient");
        }

        public async Task<bool> Validate(string cpf, CancellationToken cancellationToken)
        {
            var request = GetRequest(cpf);

            var response = await client.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            result = result.Replace($"{cpf} - ", string.Empty);

            return result == validResult;
        }

        private HttpRequestMessage GetRequest(string cpf)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var contentData = new List<KeyValuePair<string, string>>();
            contentData.Add(new KeyValuePair<string, string>("acao", "validar_cpf"));
            contentData.Add(new KeyValuePair<string, string>("txt_cpf", cpf));

            request.Content = new FormUrlEncodedContent(contentData);

            return request;
        }
    }
}
