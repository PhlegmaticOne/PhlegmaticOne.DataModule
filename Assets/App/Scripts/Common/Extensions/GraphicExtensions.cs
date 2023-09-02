using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Common.Extensions {
    public static class GraphicExtensions {
        
        public static void Transparent(this Image image) {
            var c = image.color;
            c.a = 0;
            image.color = c;
        }
        
        public static void Opaque(this Image image) {
            var c = image.color;
            c.a = 1;
            image.color = c;
        }
        
        public static void Transparent(this CanvasGroup canvasGroup) {
            canvasGroup.alpha = 0;
        }
        
        public static void Opaque(this CanvasGroup canvasGroup) {
            canvasGroup.alpha = 1;
        }
    }
}