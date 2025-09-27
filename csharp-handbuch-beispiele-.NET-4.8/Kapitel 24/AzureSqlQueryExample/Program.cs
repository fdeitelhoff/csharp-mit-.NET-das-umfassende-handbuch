using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AzureSqlQueryExample
{
    class Program
    {
        // Verbindung zur Datenbank
        private static string connectionString = "Server=tcp:beispielsqlserver123.database.windows.net,1433;Initial Catalog=BeispielDatenbank;Persist Security Info=False;User ID=sqladmin;Password=SicheresPasswort123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static async Task Main(string[] args)
        {
            try
            {
                // Abfrage durchführen und Ergebnisse anzeigen
                await QueryDatabaseAsync();


                string endpointUri = "Ihre_Endpunkt_URI";
                string primaryKey = "Ihr_Primärschlüssel";
                string databaseId = "MeineDatabase";
                string containerId = "MeinContainer";
                CosmosClient cosmosClient = new CosmosClient(endpointUri, primaryKey);
                // Erstellen einer Datenbank
                Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
                // Erstellen eines Containers
                Container container = await database.CreateContainerIfNotExistsAsync(containerId, "/partitionKey");
                // Definieren eines Beispieldokuments
                dynamic item = new
                {
                    id = Guid.NewGuid().ToString(),
                    partitionKey = "Beispiel",
                    name = "John Doe",
                    age = 30
                };
                // Einfügen des Dokuments
                ItemResponse<dynamic> response = await container.CreateItemAsync(item, new PartitionKey(item.partitionKey));
                Console.WriteLine($"Dokument erstellt mit ID: {response.Resource.id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
        private static async Task QueryDatabaseAsync()
        {
            // SQL-Abfrage, die alle Einträge aus einer Beispiel-Tabelle liest
            string query = "SELECT * FROM BeispielTabelle";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Verbindung öffnen
                await connection.OpenAsync();
                // Befehl erstellen
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Abfrage ausführen
                    using (SqlDataReader reader =
                    await command.ExecuteReaderAsync())
                    {
                        // Ergebnisse verarbeiten
                        while (await reader.ReadAsync())
                        {
                            // Beispiel: Annahme, die Tabelle hat die Spalten
                            // "Id" (int) und "Name" (string)
                            int id = reader.GetInt32(0); // Spalte 0 ist "Id"
                            string name = reader.GetString(1); // Spalte 1
                                                               // ist "Name"
                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }
                }
            }
        }
    }
}