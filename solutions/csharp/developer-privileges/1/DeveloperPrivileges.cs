using System.Collections.Generic;

public class Authenticator
{
    private static Identity _admin = new Identity()
    {
        Email = "admin@ex.ism",
        FacialFeatures = new FacialFeatures()
        {
            EyeColor = "green",
            PhiltrumWidth = 0.9m
        },
        NameAndAddress = new List<string>() { "Chanakya", "Mumbai", "India" },
    };

    private static Identity _bertrand = new Identity()
    {
        Email = "bert@ex.ism",
        FacialFeatures = new FacialFeatures()
        {
            EyeColor = "blue",
            PhiltrumWidth = 0.8m
        },
        NameAndAddress = new List<string>() { "Bertrand", "Paris", "France" }
    };

    private static Identity _anders = new Identity()
    {
        Email = "anders@ex.ism",
        FacialFeatures = new FacialFeatures()
        {
            EyeColor = "brown",
            PhiltrumWidth = 0.85m
        },
        NameAndAddress = new List<string>() { "Anders", "Redmond", "USA" }
    };

    private static IDictionary<string, Identity> _developers = new Dictionary<string, Identity>()
    {
        ["Bertrand"] = _bertrand,
        ["Anders"] = _anders,
    };
    public Identity Admin
    {
        get => _admin;
    }

    public IDictionary<string, Identity> Developers
    {
        get => _developers;
    }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}
