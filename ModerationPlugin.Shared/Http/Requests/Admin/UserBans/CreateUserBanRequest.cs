using System.ComponentModel.DataAnnotations;

namespace ModerationPlugin.Shared.Http.Requests.UserBans;

public class CreateUserBanRequest
{
    [Required(ErrorMessage = "You need to provide a reason")]
    public string Reason { get; set; } = "";

    public string Comment { get; set; } = "";
    
    [Range(1, int.MaxValue, ErrorMessage = "The duration needs to be greater than zero")]
    public int DurationDays { get; set; }

    [Required(ErrorMessage = "You need to provide a user id")]
    public int UserId { get; set; }
}