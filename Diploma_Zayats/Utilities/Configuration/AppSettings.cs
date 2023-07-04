namespace Diploma_Zayats.Utilities.Configuration;

public class AppSettings
{
    public string? URL { get; set; }
    public int MaxTimeout { get; set; }
    public int MaxWaitTime { get; set; }
    public int WaitForPageLoadingTime { get; set; }
    public int WebDriverWaitTime { get; set; }
    //public bool Headless { get; set; }
}