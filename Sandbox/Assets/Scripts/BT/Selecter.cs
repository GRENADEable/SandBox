using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter : Node
{
    //Selecter Node:
    //When all the child nodes succeed, the selector node succeds.
    //If one of the child node fails, then it will goto the next children of nodes.

    //On start it wil make the condition of the child node running.
    //Condition doesn't meet, the child node fails, moves on to the next child of nodes.
    //All child nodes failed, the selector node fails.
    //Coniditon does meet, the child node is sucessful.
    //If one of the child nodes are sucessful, then selector node succeds.
    public override void Execute(EnemyBehaviourTree ownerBT)
    {
        //currCondition will be the condition of the parent node.;
        //The list are similar as arrays in C#.

        for (int i = 0; i < children.Count; i++)
        {
            children[i].Execute(ownerBT);//Run the code and then will check them in the code below.

            //Node Succeeded
            if (children[i].currCondition == Condition.Success)
            {
                currCondition = Condition.Success;
                return;
            }
            

            //Node Running
            else if (children[i].currCondition == Condition.Running)
            {
                currCondition = Condition.Running;
                return;
            }
            
        }

        //Node Fail
        currCondition = Condition.Fail;
        return;
    }
}
