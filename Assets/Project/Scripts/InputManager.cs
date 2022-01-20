using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class InputManager : MonoBehaviour
{
    public GameObject target;
 
    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
 
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
 
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
 
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (raycastManager.Raycast(Input.GetTouch(0).position, hits))
        {
            var hitPose = hits[0].pose;
    
            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(target, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}