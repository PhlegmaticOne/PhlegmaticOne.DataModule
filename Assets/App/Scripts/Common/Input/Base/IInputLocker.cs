namespace App.Scripts.Common.Input.Base {
    public interface IInputLocker {
        void Lock();
        void Unlock();
    }
}