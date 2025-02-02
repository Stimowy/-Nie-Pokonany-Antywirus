using UnityEngine;
using System.Collections;

public class pickableFinder : MonoBehaviour
{

    GameObject pickedObject = null;
    Rigidbody pickedRigidbody = null;
    [SerializeField] GameObject pickedLocations;
    [SerializeField] Animator character;
    bool firstTime;
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
                character.SetBool("throwing", true);
                pickedRigidbody.AddForce(transform.forward * 40, ForceMode.Impulse);
                pickedRigidbody.useGravity = true;
                pickedObject = null;
                pickedRigidbody = null;
                StartCoroutine(countDown());
            }
            //----
            firstTime = false;
            return;
        }
        else
        {
            character.SetBool("holding", false);
            if (pickedObject != null) {
                pickedRigidbody.useGravity = true;
            }
            pickedRigidbody = null;
            pickedObject = null;
            firstTime = true;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5, Color.red);
            if (hit.collider.CompareTag("pickable") && !Input.GetMouseButton(0))
            {
                Debug.Log("niga");
                pickedObject = hit.collider.gameObject;
                pickedRigidbody = hit.rigidbody;
                firstTime =true;
            }
        }

    }
    private IEnumerator countDown()
    {
        yield return new WaitForSeconds(.8f);
        character.SetBool("throwing", false);
    }

}
