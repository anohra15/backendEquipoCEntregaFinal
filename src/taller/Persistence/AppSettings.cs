namespace RCVUcabBackend.Persistence{
    public class AppSettings
    {
        public readonly string _dbconnectionString = string.Empty;
        public readonly string _mqconnectionString = string.Empty;
        public readonly string _queueString = string.Empty;

        public AppSettings(){
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _dbconnectionString = root.GetSection("App").GetSection("DBConnectionString").Value;
            _mqconnectionString = root.GetSection("App").GetSection("MQConnection").Value;
            _queueString = root.GetSection("App").GetSection("QueueTaller").Value;
        }

        public string DBConnectionString
        {
            get => _dbconnectionString;
        }

        public string MQConnectionString
        {
            get => _mqconnectionString;
        }

        public string QueueString
        {
            get => _queueString;
        }
    }
}