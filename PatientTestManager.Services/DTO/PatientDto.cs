namespace PatientTestManager.Services.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public ICollection<TestDto> Tests { get; set; } = new List<TestDto>();
    }
}