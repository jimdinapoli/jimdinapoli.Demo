﻿using System.Net.Http;

namespace SkullJocks.BenAdmin.App.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
