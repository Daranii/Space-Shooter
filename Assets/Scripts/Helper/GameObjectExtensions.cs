using UnityEngine;
using UnityEngine.UI;

namespace Helper
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Extension Method for GameObjects that adds a RectTransform component and returns the GameObject for chaining
        /// </summary>
        /// <param name="anchor">Anchor struct that will be applied to anchorMax, anchorMin and pivot</param>
        /// <returns>GameObject for chaining methods</returns>
        public static GameObject AddRectTransform(this GameObject gameObj, Anchor anchor, Vector2 sizeDelta, 
            Vector2? offsetMax = null, Vector2? offsetMin = null, Vector2? anchoredPosition = null, 
            Vector3? localScale = null)
        {
            var rect = gameObj.AddComponent<RectTransform>();
            
            if (localScale != null) rect.localScale = (Vector3) localScale;
            else rect.localScale = Vector3.one;
            
            rect.anchorMax = anchor.AnchorMax;
            rect.anchorMin = anchor.AnchorMin;
            rect.pivot = anchor.Pivot;
            
            if (anchoredPosition != null) rect.anchoredPosition = (Vector2) anchoredPosition;
            else rect.anchoredPosition = Vector2.zero;
            
            if (offsetMax != null) rect.offsetMax = (Vector2) offsetMax;
            if (offsetMin != null) rect.offsetMin = (Vector2) offsetMin;
            
            rect.sizeDelta = sizeDelta;

            return gameObj;
        }

        /// <summary>
        /// Extension Method for GameObjects that adds a Text component and returns it
        /// </summary>
        /// <returns>Text Component</returns>
        public static Text AddText(this GameObject gameObj, string text, Color textColor,
            TextAnchor textAlignment, int fontSize = 16, string fontPath = "Arial.ttf")
        {
            var textComponent = gameObj.AddComponent<Text>();
            textComponent.text = text;
            textComponent.alignment = textAlignment;
            textComponent.font = (Font) Resources.GetBuiltinResource(typeof(Font), fontPath);
            textComponent.fontSize = fontSize;
            textComponent.color = textColor;

            return textComponent;
        }

        /// <summary>
        /// Extension Method for GameObjects that adds a Image component and returns it
        /// </summary>
        /// <returns>Image Component</returns>
        public static Image AddImage(this GameObject gameObj, Sprite sprite, bool preserveAspect = true)
        {
            var image = gameObj.AddComponent<Image>();
            image.sprite = sprite;
            image.preserveAspect = preserveAspect;

            return image;
        }
    }
}