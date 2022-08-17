using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class EventManager
{
    public static event System.Action OnStopMove;
    public static void Fire_OnStopMove() { OnStopMove?.Invoke(); }
}

public class NavMeshFollow : MonoBehaviour
{
    NavMeshAgent nav;
    Animator enemyAnim;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponentInChildren<Animator>();
        
    }
    private void Update()
    {
        if (!GameEndPoints.isEnd)
        {
            nav.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        
    }

    void OnStopMove()
    {
        GameEndPoints.isEnd = true;
        nav.enabled = false;
        enemyAnim.enabled = false;
        
    }

    private void OnEnable()
    {
        EventManager.OnStopMove += OnStopMove;


    }

    private void OnDisable()
    {
        EventManager.OnStopMove -= OnStopMove;


    }
}
