using UnityEngine;

public class movePrefab : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animation animControl;

    private void Awake()
    {
        animControl = GetComponent<Animation>();

        if(transform.position.z == 0.5f)
        {
            int track = Random.Range(0, 2);
            if (track == 0)
            {
                animControl.Play("prefabAnim1");
            }
            else
            {
                animControl.Play("prefabAnim2");
            }
        }
        else if(transform.position.z == -0.2f)
        {
            int track = Random.Range(0, 2);
            if (track == 0)
            {
                animControl.Play("prefabAnim3");
            }
            else
            {
                animControl.Play("prefabAnim4");
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 speedVector = new Vector3(speed * Time.deltaTime * -1, 0f, 0f);

        transform.position += speedVector;
    }
}
