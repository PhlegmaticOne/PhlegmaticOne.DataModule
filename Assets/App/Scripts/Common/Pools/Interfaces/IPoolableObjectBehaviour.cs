namespace App.Scripts.Common.Pools.Interfaces {
    public interface IPoolableObjectBehaviour {
        void OnInitialize();
        void OnSetup();
        void OnReset();
    }
}