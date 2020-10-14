using Helper;
using Managers;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 8f;

    private void Update()
    {
        MoveUp();
        DespawnOffScreen();
    }
    
    private void OnDisable()
    {
        if (transform.parent.CompareTag("PowerUpEffect"))
            GameObjectPoolManager.Instance.ReturnObject(transform.parent.gameObject);
        else
            GameObjectPoolManager.Instance.ReturnObject(gameObject);
    }

    private void DespawnOffScreen()
    { 
        if (transform.position.y > ScreenValues.TopLimit + ScreenValues.OffScreenEffectsLength)
        {
            if (transform.parent.CompareTag("PowerUpEffect"))
                transform.parent.gameObject.SetActive(false);
            else
                gameObject.SetActive(false);
        }
    }
    
    private void MoveUp()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * projectileSpeed));
    }
}