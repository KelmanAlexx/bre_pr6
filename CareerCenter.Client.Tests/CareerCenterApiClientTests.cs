using System.Net;
using System.Text;
using CareerCenter.Client.Services;
using Xunit;

namespace CareerCenter.Client.Tests;

public sealed class CareerCenterApiClientTests
{
    [Fact]
    public async Task GetVacanciesAsync_DeserializesJsonResponse()
    {
        // Arrange: имитируем ответ API, чтобы тесту не требовалось подключение к серверу.
        const string json = """
        {
          "items": [
            {
              "id": "11111111-1111-1111-1111-111111111111",
              "title": "Стажёр-разработчик C#",
              "company": "ООО ТехноПартнёр",
              "description": "Разработка и тестирование веб-сервисов.",
              "city": "Москва",
              "workFormat": "Гибридный",
              "employmentType": "Стажировка",
              "skills": ["C#", "SQL"],
              "salaryFrom": 25000,
              "publishedAt": "2026-10-20T09:00:00Z",
              "applicationDeadline": "2026-12-01",
              "isActive": true
            }
          ],
          "total": 1,
          "page": 1,
          "pageSize": 20
        }
        """;

        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        });
        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://localhost:7042/api/v1/")
        };
        var apiClient = new CareerCenterApiClient(httpClient);

        // Act: выполняем запрос и десериализуем JSON в модели C#.
        var result = await apiClient.GetVacanciesAsync();

        // Assert: проверяем, что основные поля корректно перенесены в объект.
        var vacancy = Assert.Single(result.Items);
        Assert.Equal(1, result.Total);
        Assert.Equal("Стажёр-разработчик C#", vacancy.Title);
        Assert.Equal("ООО ТехноПартнёр", vacancy.Company);
        Assert.Equal(2, vacancy.Skills.Count);
        Assert.True(vacancy.IsActive);
    }

    private sealed class StubHttpMessageHandler(
        Func<HttpRequestMessage, HttpResponseMessage> responseFactory) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(responseFactory(request));
        }
    }
}
