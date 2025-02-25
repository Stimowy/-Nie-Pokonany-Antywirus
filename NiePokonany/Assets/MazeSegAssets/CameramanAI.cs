using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CameramanAI : MonoBehaviour
{
    public GameObject eye;
    public GameObject player;
    private NavMeshAgent cameramanNav;
    private bool alive = true;
    [SerializeField] private string state = "sleep";
    private Animator anim;
    private CMLinker cmL;
    private void Awake()
    {
        cameramanNav = GetComponent<NavMeshAgent>();
        anim = cameramanNav.gameObject.GetComponent<Animator>();
        cmL = gameObject.GetComponentInChildren<CMLinker>();
    }
    private void Update()
    {
        if (alive)
        {
            /*
            if (iVC.IsVisible == "true")
            {
                if (state != "sleep")
                {
                    state = "stop";
                    iVC.IsVisible = "n";
                }
            }
            else if (iVC.IsVisible == "false")
            {
                if (state != "sleep")
                {
                    anim.speed = 5f;
                    state = "walk";
                    iVC.IsVisible = "n";
                }
            }
            */
            if (cmL.vis)
            {
                if (state != "sleep")
                {
                    state = "stop";
                }
            }
            else
            {
                if (state != "sleep" && anim.speed != 5f)
                {
                    anim.speed = 5f;
                    state = "walk";
                }
            }
            //Debug.Log(Vector3.Distance(eye.transform.position, player.transform.position));
            if (state == "sleep")
            {
                RaycastHit raycastHit;
                if (Physics.Linecast(eye.transform.position, player.transform.position, out raycastHit))
                {
                    if(raycastHit.collider.gameObject.name == "characterBox")
                    {
                        state = "walk";
                        cameramanNav.destination = player.transform.position;
                        anim.SetBool("Walking", true);
                    }
                }
            }
            if (state == "idle")
            {
                if (Vector3.Distance(eye.transform.position, player.transform.position) <= 10f)
                {
                    anim.SetBool("Walking", true);
                    state = "walk";
                }
            }
            if (state == "walk")
            {
                cameramanNav.isStopped = false;
                cameramanNav.destination = player.transform.position;
                if (cameramanNav.remainingDistance <= cameramanNav.stoppingDistance && !cameramanNav.pathPending)
                {
                    state = "kill";
                }
                if (Vector3.Distance(eye.transform.position,player.transform.position) >= 10f)
                {
                    cameramanNav.isStopped = true;
                    anim.SetBool("Walking", false);
                    state = "idle";
                }
            }   
            if(state == "stop")
            {
                cameramanNav.isStopped = true;
                anim.speed = 0f;
            }
            if(state == "kill")
            {
                Debug.Log("Death");
            }
        }
    }
}
