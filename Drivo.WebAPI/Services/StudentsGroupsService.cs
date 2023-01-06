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

    public async Task<StudentsGroupEntity> GetStudentsGroupByIdAsync(int studentsGroupId)
    {
        return await StudentsGroupsRepository.GetStudentsGroupByIdAsync(studentsGroupId);
    }

    public async Task<ActionResponse> AddStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        return await StudentsGroupsRepository.AddStudentsGroupAsync(studentsGroup);
    }

    public async Task<ActionResponse> UpdateStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        return await StudentsGroupsRepository.UpdateStudentsGroupAsync(studentsGroup);
    }

    public async Task<ActionResponse> RemoveStudentsGroupAsync(int studentsGroupId)
    {
        return await StudentsGroupsRepository.RemoveStudentsGroupAsync(await StudentsGroupsRepository.GetStudentsGroupByIdAsync(studentsGroupId));
    }
}
