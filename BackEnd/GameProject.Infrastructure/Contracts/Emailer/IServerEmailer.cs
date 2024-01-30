using GameProject.Identity.Models.Emailer;

namespace GameProject.Identity.Contracts.Emailer;

public interface IServerEmailer
{
    Task SendServerEmail(ServerEmailMessageRequest serverEmailMessageRequest);
}