using Entities;
using Helper;
using UnityEngine;

namespace PowerUps
{
    public sealed class Speed : PowerUp
    { 
        protected override void ApplyEffect(Collider2D other)
        {
            var player = other.GetComponent<Player>();
            
            var statsToBeModified = new Stats(horizontalSpeed: 6, verticalSpeed: 6);
            player.ModifyStats(statsToBeModified, powerUpTime);
        }
    }
}