using Application;

namespace ProjectASP2023.JWT
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Username { get; set; }
    }
    public class AnonymousUser : IApplicationUser
    {
        public string Identity => Username;

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int>() { 1,2,3};

        public string Username => "Anon";
    }
}
