public class Authenticator
{
    public Identity Admin => new() {Email = admin.Email, EyeColor = admin.EyeColor};

    private Identity admin;

    private readonly IDictionary<string, Identity> developers = new Dictionary<string, Identity>
    {
        ["Bertrand"] = new Identity { Email = "bert@ex.ism", EyeColor = EyeColor.Blue },
        ["Anders"] = new Identity { Email = "anders@ex.ism", EyeColor = EyeColor.Brown },
    };

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    public IDictionary<string, Identity> GetDevelopers()
    {
        return developers.AsReadOnly();
    }

    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }
}

public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}
