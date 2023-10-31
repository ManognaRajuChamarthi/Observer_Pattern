using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private int _triggerID;

    // if someone with a collider enters the trigger area then we will call the entry function from the event manager
    //also we will pass in the trigger ID
    private void OnTriggerEnter(Collider other)
    {
        EventManager._eventManagerInstance.DoorWayTriggerEnter(_triggerID);
    }
    // if someone with a collider exits the trigger area then we will call the exit function from the event manager
    //also we will pass in the trigger ID
    private void OnTriggerExit(Collider other)
    {
        EventManager._eventManagerInstance.DoorWayTriggerExit(_triggerID);
    }
}
