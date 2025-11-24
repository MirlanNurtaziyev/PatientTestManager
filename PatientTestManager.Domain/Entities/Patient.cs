namespace PatientTestManager.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } 
        public string Gender { get; set; } = string.Empty;
        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}