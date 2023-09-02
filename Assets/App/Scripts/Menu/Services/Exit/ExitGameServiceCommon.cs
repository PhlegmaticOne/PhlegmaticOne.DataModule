using UnityEngine;

namespace App.Scripts.Menu.Services.Exit {
    public class ExitGameServiceCommon : IExitGameService {
        public void Exit() {
            Application.Quit();
        }
    }
}