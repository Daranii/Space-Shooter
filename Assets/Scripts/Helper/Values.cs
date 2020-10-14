using UnityEngine;

namespace Helper
{
    // All of the values that are defaults or do not change
    public struct ScreenValues
    {
        public const float TopLimit = 5f;
        public const float BottomLimit = -5f;
        public const float RightLimit = 9.6f;
        public const float LeftLimit = -9.6f;
        public const float OffScreenEffectsLength = 1.5f;
        public const float LaserOffset = 1f;
    }

    public struct UiValues
    {
        public const int ScoreFontSize = 20;
        public const int GameOverFontSize = 40;
        public const float FlickerTimeInSeconds = 0.6f;
    }
    
    public struct PlayerValues
    {
        public const int MaxLives = 1;
        public static readonly Stats DefaultPlayerStats = 
            new Stats(MaxLives, 0.15f, 7, 3);
    }

    public struct ControlValues
    {
        public const float DefaultVerticalDeadzone = 0.002f;
        public const float DefaultHorizontalDeadzone = 0.002f;
    }

    /// <summary>
    /// Anchor Presets that the Unity engine does not offer outside of the inspector
    /// </summary>
    public struct Presets
    {
        public static Anchor Stretch = new Anchor(Vector2.one, Vector2.zero, Vector2.zero);

        public static Anchor Centered = new Anchor(new Vector2(0.5f, 0.5f));

        public static Anchor TopRight = new Anchor(Vector2.one);
        
        public static Anchor BottomLeft = new Anchor(Vector2.zero);
    }
}