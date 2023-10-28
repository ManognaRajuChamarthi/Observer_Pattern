using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager _eventManagerInstance;
    public event Action<int>  _onDoorwayTriggerEnter;
    public event Action<int> _onDoorwayTriggerExit;

    private void Awake()
    {
        _eventManagerInstance = this;
    }

    public void DoorWayTriggerEnter(int id)
    {
        if(_onDoorwayTriggerEnter != null)
        {
            _onDoorwayTriggerEnter(id);
        }
    }

    public void DoorWayTriggerExit(int id)
    {
        if(_onDoorwayTriggerExit != null)
        {
            _onDoorwayTriggerExit(id);
        }
    }

    
}
