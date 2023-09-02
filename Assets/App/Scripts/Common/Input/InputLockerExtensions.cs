using System;
using System.Threading.Tasks;
using App.Scripts.Common.Input.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace App.Scripts.Common.Input {
    public static class InputLockerExtensions {
        public static async UniTask ExecuteInLocked(this IInputLocker inputLocker, Func<UniTask> action) {
            inputLocker.Lock();
            await action.Invoke();
            inputLocker.Unlock();
        }
        
        // public static async UniTask ExecuteInLocked(this IInputLocker inputLocker, Func<Task> action) {
        //     inputLocker.Lock();
        //     await action.Invoke();
        //     inputLocker.Unlock();
        // }
        
        public static async UniTask ExecuteInLocked(this IInputLocker inputLocker, Func<Tween> action) {
            inputLocker.Lock();
            await action.Invoke();
            inputLocker.Unlock();
        }
    }
}