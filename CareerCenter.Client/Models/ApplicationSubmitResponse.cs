namespace CareerCenter.Client.Models;

/// Результат регистрации отклика в интеграционном шлюзе.
public sealed class ApplicationSubmitResponse
{
    public Guid ApplicationId { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTimeOffset SubmittedAt { get; init; }
    public string Message { get; init; } = string.Empty;
}
