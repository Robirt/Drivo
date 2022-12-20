using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class StudentsGroupsService
{
    public StudentsGroupsService(StudentsGroupsRepository studentsGroupsRepository)
    {
        StudentsGroupsRepository = studentsGroupsRepository;
    }

    private StudentsGroupsRepository StudentsGroupsRepository { get; }
    
    public async Task<List<StudentsGroupEntity>> GetStudentsGroupsAsync()
    {
        return await StudentsGroupsRepository.GetStudentsGroupsAsync();
    }

    public async Task<ActionResponse> AddStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        return await StudentsGroupsRepository.AddStudentsGroupAsync(studentsGroup);
    }

    public async Task<ActionResponse> RemoveStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        return await StudentsGroupsRepository.RemoveStudentsGroupAsync(studentsGroup);
    }
}
