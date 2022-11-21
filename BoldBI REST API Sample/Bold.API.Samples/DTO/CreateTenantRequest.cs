namespace Bold.API.Samples.DTO
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CreateTenantRequest
    {
        /// <summary>
        /// Provide the email address of any existing user. This account will have admin access to the site once it is created.
        /// </summary>
        [JsonProperty("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Configuration of the BI site.
        /// </summary>
        [JsonProperty("ServerConfiguration")]
        public ServerConfiguration ServerConfiguration { get; set; }

        /// <summary>
        /// Datastore database configuration. This database will be used to store the data extracted from the DB servers or from any web data source.
        /// </summary>
        [JsonProperty("DataStoreConfiguration")]
        public Data DataStoreConfiguration { get; set; }
    }

    public partial class Data
    {
        /// <summary>
        /// Hostname or IP address of the database server.
        /// </summary>
        [JsonProperty("ServerName")]
        public string ServerName { get; set; }

        /// <summary>
        /// Name of the database. 
        /// </summary>
        [JsonProperty("DatabaseName")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Username of the database server. Please refer to this document https://staginghelp.boldbi.com/embedded-bi/faq/what-are-the-database-permissions-required-to-set-up-bold-bi-embedded/ to learn about the permissions required for this user.
        /// </summary>
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password of the database user.
        /// </summary>
        [JsonProperty("Password")]
        public string Password { get; set; }

        /// <summary>
        /// Determines whether the application has to create a new database or use the existing database.
        /// TRUE - A new database will be created.
        /// FALSE - The application will try using the existing database.
        /// </summary>
        [JsonProperty("IsNewDatabase")]
        public bool IsNewDatabase { get; set; }

        /// <summary>
        /// Maintenance database of the database server. This is only required for PostgreSQL DB servers.
        /// </summary>
        [JsonProperty("MaintenanceDatabase")]
        public string MaintenanceDatabase { get; set; }

        /// <summary>
        /// Port number of the database server. Required only for PostgreSQL and MySQL database servers.
        /// </summary>
        [JsonProperty("Port")]
        public string Port { get; set; }

        /// <summary>
        /// Database Server Type. We support the MSSQL, PostgreSQL, and MYSQL database servers.
        /// </summary>
        [JsonProperty("ServerType")]
        public int ServerType { get; set; }
        
        /// <summary>
        /// Decides whether the connection to the database should be encrypted.
        /// </summary>
        [JsonProperty("SslEnabled")]
        public bool SslEnabled { get; set; }
    }

    public partial class ServerConfiguration
    {
        /// <summary>
        /// Database configuration of the site metadata. Dashboards, groups, users, and their permission will be stored in this database.
        /// </summary>
        [JsonProperty("Database")]
        public Data Database { get; set; }

        /// <summary>
        /// Storage configuration of the site.
        /// </summary>
        [JsonProperty("Storage")]
        public Storage Storage { get; set; }

        /// <summary>
        /// Site information.
        /// </summary>
        [JsonProperty("Site")]
        public Site Site { get; set; }
    }

    public partial class Site
    {
        /// <summary>
        /// Name of the tenant.
        /// </summary>
        [JsonProperty("TenantName")]
        public string TenantName { get; set; }

        /// <summary>
        /// Identifier of the tenant. This information will be used in the URL to differentiate multiple tenants.
        /// (i.e) https://example.com/bi/site/{site-identifier}
        /// </summary>
        [JsonProperty("TenantIdentifier")]
        public string TenantIdentifier { get; set; }

        /// <summary>
        /// Determines whether we need to use site identifier or domain to differentiate tenants.
        /// TRUE - Uses the site identifier to differentiate the tenants. (Default)
        /// FALSE - Uses domain to differentiate the tenants.
        /// </summary>
        [JsonProperty("UseSiteIdentifier")]
        public bool UseSiteIdentifier { get; set; }

        /// <summary>
        /// Type of the tenant to be deployed.
        /// * 3 - Bold BI
        /// * 4 - Bold Reports
        /// </summary>
        [JsonProperty("TenantType")]
        public int TenantType { get; set; }

        /// <summary>
        /// Determines which branding information should be used in the tenant.
        /// TRUE - Uses the UMS branding information to deploy a new tenant.
        /// FALSE - Uses the default Bold BI branding information to deploy a new tenant. 
        /// </summary>
        [JsonProperty("UseCustomBranding")]
        public bool UseCustomBranding { get; set; }

        /// <summary>
        /// Please refer to this document - https://help.boldbi.com/embedded-bi/working-with-data-source/configuring-custom-attribute
        /// </summary>
        [JsonProperty("CustomAttribute")]
        public CustomAttribute[] CustomAttribute { get; set; }

        /// <summary>
        /// Please refer to this document - https://help.boldbi.com/embedded-bi/working-with-data-source/configuring-isolation-code/
        /// </summary>
        [JsonProperty("TenantIsolation")]
        public TenantIsolation TenantIsolation { get; set; }
    }

    public partial class CustomAttribute
    {
        /// <summary>
        /// Name of the custom attribute.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Custom Attribute Value.
        /// </summary>
        [JsonProperty("Value")]
        public string Value { get; set; }

        /// <summary>
        /// Attribute Description.
        /// </summary>
        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Decide whether this needs to be stored in an encrypted format.
        /// </summary>
        [JsonProperty("CanEncrypt")]
        public bool CanEncrypt { get; set; }
    }

    public partial class TenantIsolation
    {
        /// <summary>
        /// Enable or disable the isolation code configuration.
        /// </summary>
        [JsonProperty("IsEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Isolation code for the tenant. Please refer https://help.boldbi.com/embedded-bi/working-with-data-source/configuring-isolation-code/
        /// </summary>
        [JsonProperty("IsolationCode")]
        public string IsolationCode { get; set; }
    }

    /// <summary>
    /// Configuration for storing the static resources of the tenant.
    /// </summary>
    public partial class Storage
    {
        /// <summary>
        /// Determines in which storage, the application will store the static resources.
        /// 0 - File Storage
        /// 1 - Azure Blob Storage
        /// </summary>
        [JsonProperty("StorageType")]
        public int StorageType { get; set; }

        /// <summary>
        /// Azure Blob Storage Configuration. Only required
        /// </summary>
        [JsonProperty("AzureBlob")]
        public AzureBlob AzureBlob { get; set; }
    }

    public partial class AzureBlob
    {
        /// <summary>
        /// Blob Storage Container Name
        /// </summary>
        [JsonProperty("AzureBlobStorageContainerName")]
        public string AzureBlobStorageContainerName { get; set; }

        /// <summary>
        /// Azure Blob Storage URI.
        /// </summary>
        [JsonProperty("AzureBlobStorageUri")]
        public string AzureBlobStorageUri { get; set; }

        /// <summary>
        /// Azure Blob Storage Connection String.
        /// </summary>
        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Connection type. Either http or https.
        /// </summary>
        [JsonProperty("ConnectionType")]
        public string ConnectionType { get; set; }

        /// <summary>
        /// Name of the storage account.
        /// </summary>
        [JsonProperty("AccountName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Access Key for connecting to the storage account.
        /// </summary>
        [JsonProperty("AccessKey")]
        public string AccessKey { get; set; }
    }
}

