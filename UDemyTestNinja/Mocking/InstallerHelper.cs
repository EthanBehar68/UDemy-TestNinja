using System.Net;

// Disable warning messages 4507 and 4034.
namespace UDemyTestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        #pragma warning disable 0649 // this is intentional
        private string _setupDestinationFile;
        #pragma warning restore 0649


        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller( string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                    customerName,
                    installerName),
                    _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}