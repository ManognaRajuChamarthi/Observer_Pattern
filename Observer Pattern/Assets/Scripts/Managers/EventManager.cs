using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager _eventManagerInstance;
    public event Action<int>  _onDoorwayTriggerEnter;// event if someone enters the doorway trigger area
    public event Action<int> _onDoorwayTriggerExit;// event if someone exits the doorway trigger area

    private void Awake()
    {
        _eventManagerInstance = this;
    }

    public void DoorWayTriggerEnter(int id)// function to call for entry, we also take an int ID as an argument 
    {
        if(_onDoorwayTriggerEnter != null)
        {
            _onDoorwayTriggerEnter(id);
        }
    }

    public void DoorWayTriggerExit(int id)// function to call  if player exits, we also take an int ID as an argument 
    {
        if(_onDoorwayTriggerExit != null)
        {
            _onDoorwayTriggerExit(id);
        }
    }

    
}
