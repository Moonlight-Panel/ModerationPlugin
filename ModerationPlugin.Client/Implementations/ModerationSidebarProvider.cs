using Moonlight.Client.App.Interfaces;
using Moonlight.Client.App.Models;

namespace ModerationPlugin.Client.Implementations;

public class ModerationSidebarProvider : ISidebarItemProvider
{
    public SidebarItem[] GetItems()
    {
        return [
            new SidebarItem()
            {
                Group = "Admin",
                Icon = "bi bi-hammer",
                Name = "Moderation",
                Permission = "admin.moderation.userbans.get",
                Priority = 3,
                Target = "/admin/moderation"
            }
        ];
    }
}