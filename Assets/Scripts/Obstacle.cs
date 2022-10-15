using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IAttackable
{
    public void Attack()
    {
        Debug.Log("ObstacleAttack");
    }
}
