using System.Net.Http.Json;
using System.Text.Json;
using CareerCenter.Client.Models;

namespace CareerCenter.Client.Services;

/// Клиент интеграционного шлюза. Содержит HTTP-запросы и не зависит от UI.
/// HttpClient передаётся снаружи, поэтому его можно настроить в точке запуска приложения.
public sealed class CareerCenterApiClient : ICareerCenterApiClient
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public CareerCenterApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// Получает страницу актуальных стажировок (по умолчанию первую).
    public async Task<VacancyListResponse> GetVacanciesAsync(
        CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync("vacancies", cancellationToken);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<VacancyListResponse>(
            JsonOptions, cancellationToken);

        return result ?? throw new JsonException("Сервер вернул пустой ответ со списком вакансий.");
    }

    /// Отправляет отклик студента на выбранную вакансию.
    public async Task<ApplicationSubmitResponse> SubmitApplicationAsync(
        ApplicationSubmitRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var response = await _httpClient.PostAsJsonAsync(
            "applications/submit", request, JsonOptions, cancellationToken);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ApplicationSubmitResponse>(
            JsonOptions, cancellationToken);

        return result ?? throw new JsonException("Сервер вернул пустой ответ после отправки отклика.");
    }
}
