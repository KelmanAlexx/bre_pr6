namespace CareerCenter.Client.Models;

/// Данные об одной актуальной стажировке.
public sealed class Vacancy
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Company { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string WorkFormat { get; init; } = string.Empty;
    public string EmploymentType { get; init; } = string.Empty;
    public List<string> Skills { get; init; } = [];
    public decimal? SalaryFrom { get; init; }
    public DateTimeOffset PublishedAt { get; init; }
    public DateOnly? ApplicationDeadline { get; init; }
    public bool IsActive { get; init; }
}
