using UnityEngine;

public class destroyBomb : MonoBehaviour
{
    private float timer = 2;
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
