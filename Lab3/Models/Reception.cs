namespace Lab3.Models
{
    public class Reception
    {
        public int Id { get; set; }
        public DateTime DataRec { get; set; }
        public int DoctorId { get; set; }
        
        public List<Doctor> doctors { get; set; }   


    }
}

