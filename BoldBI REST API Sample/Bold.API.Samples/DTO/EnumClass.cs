namespace Bold.API.Samples.DTO
{
    public class EnumClass
    {
        public enum TenantType
        {
            BoldBI = 3,
            BoldReports = 4
        }

        public enum StorageType
        {
            FileStorage = 0,
            AzureBlob = 1
        }

        public enum SqlServerType
        {
            MSSQL = 0,
            MySql = 1,
            PostgresSQL = 4
        }
    }
}
