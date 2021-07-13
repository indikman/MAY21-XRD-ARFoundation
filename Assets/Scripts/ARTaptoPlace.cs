using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{

    public GameObject prefab;


    private GameObject spawnedPrefab;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

   
    void Update()
    {
        if (spawnedPrefab == null)
        {
            if(Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    spawnedPrefab = Instantiate(prefab, hitPose.position, prefab.transform.rotation);

                }
            }

        }
    }
}
