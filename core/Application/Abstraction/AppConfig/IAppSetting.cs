namespace Application.Abstraction.AppConfig
{
    public interface IAppSetting
    {
        string SqlConnectionString { get; }
        string MongoDatabase { get; }
        string CloudConnectionString { get; }
        string CloudStorageUrl { get; }
        string FileContainer { get; }
        string HashKey { get; }
    }
}
