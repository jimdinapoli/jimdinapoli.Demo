using System.Net.Http;

namespace SkullJocks.BenAdmin.App.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
