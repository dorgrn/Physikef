using System.Collections.Generic;

public class HomeWork : IFirebaseConvertable
{
    public string Name { get; set; }
    public string SceneName { get; set; }

    public string CreatorName { get; set; }

    public IEnumerable<string> Students { get; set; }

    public void FromDictionary(IDictionary<string, object> data)
    {
        Name = (string)data[nameof(Name)];
        SceneName = (string)data[nameof(SceneName)];
        CreatorName = (string)data[nameof(CreatorName)];
        Students = (IEnumerable<string>)data[nameof(Students)];
    }

    public string GetTableName()
    {
        return "homework";
    }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {nameof(Name), Name},
            {nameof(SceneName), SceneName},
            {nameof(CreatorName), CreatorName},
            {nameof(Students), Students}
        };
    }
}