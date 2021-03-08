using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Manager<InteractionManager>
{
    public LayerMask interactableLayer;
    public LayerMask animalLayer;
    public LayerMask sleep;

    public ParticleSystem collisionParticles;

    private Camera mainCamera;

    private Interactable currentInteractable;
    private Feed currentFeed;
    private petting currentPetting;

    private Vector3 startTouchPosition;
    private float startInteractDistance;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        DetectFingerInEditor();
#else
        DetectFingerInPhone();
#endif

        //MoveInteractable();
    }

    

    private Vector3? GetTouchPosition()
    {
#if UNITY_EDITOR
        // Editor
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, startInteractDistance);
#else
        // Phone
        if (Input.touchCount == 0) return null;
        Vector3 touchPosition = Input.GetTouch(0).position;
        return new Vector3(touchPosition.x, touchPosition.y, startInteractDistance);
#endif
    }

    private void DetectFingerInEditor()
    {
        Ray ray;
        RaycastHit hit;

        // First down
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // if (Physics.Raycast(ray, out hit, 50f, interactableLayer))
            // {
            //     // maybe hit an interactable
            //     Interactable interactable = hit.rigidbody.GetComponent<Interactable>();

            //     if (interactable)
            //     {
            //         // really hit an interactable
            //         currentInteractable = interactable;
            //         startInteractDistance = hit.distance;

            //         // Inform interactable with the touch posisiont
            //         startTouchPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, startInteractDistance));
            //         currentInteractable.OnTouchDown(startTouchPosition);
            //     }
            // }
            //animal disappear
        
	        // if (Physics.Raycast(ray, out hit, 50f, animalLayer)){
	        //     	Feed feed = hit.rigidbody.GetComponent<Feed>();
	        //     	if(feed){
	        //     		currentFeed = feed;
	        //     		currentFeed.OnTouchDown();
	        //     	}
	        //     }


	        //animal petting
	        if (Physics.Raycast(ray, out hit, 50f, sleep)){
	        	Debug.Log("petpet1");
	            	petting pet = hit.rigidbody.GetComponent<petting>();
	            	if(pet){

	            		currentPetting = pet;
	            		currentPetting.OnTouchDown();
	            	}
	            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            // //Reset
            if (currentPetting)
            {
                currentPetting.OnTouchUp();
            }
            currentPetting = null;
        }



    }

    private void DetectFingerInPhone()
    {
        if (Input.touchCount == 0)
        {
            if (currentPetting)
            {
                currentPetting.OnTouchUp();
            }
            currentPetting = null;
            return;
        }

        Ray ray;
        RaycastHit hit;

        Vector3 touchPosition = Input.GetTouch(0).position;
        // First down
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = mainCamera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out hit, 50f, sleep))
            {
            	Debug.Log("petpet1");
	            	petting pet = hit.rigidbody.GetComponent<petting>();
	            	if(pet){

	            		currentPetting = pet;
	            		currentPetting.OnTouchDown();
	            	}
	           
            }
        }
    }
}