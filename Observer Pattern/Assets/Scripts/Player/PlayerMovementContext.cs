using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementContext : MonoBehaviour
{

    //stateMachine Ref;
    private PlayerMovementContext _context;
    private PlayerMovementAbstract _currentState;
    private WalkState _walkState = new WalkState();
    private RunState runState = new RunState();

    private void Awake()
    {
        _context = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentState = _walkState;
        _currentState.EnterState(_context);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(_context);
    }

    public void SwitchState(PlayerMovementAbstract newPlayerState)
    {
        _currentState = newPlayerState;
        newPlayerState.EnterState(_context);
    }
}
