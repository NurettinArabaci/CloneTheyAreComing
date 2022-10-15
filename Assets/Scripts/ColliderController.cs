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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackable>() != null)
        {
            other.GetComponent<IAttackable>().Attack();
            ObjectPooling.Instance.BackToPool(gameObject, "PlayerChild");
            StackController.playerChildAmount--;
            //PlayerCount.playerCount.text = StackController.playerChildAmount.ToString();

            if (StackController.playerChildAmount <= 0)
            {
                EventManager.Fire_OnStopMove();
                ButtonController.Instance.restartBut.gameObject.SetActive(true);
                GameManager.Instance.StopMovement();
                GameManager.Instance.gameState = GameState.Lose;
            }

        }

    }

}
