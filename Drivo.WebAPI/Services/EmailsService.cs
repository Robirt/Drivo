using Drivo.Entities;
using Drivo.Responses;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Drivo.WebAPI.Services;

public class MailsService
{
    public MailsService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public async Task<ActionResponse> SendWelcomeMail(UserEntity user, string password)
    {
        try
        {
            var body = new StreamReader("./MailsTemplates/WelcomeMail.html").ReadToEnd();

            body = body.Replace("[FullName]", user.FullName);
            body = body.Replace("[UserName]", user.UserName);
            body = body.Replace("[Password]", password);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Drivo", Configuration.GetValue<string>("Smpt:Credentials:UserName")));
            message.To.Add(new MailboxAddress(user.FullName, user.Email));
            message.Subject = $"Witaj, {user.FullName}!";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(Configuration.GetValue<string>("Smpt:Host"), Configuration.GetValue<int>("Smpt:Port"), SecureSocketOptions.StartTls);

                client.Authenticate(Configuration.GetValue<string>("Smpt:Credentials:UserName"), Configuration.GetValue<string>("Smpt:Credentials:Password"));

                client.Send(message);
                client.Disconnect(true);
            }
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Welcome Mail has been sent successfully.");
    }

    public async Task<ActionResponse> SendNotificationsMail(UserEntity user, List<EventEntity> events)
    {
        try
        {
            var body = new StreamReader("./MailsTemplates/NotificationsMail.html").ReadToEnd();

            body = body.Replace("[FullName]", user.FullName);

            string notifications = "";
            foreach (var notification in events)
            {
                notifications += "<div>";
                notifications += $"<label><span>Nazwa</span><span>{notification.Name}</span></label>";
                notifications += $"<label><span>Data rozpoczęcia</span><span>{notification.StartDate.ToUniversalTime()}</span></label>";
                notifications += $"<label><span>Data zakończenia</span><span>{notification.EndDate.ToUniversalTime()}</span></label>";
                notifications += $"<label><span>Miejsce</span><span>{notification.Place}</span></label>";
                notifications += "</div>";
            }

            body = body.Replace("[Notifications]", notifications);
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Notifications Mail has been sent successfully.");
    }
}
