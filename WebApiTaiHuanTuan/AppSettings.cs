namespace WebApiTaiHuanTuan;

public class AppSettings
{
    public static string ConnectionStrings { get; private set; }
    public static string Secret { get; set; }
    public static List<string> CORS { get; set; }
}