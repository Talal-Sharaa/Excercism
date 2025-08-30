using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public string Blue = "blue";
        public string Green = "green";
        public string Brown = "brown";
        public string Hazel = "hazel";
        public string Grey = "grey";
    }
    private readonly IDictionary<string, Identity> developers;
    private readonly Identity admin;

    public Authenticator(Identity admin)
    {
        this.admin = admin;
        developers = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };
    }



    public Identity Admin
    {
        get { return admin; }
    }

    public IDictionary<string, Identity> GetDevelopers() => new ReadOnlyDictionary<string, Identity>(developers);
}

public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
}
