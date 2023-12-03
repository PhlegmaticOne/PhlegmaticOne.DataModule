#if UNITY_EDITOR
using UnityEditor;

namespace App.Scripts.Menu.Services.Exit {
    public class ExitGameServiceEditor : IExitGameService {
        public void Exit() {
            EditorApplication.ExitPlaymode();
        }
    }
}
#endif