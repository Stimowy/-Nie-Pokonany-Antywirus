using UnityEngine;
using System.Collections;
using System.Numerics;
using Unity.Mathematics;

public class pickableFinder : MonoBehaviour
{
    GameObject pickedObject = null;
    Rigidbody pickedRigidbody = null;
    [SerializeField] GameObject pickedLocations;
    [SerializeField] Animator character;
    bool firstTime;
    float startTimer;
    float endTimer;
    public bool throwPossible = false;
    public float timeOfHolding = 0f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startTimer = Time.time;
        }
        if (Input.GetMouseButtonUp(1) && throwPossible)
        {
            endTimer = Time.time;
            timeOfHolding = Mathf.Clamp(endTimer - startTimer, 0f, 2f);
            throwObj(timeOfHolding);
        }
    }
    private void FixedUpdate()
    {

        if (firstTime && pickedObject != null)
        {
            pickedLocations.transform.position = pickedObject.transform.position;
            character.SetBool("holding", true);
        }
        if (Input.GetMouseButton(0) && pickedObject != null)
        {
            pickedRigidbody.useGravity = false;
            pickedObject.transform.position = pickedLocations.transform.position;
            //---throwing
            if (Input.GetMouseButton(1))
            {
                //Debug.Log(Time.time - startTimer);
                throwPossible = true;
            }
            //----
            firstTime = false;
            return;
        }
        else
        {
            throwPossible = false;
            character.SetBool("holding", false);
            if (pickedObject != null) {
                pickedRigidbody.useGravity = true;
            }
            pickedRigidbody = null;
            pickedObject = null;
            firstTime = true;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward) * 5, Color.red);
            if (hit.collider.CompareTag("pickable") && !Input.GetMouseButton(0))
            {
                pickedObject = hit.collider.gameObject;
                pickedRigidbody = hit.rigidbody;
                firstTime = true;
            }
        }

    }
    private IEnumerator countDown()
    {
        yield return new WaitForSeconds(.8f);
        character.SetBool("throwing", false);
    }
    private void throwObj(float strength){
        character.SetBool("throwing", true);
        pickedRigidbody.AddForce(transform.forward * strength*20, ForceMode.Impulse);
        pickedRigidbody.useGravity = true;
        pickedObject = null;
        pickedRigidbody = null;
        StartCoroutine(countDown());
    }
}
