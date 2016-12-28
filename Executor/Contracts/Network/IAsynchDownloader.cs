namespace Executor.Contracts
{
    public interface IAsynchDownloader
    {
        void DownloadAsync(string fileURL);
    }
}
