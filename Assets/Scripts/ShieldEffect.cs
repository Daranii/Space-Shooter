using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    private float _timeToLive;
    
    public void SetTimeToLive(float timeToLive) => _timeToLive = timeToLive;

    public void ExtendTimeToLive(float timeToLive) => _timeToLive += timeToLive;

    private void Update()
    {
        _timeToLive -= Time.deltaTime;
        
        if (_timeToLive < 0.0001f)
            Destroy(gameObject);
    }
}