public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
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
    // TODO: implement equality and GetHashCode() methods
}

public class Authenticator
{
    private List<Identity> xLstIdentities = new List<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        (faceA.Equals(faceB) || (faceA.EyeColor == faceB.EyeColor && faceA.PhiltrumWidth == faceB.PhiltrumWidth));

    public bool IsAdmin(Identity identity) => (identity.Email == "admin@exerc.ism" && identity.FacialFeatures.EyeColor == "green" && identity.FacialFeatures.PhiltrumWidth == 0.9m);

    public bool Register(Identity identity)
    {
        if(!IsRegistered(identity)){
            xLstIdentities.Add(identity);
            return true;
        }
        return false;
        
    }

    public bool IsRegistered(Identity identity){
        foreach(Identity iIdentity in xLstIdentities){
            if(AreIdentical(identity, iIdentity))
                return true;
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB) => (identityA.Equals(identityB));

    public static bool AreIdentical(Identity identityA, Identity identityB) => (identityA.Equals(identityB) || (identityA.Email == identityB.Email && identityA.FacialFeatures.EyeColor == identityB.FacialFeatures.EyeColor && identityA.FacialFeatures.PhiltrumWidth == identityB.FacialFeatures.PhiltrumWidth));
}
