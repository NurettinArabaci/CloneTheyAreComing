using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public static ColliderController Instance;

    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"|| other.tag == "Obstacle")
        {
           
            transform.GetChild(0).GetChild(0).GetComponent<ShootControl>().enabled = false;

            ObjectPooling.Instance.BackToPool(transform.gameObject, "PlayerChild");
            StackController.playerChildAmount--;
            PlayerCount.playerCount.text = StackController.playerChildAmount.ToString();

            if (StackController.playerChildAmount <= 0)
            {
                ButtonController.Instance.restartBut.gameObject.SetActive(true);
                GameManager.Instance.StopMovement();
            }

        }

    }

   

}
