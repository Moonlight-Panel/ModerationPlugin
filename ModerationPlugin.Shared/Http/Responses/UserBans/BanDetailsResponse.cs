namespace ModerationPlugin.Shared.Http.Responses.UserBans;

public class BanDetailsResponse
{
    public string Reason { get; set; }
    public int DurationDays { get; set; }
    public DateTime CreatedAt { get; set; }
}