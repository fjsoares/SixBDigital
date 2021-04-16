namespace SixBDigital.CarValeting.Core.Interfaces
{
    public interface IEmailClient
    {
        void SendApprovedEmail(int id, string name, string email);
    }
}