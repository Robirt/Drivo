using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class InternalExamsService
{
    public InternalExamsService(InternalExamsRepository internalExamsRepository)
    {
        InternalExamsRepository = internalExamsRepository;
    }

    private InternalExamsRepository InternalExamsRepository { get; }

    public async Task<List<InternalExamEntity>> GetInternalExamsByUserName(string userName)
    {
        return await InternalExamsRepository.GetInternalExamsByUserNameAsync(userName);
    }

    public async Task<InternalExamEntity> GetInternalExamByIdAsync(int internalExamId)
    {
        return await InternalExamsRepository.GetInternalExamByIdAsync(internalExamId);
    }

    public async Task<ActionResponse> AddInternalExamAsync(InternalExamEntity internalExam)
    {
        return await InternalExamsRepository.AddInternalExamAsync(internalExam);
    }

    public async Task<ActionResponse> UpdateInternalExamAsync(InternalExamEntity internalExam)
    {
        return await InternalExamsRepository.UpdateInternalExamAsync(internalExam);
    }

    public async Task<ActionResponse> RemoveInternalExamAsync(int internalExamId)
    {
        return await InternalExamsRepository.RemoveInternalExamAsync(await GetInternalExamByIdAsync(internalExamId));
    }
}
