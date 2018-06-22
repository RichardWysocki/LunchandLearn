namespace SampleClassLibrary.NetStandard
{
    public interface IEmailSender
    {
        string SendEmail(string recipient, string subject, string body);
    }
}
