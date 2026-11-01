namespace CareerCenter.Client.Models;

/// Данные, необходимые для отправки отклика на вакансию.
public sealed class ApplicationSubmitRequest
{
    public Guid VacancyId { get; init; }
    public Guid StudentId { get; init; }
    public StudentResume Resume { get; init; } = new();
    public string? CoverLetter { get; init; }
}
