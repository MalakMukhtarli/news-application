namespace NewsApplication.MVC.Contract;

public struct Routes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;
    
    
    public struct Announcement
    {
        public const string GetAll = Base + "/serviceSteps";
        public const string Create = Base + "/serviceStep";
        public const string Update = Base + "/serviceStep";
        public const string Get = Base + "/serviceStep/{serviceId}";
        public const string Delete = Base + "/serviceStep";
    }
}