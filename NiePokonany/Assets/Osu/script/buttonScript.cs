using UnityEngine;

public class buttonScript : MonoBehaviour
{
    private GameObject pref;
    [SerializeField] private KeyCode button;
    [SerializeField] private triggerOn good;
    [SerializeField] private triggerOn better;

    [SerializeField] private pointCounter points;
    [SerializeField] private triggerOn trigger1;
    [SerializeField] private triggerOn trigger2;

    [SerializeField] private generatePrefabs generate;

    private void Update()
    {
        if (Input.GetKeyDown(button))
        {
            WhichTrigger();
            Destroy(pref);
            pref = null;
            triggerOff();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pref = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        pref = null;
    }

    private void WhichTrigger()
    {
        if(better.IsTrigger() && better.IsName() == 1)
        {
            points.AddPointsPlus();
            points.AddScore();
            generate.addDamage(2);
        }
        else if(good.IsTrigger() && good.IsName() == 1)
        {
            points.AddPoints();
            generate.addDamage(1);
        }
        else if(good.IsTrigger() && good.IsName() == 2)
        {
            points.DiviseScore();
        }
    }

    private void triggerOff()
    {
        trigger1.SetTrigger();
        trigger2.SetTrigger();
    }
}
