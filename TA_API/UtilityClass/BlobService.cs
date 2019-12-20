using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TA_API.UtilityClass
{
    public class BlobService
    {
        private CloudBlobClient _blobClient;
        private CloudBlockBlob _blockBlob;
        string accessKey = string.Empty;
        public BlobService()
        {
            //this.accessKey = AppConfiguration.GetConfiguration("DefaultEndpointsProtocol=https;AccountName=demoforimage;AccountKey=1h4/hdyX9pJ7uIM9t6+/JMZ9XmJwD1hN4pfXy6QSw1sqQYWn3f4LLqW1vEQHLcEhGMNMuTLBLNSmWRgp/XC+iw==;EndpointSuffix=core.windows.net");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=vlinkstoragefiles;AccountKey=u9aE/xdtETiPseDfskHQI0LnHo+RucvHtiyoPnNhTeJpYrgLPpGDoVlumJ3XtzySTMi1b/XIVJQQLpxFR5+6UQ==;EndpointSuffix=core.windows.net");
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public byte[] GetBlob(string containerName, string blobName)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            _blockBlob = container.GetBlockBlobReference(blobName);
            _blockBlob.FetchAttributesAsync();

            long fileByteLength = _blockBlob.Properties.Length;
            byte[] fileContents = new byte[fileByteLength];
            _blockBlob.DownloadToByteArrayAsync(fileContents, 0);
            return fileContents;
        }


        public string Upload(Stream blob, string containerName, string path)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            _blockBlob = container.GetBlockBlobReference(path);
            using (var fileStream = blob)
            {
                _blockBlob.UploadFromStreamAsync(fileStream);
            }
            return _blockBlob.Uri.AbsoluteUri;
        }

        public Stream Download(string containerName, string path)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            _blockBlob = container.GetBlockBlobReference(path);
            var ms = new MemoryStream();
            _blockBlob.DownloadToStreamAsync(ms);
            return ms;
        }


        public void Delete(string containerName, string path)
        {
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);

            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            _blockBlob = container.GetBlockBlobReference(path);
            _blockBlob.DeleteIfExistsAsync();
        }
    }
}
