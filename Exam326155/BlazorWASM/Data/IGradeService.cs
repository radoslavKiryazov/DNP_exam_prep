using Shared;

namespace BlazorWASM.Data;

public interface IGradeService
{
    public Task<StatisticsOverviewDTO> GetCourseStatistics (String course);
}