﻿namespace Bold.API.Samples
{
    using System.Net.Http;
    using System.Text;

    using Newtonsoft.Json;

    public static class Extensions
    {
        public static StringContent AsJson(this object o)
         => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
}
