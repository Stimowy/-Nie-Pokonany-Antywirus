using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject rockObj;
    private float timer = 0f;
    private void Start()
    {
        rockObj.AddComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            
            particle.Stop();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
