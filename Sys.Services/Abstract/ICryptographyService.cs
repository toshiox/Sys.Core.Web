namespace Sys.Services.Abstract
{
    public interface ICryptographyService
    {
        string StringDecript(string value);
        string StringEncript(string value);
        void EncryptFile(string inputFile, string outputFile);
    }
}