using MimeKit.Text;

namespace GameProject.Identity.Models.Emailer;

public class ServerEmailMessageRequest
{
    public string ReceiverName { get; set; } = string.Empty;
    public string ReceiverEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public TextFormat Format { get; set; }
}