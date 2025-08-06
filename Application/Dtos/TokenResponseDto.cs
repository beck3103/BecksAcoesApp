using System.Text.Json.Serialization;

namespace BeckAcoesApp.Application.Dtos;

public sealed class TokenResponseDto
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
}