using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if (GameEndPoints.isEnd==false)
        {
            nav.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        
    }

}
