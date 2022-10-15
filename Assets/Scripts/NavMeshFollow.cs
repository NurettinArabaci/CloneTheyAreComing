using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static partial class EventManager
{
    public static event System.Action OnStopMove;
    public static void Fire_OnStopMove() { OnStopMove?.Invoke(); }
}

public class NavMeshFollow : MonoBehaviour
{
    NavMeshAgent nav;

    public bool isDeath;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if (isDeath)
        {
            OnStopMove();
            return;
        }

        if (GameManager.Instance.gameState==GameState.Play)
        {
            nav.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        
    }

    void OnStopMove()
    {
        //GameEndPoints.isEnd = true;
        nav.enabled = false;
        
    }

    private void OnEnable()
    {
        EventManager.OnStopMove += OnStopMove;
        isDeath = false;
        nav.enabled = true;

    }

    private void OnDisable()
    {
        EventManager.OnStopMove -= OnStopMove;


    }
}
