using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureBlobStorageExample
{
    public class AzureBlobStorageExample
    {
        private const string connectionString = "Ihre_Verbindungszeichenfolge";
        private const string containerName = "mein-container";
        private const string blobName = "beispiel-datei.txt";
        private const string filePath = "C:\\pfad\\zu\\ihrer\\datei.txt";
        public async Task RunExampleAsync()
        {
            // einen BlobServiceClient erstellen

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // einen Container erstellen
            BlobContainerClient containerClient =
            await blobServiceClient.CreateBlobContainerAsync(containerName);
            Console.WriteLine($"Container '{containerName}' wurde erstellt.");
            // Referenz auf einen Blob erstellen und Datei hochladen
            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            using FileStream uploadFileStream = File.OpenRead(filePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            Console.WriteLine($"Blob '{blobName}' wurde hochgeladen.");
            // Blob-Eigenschaften abrufen und anzeigen
            BlobProperties properties = await blobClient.GetPropertiesAsync();
            Console.WriteLine($"Blob-Größe: {properties.ContentLength} Bytes");
            // Blob herunterladen und Inhalt anzeigen
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            using (MemoryStream ms = new MemoryStream())
            {
                await download.Content.CopyToAsync(ms);
                string content =
                System.Text.Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine($"Blob-Inhalt: {content}");
            }
            // Aufräumen: Blob und Container löschen
            await blobClient.DeleteAsync();
            await containerClient.DeleteAsync();
            Console.WriteLine("Aufräumarbeiten abgeschlossen.");
        }
    }
}