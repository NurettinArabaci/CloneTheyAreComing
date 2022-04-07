using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StopMovement()
    {
        PlayerController.speed = 0;
        PlayerController.limitX = 0;
        
    }

   public void StartMovement()
    {
        PlayerController.speed = 10;
        PlayerController.limitX = 11;
    }

    public void EnabledOpenClose(GameObject player, GameObject enemiesParent, bool isEnabled)
    {
        player.transform.GetChild(2).GetComponent<Animator>().enabled = isEnabled;

        for (int i = 0; i < enemiesParent.transform.childCount; i++)
        {
            enemiesParent.transform.GetChild(i).GetComponent<NavMeshAgent>().enabled = isEnabled;
            enemiesParent.transform.GetChild(i).GetComponent<NavMeshFollow>().enabled = isEnabled;
            enemiesParent.transform.GetChild(i).GetChild(0).GetComponent<Animator>().enabled = isEnabled;
        }
    }
}
