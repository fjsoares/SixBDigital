namespace SixBDigital.CarValeting.Core.Entities
{
    public class User : BaseEntity<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
