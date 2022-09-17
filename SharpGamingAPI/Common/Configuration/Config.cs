namespace SharpGamingAPI.Common.Configuration
{
    public static class DBConfig
    {
        public static string Connection { get; set; }
    }
    public static class UserConfig
    {
        public static long UserId { get; set; }
        public static int GroupId { get; set; }
    }
    public static class PhotoPathConfig
    {
        public static string Product { get; set; }
        public static string Supplier { get; set; }
        public static string Customer { get; set; }
    }
}
