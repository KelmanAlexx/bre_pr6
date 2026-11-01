namespace CareerCenter.Client.Models;

/// Минимальный набор данных резюме, передаваемый работодателю.
public sealed class StudentResume
{
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? Phone { get; init; }
    public List<string> Skills { get; init; } = [];
    public string? Experience { get; init; }
    public string? PortfolioUrl { get; init; }
}
