namespace PatientTestManager.Services.DTO
{ 
    public class TestDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; }
        public decimal Result { get; set; }
        public bool IsWithinThreshold { get; set; }
        public PatientDto? Patient { get; set; }
    }
}