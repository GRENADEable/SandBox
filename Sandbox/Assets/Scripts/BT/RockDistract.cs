using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDistract : Node
{
    public override void Execute(EnemyBehaviourTree ownerBT)
    {
        /*float distanceToRock = Vector3.Distance(ownerBT.rock.position, ownerBT.transform.position);
        if (distanceToRock < ownerBT.rockDistance)
        {
            Debug.Log("Found Rock");
        }*/
    }
}
