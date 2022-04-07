using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectDeathEnemy : MonoBehaviour
{
    Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="DeathEnemy")
        {
            pos = new Vector3( Random.Range(-10, 10),other.transform.position.y,transform.position.z - Random.Range(20, 25));
            
            BulletController.ComponentChange(other.gameObject, true,"Enemy");

            ObjectPooling.Instance.BackToPool(other.gameObject, "Enemy");
            ObjectPooling.Instance.GetSpawnObject("Enemy",pos, Quaternion.identity);
        }
    }
}
