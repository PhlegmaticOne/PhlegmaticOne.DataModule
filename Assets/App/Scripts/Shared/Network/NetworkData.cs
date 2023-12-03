namespace Assets.App.Scripts.Shared.Network
{
    public class NetworkData
    {
        public int Port { get; }
        public string Address { get; }
        public bool TestNotConnect { get; }

        public NetworkData(string address, int port, bool testNotConnect)
        {
            TestNotConnect=testNotConnect;
            Address=address;
            Port=port;
        }
    }
}
