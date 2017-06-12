namespace HelloWorld
{
    using System.Threading.Tasks;
    public class Startup
    {
        public async Task<object> Invoke(object input)
        {
            return "Hello from dot net core";
        }
    }
}
