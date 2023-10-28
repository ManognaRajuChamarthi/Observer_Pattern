using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform _doorTransform;

    [SerializeField] private int _doorId;
    [SerializeField] private float _doorSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _doorTransform = GetComponent<Transform>();

        EventManager._eventManagerInstance._onDoorwayTriggerEnter += DoorOpen;
        EventManager._eventManagerInstance._onDoorwayTriggerExit += DoorClose;
    }

    private void DoorOpen(int Id)
    {
        if (_doorId == Id)
        {
            _doorTransform.transform.Translate(0, 3, 0);
        }
        
    }

    private void DoorClose(int Id)
    {
        if (_doorId == Id)
        {
            _doorTransform.transform.Translate(0, -3, 0);
        }
    }

    private void OnDestroy()
    {
        EventManager._eventManagerInstance._onDoorwayTriggerEnter -= DoorOpen;
        EventManager._eventManagerInstance._onDoorwayTriggerExit -= DoorClose;
    }
}
