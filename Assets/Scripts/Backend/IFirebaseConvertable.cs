using System.Collections.Generic;

public interface IFirebaseConvertable
{
    IDictionary<string, object> ToDictionary();

    void FromDictionary(IDictionary<string, object> data);

    string GetTableName();
}
