namespace NewsApplication.MVC.Contract;

public struct Routes
{
    private const string Base = "" ;
    
    public struct Announcement
    {
        public const string GetAll = Base + "/";
        public const string Create = Base + "/announcement/post";
        public const string Update = Base + "/announcement/put";
        public const string Get = Base + "/announcement/{id}";
        // public const string Delete = Base + "/announcement/delete/{id}";
    }
}