namespace Shared.Models;

public record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
}