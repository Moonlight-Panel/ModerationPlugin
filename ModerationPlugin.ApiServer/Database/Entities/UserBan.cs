using Moonlight.ApiServer.App.Database.Entities;

namespace ModerationPlugin.ApiServer.Database.Entities;

public class UserBan
{
    public int Id { get; set; }
    
    public string Reason { get; set; } = "";
    public string Comment { get; set; } = "";
    public int DurationDays { get; set; } = int.MaxValue;
    public int UserId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}