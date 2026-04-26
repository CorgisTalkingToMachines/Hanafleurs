using System.ComponentModel.DataAnnotations;

namespace API.Application.DataObjects.Queries;

public record GoogleLoginQuery(string Email, string Name, string GoogleId);