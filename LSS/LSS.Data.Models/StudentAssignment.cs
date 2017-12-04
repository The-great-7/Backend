namespace LSS.Data.Models
{
    public class StudentAssignment
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public int Score { get; set; }
    }
}