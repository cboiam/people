using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Options;
using ValidPeople.Application.Validators;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace ValidPeople.IntegrationTests.Validators
{
    public class CpfNumberValidatorTest
    {
        private readonly CpfNumberValidator validator;
        private static readonly WireMockServer server = WireMockServer.Start(Url);
        
        private const string Url = "http://localhost:7060";

        public CpfNumberValidatorTest()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateClient("CpfNumberValidator4DevsClient"))
                .Returns(new HttpClient());

            var integrationOptions = new IntegrationOptions
            {
                CpfValidator4Devs = new UrlOptions { Url = Url }
            };

            validator = new CpfNumberValidator(httpClientFactory.Object, Options.Create(integrationOptions));
        }

        [Fact]
        public async Task Validate_ValidCpfResponse()
        {
            server.Given(Request.Create()
                    .UsingPost()
                    .WithBody("acao=validar_cpf&txt_cpf=323.463.290-10"))
                .RespondWith(Response.Create()
                    .WithBody("323.463.290-10 - Verdadeiro")
                    .WithSuccess());

            var result = await validator.Validate("323.463.290-10", new CancellationToken());

            Assert.True(result);
        }

        [Fact]
        public async Task Validate_InvalidCpfResponse()
        {
            server.Given(Request.Create()
                    .UsingPost()
                    .WithBody("acao=validar_cpf&txt_cpf=123.456.789-10"))
                .RespondWith(Response.Create()
                    .WithBody("123.456.789-10 - Falso")
                    .WithSuccess());

            var result = await validator.Validate("123.456.789-10", new CancellationToken());

            Assert.False(result);
        }
    }
}
