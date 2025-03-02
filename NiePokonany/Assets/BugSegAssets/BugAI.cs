using System.Collections;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class BugAI : MonoBehaviour
{
    //[SerializeField] private float NearestPointSearchRange = 0.5f;
    private NavMeshAgent bugNavAgent;
    private bool DestinationSet = false;
    private bool offMeshLinkInProgress = false;
    private bool alive = true;
    private string state = "idle";
    private float timeToPickingNew = 0f;
    [SerializeField] private GameObject particle;
    [SerializeField] private pickableFinder pickableFinderScript;
    [SerializeField] private HolesManager holesManager;
    private void Awake()
    {
        bugNavAgent = GetComponent<NavMeshAgent>();
        pickableFinderScript = GameObject.Find("rayCast").GetComponent<pickableFinder>();
        holesManager = GameObject.Find("level1").GetComponent<HolesManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pickable")
        {
            //Debug.Log(collision.gameObject.name);
            if (pickableFinderScript != null)
            {
                if (pickableFinderScript.timeOfHolding >= 1.2f)
                {
                    Destroy(collision.gameObject);
                    holesManager.amountOfBugs--;
                    Instantiate(particle,this.gameObject.transform.position,this.gameObject.transform.rotation);
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void Update()
    {
        if (alive)
        {
            if(state == "idle")
            {
                Vector3 randomPos = Random.insideUnitSphere * 40f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 40f, NavMesh.AllAreas);
                MoveTo(navHit);
                state = "walk";
            }
            if(state == "walk")
            {
                if (bugNavAgent.remainingDistance <= bugNavAgent.stoppingDistance && !bugNavAgent.pathPending)
                {
                    state = "idle";
                }
                timeToPickingNew += Time.deltaTime;
                if (timeToPickingNew >= 10f)
                {
                    state = "idle";
                    timeToPickingNew = 0f;
                }
                timeToPickingNew += Time.deltaTime;
                //Debug.Log(timeToPickingNew);
            }

            if (!bugNavAgent.pathPending && !bugNavAgent.isOnOffMeshLink && (bugNavAgent.remainingDistance <= bugNavAgent.stoppingDistance))
            {
                DestinationSet = false;
            }
            if (bugNavAgent.isOnOffMeshLink && !offMeshLinkInProgress)
            {
                offMeshLinkInProgress = true;
                StartCoroutine(FollowOffMeshLinkLerp());
            }
        }
        else
        {
            
        }
    }
    IEnumerator FollowOffMeshLinkLerp()
    {
        //bugNavAgent.updatePosition = false;
        //bugNavAgent.updateRotation = false;
        //bugNavAgent.updateUpAxis = false;
        Vector3 newPosition = transform.position;
        Vector3 endPosition = bugNavAgent.currentOffMeshLinkData.endPos;
        while (!Mathf.Approximately(Vector3.SqrMagnitude(endPosition - transform.position),0f))
        {
            newPosition = Vector3.MoveTowards(transform.position, endPosition, bugNavAgent.speed * Time.deltaTime);
            transform.position = newPosition;
            yield return new WaitForEndOfFrame();
        }
        offMeshLinkInProgress = false;
        bugNavAgent.CompleteOffMeshLink();
        //bugNavAgent.updatePosition = true;
        //bugNavAgent.updateRotation = true;
        //bugNavAgent.updateUpAxis = true;
    }
    public void MoveTo(/*Vector3 newDestination*/ NavMeshHit hit)
    {
        bugNavAgent.SetDestination(hit.position);
        DestinationSet = true;
        /*
        NavMeshHit hit;
        if(NavMesh.SamplePosition(newDestination,out hit, NearestPointSearchRange, NavMesh.AllAreas))
        {
            bugNavAgent.SetDestination(hit.position);
            DestinationSet = true;
        }
        */
    }
}
