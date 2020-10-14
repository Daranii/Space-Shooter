using Entities;
using Managers;
using UnityEngine;

namespace PowerUps
{
    public sealed class TripleShot : PowerUp
    {
        protected override void ApplyEffect(Collider2D other)
        {
            other.GetComponent<Player>()?.SetAttackPowerUp(TripleShotAttack, powerUpTime);
        }

        private void TripleShotAttack(Transform playerTransform, Transform projectileContainer)
        {
            var instance =
                GameObjectPoolManager.Instance.RequestObject(powerUpEffect, playerTransform.position,
                    Quaternion.identity, projectileContainer);
            instance.SetActive(true);
        }
    }
}