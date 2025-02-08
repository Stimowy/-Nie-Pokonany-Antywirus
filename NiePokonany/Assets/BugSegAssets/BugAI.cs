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
    private void Awake()
    {
        bugNavAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (alive)
        {
            if(state == "idle")
            {
                Vector3 randomPos = Random.insideUnitSphere * 20f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                MoveTo(navHit);
                state = "walk";
            }
            if(state == "walk")
            {
                if (bugNavAgent.remainingDistance <= bugNavAgent.stoppingDistance && !bugNavAgent.pathPending)
                {
                    state = "idle";
                }
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
