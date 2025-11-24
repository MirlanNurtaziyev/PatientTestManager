namespace PatientTestManager.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TestName { get; set; } = string.Empty;
        public DateTime TestDate { get; set; } 
        public decimal Result { get; set; }
        public bool IsWithinThreshold { get; set; }
        public Patient? Patient { get; set; }
    }
}