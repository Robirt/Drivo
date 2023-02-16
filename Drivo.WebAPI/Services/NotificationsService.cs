using Drivo.Entities;
using Drivo.Responses;

namespace Drivo.WebAPI.Services;

public class NotificationsService
{
    private AdministratorsService AdministratorsService { get; }
    private LecturersService LecturersService { get; }
    private InstructorsService InstructorsService { get; }
    private StudentsService StudentsService { get; }

    private MailsService MailsService { get; }
}
