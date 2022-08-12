namespace Bold.API.Samples.DTO
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CreateTenantRequest
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("ServerConfiguration")]
        public ServerConfiguration ServerConfiguration { get; set; }

        [JsonProperty("DataStoreConfiguration")]
        public Data DataStoreConfiguration { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("ServerName")]
        public string ServerName { get; set; }

        [JsonProperty("DatabaseName")]
        public string DatabaseName { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("IsNewDatabase")]
        public bool IsNewDatabase { get; set; }

        [JsonProperty("MaintenanceDatabase")]
        public string MaintenanceDatabase { get; set; }

        [JsonProperty("Port")]
        public string Port { get; set; }

        [JsonProperty("ServerType")]
        public int ServerType { get; set; }

        [JsonProperty("SslEnabled")]
        public bool SslEnabled { get; set; }
    }

    public partial class ServerConfiguration
    {
        [JsonProperty("Database")]
        public Data Database { get; set; }

        [JsonProperty("Storage")]
        public Storage Storage { get; set; }

        [JsonProperty("Site")]
        public Site Site { get; set; }
    }

    public partial class Site
    {
        [JsonProperty("TenantName")]
        public string TenantName { get; set; }

        [JsonProperty("TenantIdentifier")]
        public string TenantIdentifier { get; set; }

        [JsonProperty("UseSiteIdentifier")]
        public bool UseSiteIdentifier { get; set; }

        [JsonProperty("TenantType")]
        public int TenantType { get; set; }

        [JsonProperty("UseCustomBranding")]
        public bool UseCustomBranding { get; set; }

        [JsonProperty("CustomAttribute")]
        public CustomAttribute[] CustomAttribute { get; set; }

        [JsonProperty("TenantIsolation")]
        public TenantIsolation TenantIsolation { get; set; }
    }

    public partial class CustomAttribute
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("CanEncrypt")]
        public bool CanEncrypt { get; set; }
    }

    public partial class TenantIsolation
    {
        [JsonProperty("IsEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("IsolationCode")]
        public string IsolationCode { get; set; }
    }

    public partial class Storage
    {
        [JsonProperty("StorageType")]
        public int StorageType { get; set; }

        [JsonProperty("AzureBlob")]
        public AzureBlob AzureBlob { get; set; }
    }

    public partial class AzureBlob
    {
        [JsonProperty("AzureBlobStorageContainerName")]
        public string AzureBlobStorageContainerName { get; set; }

        [JsonProperty("AzureBlobStorageUri")]
        public string AzureBlobStorageUri { get; set; }

        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [JsonProperty("ConnectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("AccountName")]
        public string AccountName { get; set; }

        [JsonProperty("AccessKey")]
        public string AccessKey { get; set; }
    }
}

