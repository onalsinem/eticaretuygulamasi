using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public RedisService(string port, string host)
        {
            _port = port;
            _host = host;
        }

        public string _port { get; set; }

        public string _host { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;

        //public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port},abortConnect=false");


        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
