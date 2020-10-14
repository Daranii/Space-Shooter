using System;
using Entities;
using Helper;
using UnityEngine;

namespace PowerUps
{
    /// <summary>
    /// It is used as a base class for power ups mainly because Reflection can be used to generate the list
    /// of power ups without the need fill it manually. Especially useful for automated testing.
    /// </summary>
    public abstract class PowerUp : MonoBehaviour
    {
        [SerializeField] protected float verticalSpeed = 2;
        [SerializeField] protected float powerUpTime = 5f;
        [SerializeField] protected GameObject powerUpEffect;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            ApplyEffect(other);
            Destroy(gameObject);
        }

        private void Update()
        {
            Move();
            DestroyOffScreen();
        }

        protected abstract void ApplyEffect(Collider2D other);

        protected virtual void Move()
        {
            transform.Translate(Vector3.down * (verticalSpeed * Time.deltaTime));
        }
        
        protected virtual void DestroyOffScreen()
        {
            if (transform.position.y < ScreenValues.BottomLimit - ScreenValues.OffScreenEffectsLength)
                Destroy(gameObject);
        }

#if UNITY_INCLUDE_TESTS
        // protected virtual bool ResultTester(Player player)
        // {
        //     throw new NotImplementedException();
        // }
#endif
    }
}