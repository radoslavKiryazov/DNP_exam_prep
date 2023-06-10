namespace Shared;

public class StatisticsOverviewDTO
{
    public string CourseCode { get; set; }
    public int? TotalNumOfPassedStudents { get; set; }
    public int? TotalNumOfStudents { get; set; }
    public float? AvgGradeOverall { get; set; }
    public float? AvgGradeOfPassed { get; set; }
    public int? MedianGrade { get; set; }
}