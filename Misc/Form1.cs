using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.ServiceBus;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StackExchange.Redis;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Misc
{
    public partial class Form1 : Form
    {
        const string connStr = "ConnStr";
        const string queueName = "QueueName";
        static IQueueClient queueClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //queueClient = new QueueClient(connStr, queueName);
            string serviceName = "<your-search-service-name>";
            string apiKey = "<your-search-service-admin-api-key>";
            string indexName = "hotels-quickstart";

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloudStorageAccount storage = CloudStorageAccount.Parse("ConnStr");
            CloudTableClient tableClient = storage.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Table");

            TableBatchOperation tableOperations = new TableBatchOperation();
            table.ExecuteBatch(tableOperations);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //IDatabase cache = Connection.GetDatabase();
        }
    }
}
