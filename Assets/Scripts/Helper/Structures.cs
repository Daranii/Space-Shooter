using System;
using UnityEngine;

namespace Helper
{
    /// <summary>
    /// Holds player stats
    /// </summary>
    [Serializable]
    public struct Stats
    {
        public int lives;
        public float fireRate;
        public float horizontalSpeed;
        public float verticalSpeed;

        public Stats(int lives = 0, float fireRate = 0, float horizontalSpeed = 0, float verticalSpeed = 0)
        {
            this.fireRate = fireRate;
            this.horizontalSpeed = horizontalSpeed;
            this.verticalSpeed = verticalSpeed;
            this.lives = lives;
        }

        public static Stats operator +(Stats a, Stats b) =>
            new Stats(Math.Min(a.lives + b.lives, PlayerValues.MaxLives), 
                a.fireRate + b.fireRate,
                a.horizontalSpeed + b.horizontalSpeed, 
                a.verticalSpeed + b.verticalSpeed);

        public static Stats operator -(Stats a, Stats b) =>
            new Stats(a.lives - b.lives, 
                a.fireRate - b.fireRate,
                a.horizontalSpeed - b.horizontalSpeed, 
                a.verticalSpeed - b.verticalSpeed);
    }
    
    /// <summary>
    /// Used for Anchor presets, mainly
    /// </summary>
    [Serializable]
    public readonly struct Anchor
    {
        public readonly Vector2 AnchorMax;
        public readonly Vector2 AnchorMin;
        public readonly Vector2 Pivot;

        public Anchor(Vector2 anchorMax, Vector2 anchorMin, Vector2 pivot)
        {
            AnchorMax = anchorMax;
            AnchorMin = anchorMin;
            Pivot = pivot;
        }

        public Anchor(Vector2 anchor, Vector2 pivot)
        {
            AnchorMax = anchor;
            AnchorMin = anchor;
            Pivot = pivot;
        }

        public Anchor(Vector2 anchor)
        {
            AnchorMax = anchor;
            AnchorMin = anchor;
            Pivot = new Vector2(0.5f, 0.5f);
        }
    }

}