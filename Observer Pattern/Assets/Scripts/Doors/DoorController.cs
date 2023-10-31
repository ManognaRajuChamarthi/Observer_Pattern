using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform _doorTransform;// ref for door's transform comp

    [SerializeField] private int _doorId;// door's ID
    
    // Start is called before the first frame update
    void Start()
    {
        _doorTransform = GetComponent<Transform>();


        EventManager._eventManagerInstance._onDoorwayTriggerEnter += DoorOpen;// we subscribe to the events at the start
        EventManager._eventManagerInstance._onDoorwayTriggerExit += DoorClose;
    }

    private void DoorOpen(int Id)//this function is listening for Entry event.
    {
        //since event manager already has ID as argument passed by the trigger controller, we can check it here.
        if (_doorId == Id)
        {
            _doorTransform.transform.Translate(0, 3, 0);// if event happens change its location to the new vector position
        }
        
    }

    private void DoorClose(int Id)// this function is looking for exit event.
    {
        //since event manager already has ID as argument passed by the trigger controller, we can check it here.
        if (_doorId == Id)
        {
            _doorTransform.transform.Translate(0, -3, 0);// if event happens change its location to the new vector position
        }
    }

    private void OnDestroy()
    {
        EventManager._eventManagerInstance._onDoorwayTriggerEnter -= DoorOpen;// we unsubscribe to the events if the game object is destroyed
        EventManager._eventManagerInstance._onDoorwayTriggerExit -= DoorClose;// or if it is no longer available in the scene
    }
}
