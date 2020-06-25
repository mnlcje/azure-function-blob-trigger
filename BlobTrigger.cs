using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace My.Blob
{
    public static class BlobTrigger
    {
        [FunctionName("BlobTrigger")]
        public static void Run(
            [BlobTrigger("demo/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("output/{name}", FileAccess.Write,  Connection = "AzureWebJobsStorage")]Stream outputBlob,
            string name, ILogger log)
        {
            myBlob.CopyTo(outputBlob);
            
        }
    }
}
