namespace SampleAspNetCore.Models
{
    public class EmailDTO
    {
        public int EmailId { get; set; }

        public string ToAddress { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool EmailSent { get; set; }
    }
}
