namespace ResXapp.Services;

public interface IFileService
{
    Task<IEnumerable<string>> OpenFiles();
}
