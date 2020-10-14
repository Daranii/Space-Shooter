using Helper;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            MoveDown();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            HandleCollisions(other);
        }

        private void OnDisable()
        {
            GameObjectPoolManager.Instance.ReturnObject(gameObject);
        }

        private void MoveDown()
        {
            transform.Translate(Vector3.down * (Time.deltaTime * speed));
            WrapVerticalWithRandomHorizontal();
        }

        private void WrapVerticalWithRandomHorizontal()
        {
            var position = transform.position;

            if (!(position.y < ScreenValues.BottomLimit - ScreenValues.OffScreenEffectsLength)) return;
        
            position.y = ScreenValues.TopLimit + ScreenValues.OffScreenEffectsLength;
            position.x = Random.Range(ScreenValues.LeftLimit, ScreenValues.RightLimit);
        
            transform.position = position;
        }

        private void HandleCollisions(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage();
                gameObject.SetActive(false);
            }
            else if (other.CompareTag("Bullet"))
            {
                ScoreManager.AddPoints(GetType());
                if (other.transform.parent.CompareTag("PowerUpEffect"))
                    other.transform.parent.gameObject.SetActive(false);
                else
                    other.gameObject.SetActive(false);
                
                gameObject.SetActive(false);
            }
        }
    }
}