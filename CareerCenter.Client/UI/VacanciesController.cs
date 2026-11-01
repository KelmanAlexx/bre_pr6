using CareerCenter.Client.Models;
using CareerCenter.Client.Services;

namespace CareerCenter.Client.UI;

/// Класс презентационного слоя. Подготавливает данные для формы/страницы,
public sealed class VacanciesController
{
    private readonly ICareerCenterApiClient _apiClient;

    public VacanciesController(ICareerCenterApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<IReadOnlyList<Vacancy>> LoadVacanciesAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _apiClient.GetVacanciesAsync(cancellationToken);
        return response.Items;
    }
}
