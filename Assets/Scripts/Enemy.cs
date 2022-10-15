using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable
{
    [SerializeField] Animator anim;
    [SerializeField] NavMeshFollow navMeshFollow;

    int randomBorn;

    Vector3 bornOffsetPose;

    public void Die()
    {
        anim.SetBool("die", true);
        bornOffsetPose = transform.localPosition + Vector3.back * 50;
        navMeshFollow.isDeath = true;
        StartCoroutine(DieCR());
    }

    IEnumerator DieCR()
    {
        yield return new WaitForSeconds(1);

        ReBorn();
        ObjectPooling.Instance.BackToPool(this.gameObject, "Enemy");

        
    }

    void ReBorn()
    {
        if (GameManager.Instance.gameState != GameState.Play) return;

        randomBorn = Random.Range(1, 3);
        

        for (int i = 0; i < randomBorn; i++)
        {
            ObjectPooling.Instance.GetSpawnObject("Enemy", bornOffsetPose, Quaternion.identity);
        }
    }

    public void Attack()
    {
        Debug.Log("enemyAttack");
    }

    
}
