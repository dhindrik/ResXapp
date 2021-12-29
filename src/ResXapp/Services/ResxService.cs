namespace ResXapp.Services;

public class ResxService : IResxService
{
    public List<Language> ReadData(IEnumerable<string> files)
    {
        var xml = new XmlSerializer(typeof(Root));

        var values = new List<Language>();

        foreach (var file in files.OrderBy(x => x))
        {
            var fileName = Path.GetFileName(file);

            var data = (Root)xml.Deserialize(File.Open(file, FileMode.Open));

            var language = values.SingleOrDefault(x => x.Name == fileName);

            if (language is null)
            {
                language = new Language() { Name = fileName };
                values.Add(language);
            }

            foreach (var item in data.Data)
            {
                language.Translations.Add(item.Name, new Translation() { Key = item.Name, Value = item.Value });
            }
        }

        return values;
    }

    public void SaveData(List<Language> languages)
    {
        throw new NotImplementedException();
    }
}
