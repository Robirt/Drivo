using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class ExternalExamsService
{
    public ExternalExamsService(ExternalExamsRepository externalExamsRepository, StudentsService studentsService)
    {
        ExternalExamsRepository = externalExamsRepository;
        StudentsService = studentsService;
    }

    private ExternalExamsRepository ExternalExamsRepository { get; }
    private StudentsService StudentsService { get; }

    public async Task<List<ExternalExamEntity>> GetExternalExamsByStudentAsync(string studentUserName)
    {
        return await ExternalExamsRepository.GetExternalExamsByStudentAsync(await StudentsService.GetStudentByUserNameAsync(studentUserName));
    }

    public async Task<ActionResponse> AddExternalExamAsync(ExternalExamEntity externalExam, string studentUserName)
    {
        externalExam.StudentId = (await StudentsService.GetStudentByUserNameAsync(studentUserName)).Id;

        return await ExternalExamsRepository.AddExternalExamAsync(externalExam);
    }

    public async Task<ActionResponse> UpdateExternalExamAsync(ExternalExamEntity externalExam, string studentUserName)
    {
        if (externalExam.Student.UserName != studentUserName)
        {
            return new ActionResponse(false, "Student is not assigned to this External Exam.");
        }

        return await ExternalExamsRepository.UpdateExternalExamAsync(externalExam);
    }

    public async Task<ActionResponse> RemoveExternalExamAsync(int externalExamId, string studentUserName)
    {
        var externalExam = await ExternalExamsRepository.GetExternalExamById(externalExamId);

        if (externalExam is null)
        {
            return new ActionResponse(false, "External Exam was not found");
        }

        if (externalExam.Student.UserName != studentUserName)
        {
            return new ActionResponse(false, "Student is not assigned to this External Exam.");
        }

        return await ExternalExamsRepository.RemoveExternalExamAsync(externalExam);
    }
}
