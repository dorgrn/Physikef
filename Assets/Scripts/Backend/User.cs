using System.Collections.Generic;

public class User : IFirebaseConvertable
{
    public string displayname { get; set; }
    public string userid { get; set; }
    public string email { get; set; }
    public string usertype { get; set; }

    public void FromDictionary(IDictionary<string, object> data)
    {
        displayname = (string) data[nameof(displayname)];
        userid = (string)data[nameof(userid)];
        email = (string)data[nameof(email)];
        usertype = (string)data[nameof(usertype)];
    }

    public string GetTableName()
    {
        return "users";
    }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {nameof(displayname), displayname},
            {nameof(email), email},
            {nameof(userid), userid},
            {nameof(usertype), usertype}
        };
    }
}