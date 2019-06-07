using System;

namespace WebApiSample
{
    public class MongoDBConfig
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString
        {

            get
            {
                var host = Environment.GetEnvironmentVariable("MONGO_HOST");
                if (host != null)
                    Host = host;

                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}