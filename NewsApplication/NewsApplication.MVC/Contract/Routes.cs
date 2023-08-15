namespace NewsApplication.MVC.Contract;

public struct Routes
{
    private const string Base = "" ;
    
    public struct Announcement
    {
        public const string GetAll = Base + "/";
        public const string Get = Base + "/announcement/{id}";
    }
    
    public struct AdminAnnouncement
    {
        public const string GetAll = Base + "/admin/announcement";
        public const string Get = Base + "/admin/announcement/{id}";
        public const string Create = Base + "/admin/announcement/post";
        public const string Update = Base + "/admin/announcement/put";
        // public const string Delete = Base + "/announcement/delete/{id}";
    }
    
    public struct Auth
    {
        public const string Register = "/auth/register";
        public const string Login = "/auth/login";
        public const string Logout = "/auth/logout";

    }
}