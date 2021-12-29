namespace ResXapp.Services;

public interface IResxService
{
    List<Language> ReadData(IEnumerable<string> files);
    void SaveData(List<Language> languages);
}
