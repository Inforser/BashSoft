
namespace Executor.Network
{
    using System.Net;
    using System.Threading.Tasks;
    using IO;
    using Static_Data;
    using Contracts;

    public class DownloadManager : IDownloadManager
    {
        private readonly WebClient webClient;

        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        public void Download(string fileURL)
        {

            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");

                string nameOfFile = ExtractNameOfFile(fileURL);
                string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

                this.webClient.DownloadFile(fileURL, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public void DownloadAsync(string fileURL)
        {
            Task currentTask = Task.Run(() => Download(fileURL));
            SessionData.taskPool.Add(currentTask);
        }

        private static string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf("/");

            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new WebException(ExceptionMessages.InvalidPath);
            }
        }
    }
}
