using System;
using System.Collections;
using System.Collections.Generic;
using Helper;
using Managers;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Stats playerStats = PlayerValues.DefaultPlayerStats;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject defaultProjectilePrefab;
        [SerializeField] private Transform projectileContainer;

        public ShieldEffect shieldEffect;

        private bool _isAttackPowerUpActive;
        private float _nextFireTime = -1f;
        private Action _onPlayerDeath;
        private Action<Transform, Transform> _powerUpAttack;
        private Coroutine _attackPowerUpCoroutine;

        private void Start()
        {
            transform.position = new Vector3(0, ScreenValues.BottomLimit);
        }

        public void ModifyStats(Stats modifiedStats, float powerUpTime)
        {
            var livesVerification = playerStats + modifiedStats;
            
            if (livesVerification.lives < 0)
            {
                Debug.LogError("Lives is smaller than 0");
                livesVerification.lives = 0;
            }

            playerStats = livesVerification;

            if (powerUpTime > 0.0001f)
                StartCoroutine(UndoStatModificationCoroutine(modifiedStats, powerUpTime));
        }

        private IEnumerator UndoStatModificationCoroutine(Stats modifiedStats, float time)
        {
            yield return new WaitForSeconds(time);
        
            playerStats -= modifiedStats;
        }

        public void SetAttackPowerUp(Action<Transform, Transform> powerUp, float time)
        {
            _powerUpAttack = powerUp;

            if (_attackPowerUpCoroutine != null)
                StopCoroutine(_attackPowerUpCoroutine);

            _isAttackPowerUpActive = true;
            _attackPowerUpCoroutine = StartCoroutine(RemovePowerUpCoroutine(time));
        }

        public void SetOnPlayerDeath(Action deathAction)
        {
            _onPlayerDeath += deathAction;
        }

        public void TakeDamage()
        {
            if (shieldEffect)
            {
                Destroy(shieldEffect.gameObject);
                return;
            }

            playerStats.lives--;
            UiManager.Instance.UpdateLives(playerStats.lives);

            if (playerStats.lives < 1)
                PlayerDeath();
        }

        public void Fire()
        {
            if (Time.time < _nextFireTime) return;

            if (_isAttackPowerUpActive)
                _powerUpAttack(transform, projectileContainer);
            else
                FireDefaultProjectile();

            _nextFireTime = Time.time + playerStats.fireRate;
        }

        private void FireDefaultProjectile()
        {
            var position = transform.position;
            position.y += ScreenValues.LaserOffset;

            var projectile = 
                GameObjectPoolManager.Instance.RequestObject(defaultProjectilePrefab, position, Quaternion.identity,
                    projectileContainer);
            projectile.SetActive(true);
        }

        public void Move(Vector2 movement)
        {
            var x = movement.x * playerStats.horizontalSpeed;
            var y = movement.y * playerStats.verticalSpeed;
            
            transform.Translate(new Vector3(x, y, 0) * Time.deltaTime);
            transform.position = BoundsVerification(transform.position);
        }

        private void PlayerDeath()
        {
            _onPlayerDeath?.Invoke();
            Destroy(gameObject);
        }

        private IEnumerator RemovePowerUpCoroutine(float time)
        {
            yield return new WaitForSeconds(time);

            _isAttackPowerUpActive = false;
            _attackPowerUpCoroutine = null;
        }
        
        private Vector2 BoundsVerification(Vector2 position)
        {
            // Wrapping horizontal axis
            if (position.x > ScreenValues.RightLimit + ScreenValues.OffScreenEffectsLength)
                position.x = ScreenValues.LeftLimit - ScreenValues.OffScreenEffectsLength;
            else if (position.x < ScreenValues.LeftLimit - ScreenValues.OffScreenEffectsLength)
                position.x = ScreenValues.RightLimit + ScreenValues.OffScreenEffectsLength;

            // Clamping vertical axis
            position.y = Mathf.Clamp(position.y, ScreenValues.BottomLimit, ScreenValues.TopLimit);

            return position;
        }
    }
}