namespace LSS.DataModels
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public decimal? Grade { get; set; }
    }
}