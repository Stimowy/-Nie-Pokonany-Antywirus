using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractableScreen : GraphicRaycaster
{
    public Camera computerCamera;
    public GraphicRaycaster screenCaster; 
    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        Ray ray = eventCamera.ScreenPointToRay(eventData.position); 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform == transform)
            {
                //Debug.Log(hit.collider.gameObject.name);
                Vector3 virtualPos = new Vector3(hit.textureCoord.x, hit.textureCoord.y);
                virtualPos.x *= computerCamera.targetTexture.width;
                virtualPos.y *= computerCamera.targetTexture.height;
                
                eventData.position = virtualPos;
                
                screenCaster.Raycast(eventData, resultAppendList);
                //Debug.Log(screenCaster);
            }
            
        }
    }
    public void TestSkidibi()
    {
        Debug.Log("SKIDIBI");
    }
}
