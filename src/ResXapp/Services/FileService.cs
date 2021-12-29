namespace ResXapp.Services;

public class FileService : IFileService
{
    public FileService()
    {

    }

    public async Task<IEnumerable<string>> OpenFiles()
    {
        var result = await FilePicker.PickAsync();

        if (result == null)
        {
            return new List<string>();
        }

        var location = System.IO.Path.GetDirectoryName(result.FullPath);
        var files = Directory.GetFiles(location, "*.resx");

        return files;
    }
}
