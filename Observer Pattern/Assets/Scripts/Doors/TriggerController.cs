using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private int _triggerID;

    private void OnTriggerEnter(Collider other)
    {
        EventManager._eventManagerInstance.DoorWayTriggerEnter(_triggerID);
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager._eventManagerInstance.DoorWayTriggerExit(_triggerID);
    }
}
