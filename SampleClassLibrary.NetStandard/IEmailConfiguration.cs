namespace SampleClassLibrary.NetStandard
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string SmtpServerUserName { get; set; }
        string SmtpServerPassword { get; set; }
        string SenderEmail { get; set; }
    }
}
