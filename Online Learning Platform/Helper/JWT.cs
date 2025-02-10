namespace Online_Learning_Platform.Helper
{
    public class JWT
    {
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public int LifeTime { get; set; }
        public static string SigningKey { get; set; }
    }

}
