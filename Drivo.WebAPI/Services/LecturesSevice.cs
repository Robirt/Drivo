using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class LecturesSevice
{
    public LecturesSevice(LecturesRepository lecturesRepository)
    {
        LecturesRepository = lecturesRepository;
    }

    private LecturesRepository LecturesRepository { get; }

    public async Task<LectureEntity> GetLectureByIdAsync(int lectureId)
    {
        return await LecturesRepository.GetLectureByIdAsync(lectureId);
    }

    public async Task<ActionResponse> AddLectureAsync(LectureEntity lecture)
    {
        return await LecturesRepository.AddLectureAsync(lecture);
    }

    public async Task<ActionResponse> UpdateLectureAsync(LectureEntity lecture)
    {
        return await LecturesRepository.UpdateLectureAsync(lecture);
    }

    public async Task<ActionResponse> RemoveLectureAsync(int lectureId)
    {
        return await LecturesRepository.RemoveLectureAsync(await );
    }
}
