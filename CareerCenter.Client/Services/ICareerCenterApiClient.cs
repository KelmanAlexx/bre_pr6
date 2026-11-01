using CareerCenter.Client.Models;

namespace CareerCenter.Client.Services;

/// Контракт сетевого клиента для работы с интеграционным шлюзом.
public interface ICareerCenterApiClient
{
    Task<VacancyListResponse> GetVacanciesAsync(CancellationToken cancellationToken = default);

    Task<ApplicationSubmitResponse> SubmitApplicationAsync(
        ApplicationSubmitRequest request,
        CancellationToken cancellationToken = default);
}
