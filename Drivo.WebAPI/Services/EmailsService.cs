using Drivo.Entities;
using Drivo.Responses;
using System.Net.Mail;

namespace Drivo.WebAPI.Services;

public class MailsService
{
    public MailsService(SmtpClient smtpClient, IConfiguration configuration)
    {
        SmtpClient = smtpClient;
        Configuration = configuration;
    }

    private SmtpClient SmtpClient { get; }
    private IConfiguration Configuration { get; }

    public async Task<ActionResponse> SendWelcomeMail(UserEntity user, string password)
    {
        try
        {
            var body = new StreamReader("./MailsTemplates/WelcomeMail.html").ReadToEnd();

            body = body.Replace("[FullName]", user.FullName);
            body = body.Replace("[UserName]", user.UserName);
            body = body.Replace("[Password]", password);

            await SmtpClient.SendMailAsync(new MailMessage(new MailAddress(Configuration["Credentials:UserName"], "Drivo"), new MailAddress(user.Email)) { Subject = $"DRIVO - Welcome - {user.FullName}", Body = body, IsBodyHtml = true });
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

            await SmtpClient.SendMailAsync(new MailMessage(new MailAddress(Configuration["Credentials:UserName"], "Drivo"), new MailAddress(user.Email)) { Subject = $"DRIVO - Notifications - {user.FullName}", Body = body, IsBodyHtml = true });
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Notifications Mail has been sent successfully.");
    }
}
