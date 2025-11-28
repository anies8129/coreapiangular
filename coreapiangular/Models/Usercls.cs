namespace coreapiangular.Models
{
    public class Usercls
    {
        public int uid { set; get; }
        public string? name { set; get; }
        public int age { set; get; }
        public string? addr { set; get; }
        public string? email { set; get; }
        public string? photo { set; get; }
        public string? uname { set; get; }
        public string? password { set; get; }
    }
    public class UsercreateDTO
    {
        public string? name { set; get; }
        public int age { set; get; }
        public string? addr { set; get; }
        public string? email { set; get; }
        public IFormFile? path { set; get; }
        public string? uname { set; get; }
        public string? password { set; get; }
    }
    public class userloginDTo
    {
        public string? uname { set; get; }
        public string? password { set; get; }
    }
}
