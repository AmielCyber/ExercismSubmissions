using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(Object obj) =>
        obj is FacialFeatures other && this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(Object obj) =>
        obj is Identity other && this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private HashSet<Identity> _registeredIdenties = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => _admin.Equals(identity);

    public bool Register(Identity identity) => _registeredIdenties.Add(identity);

    public bool IsRegistered(Identity identity) => _registeredIdenties.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
}
