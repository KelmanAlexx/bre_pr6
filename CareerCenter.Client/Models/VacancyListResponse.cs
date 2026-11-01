namespace CareerCenter.Client.Models;

/// Ответ API со страницей списка стажировок.
public sealed class VacancyListResponse
{
    public List<Vacancy> Items { get; init; } = [];
    public int Total { get; init; }
    public int Page { get; init; }
    public int PageSize { get; init; }
}
