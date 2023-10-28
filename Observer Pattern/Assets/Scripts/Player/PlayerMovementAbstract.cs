using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementAbstract 
{
    public abstract void EnterState(PlayerMovementContext player);

    public abstract void UpdateState(PlayerMovementContext player);

    public abstract void ExitState(PlayerMovementContext player);
}
