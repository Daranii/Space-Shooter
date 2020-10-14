using Entities;
using UnityEngine;

namespace PowerUps
{
    
    public sealed class Shield : PowerUp
    {
        protected override void ApplyEffect(Collider2D other)
        {
            var player = other.GetComponent<Player>();

            if (!player.shieldEffect)
            {
                var instance = Instantiate(powerUpEffect, other.transform.position, Quaternion.identity);
                instance.transform.parent = other.transform;
                
                var shieldEffect = instance.GetComponent<ShieldEffect>();
                shieldEffect.SetTimeToLive(powerUpTime);
                player.shieldEffect = shieldEffect;
            }
            else
            {
                player.shieldEffect.ExtendTimeToLive(powerUpTime);
            }
        }
    }
}