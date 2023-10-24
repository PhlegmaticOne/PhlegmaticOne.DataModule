using UnityEngine;

namespace App.Scripts.Common.Extensions {
    public static class SpriteExtensions {
        public static Sprite[] Split(this Sprite sprite) {
            var texture = sprite.texture;
            var xPos = texture.width / 2.0f;
            var rightPivot = (texture.width - xPos) / texture.width;
            var leftPivot = 1.0f - rightPivot;
            var leftFruitPart = new Rect(0, 0, xPos, texture.height);
            var rightFruitPart = new Rect(xPos, 0, texture.width - xPos, texture.height);

            return new[] {
                CreateSprite(sprite, rightFruitPart, rightPivot),
                CreateSprite(sprite, leftFruitPart, leftPivot)
            };
        }
        
        private static Sprite CreateSprite(Sprite originalSprite, Rect fruitPart, float pivot) => 
            Sprite.Create(originalSprite.texture, fruitPart, Vector2.one * pivot, originalSprite.pixelsPerUnit);
    }
}