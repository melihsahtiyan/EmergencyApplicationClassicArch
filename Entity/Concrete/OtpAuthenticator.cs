using Entity.Concrete;
using Entity.Abstract;

namespace Entity.Concrete;

public class OtpAuthenticator : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator()
    {
    }

    public OtpAuthenticator(int id, int userId, byte[] secretKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}