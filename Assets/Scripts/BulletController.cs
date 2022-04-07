using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletController : MonoBehaviour
{
    ObjectPooling objectPooling;

    public static int scoreAmount = 0;

    private void Awake()
    {
        objectPooling = ObjectPooling.Instance;
    }

    private void Start()
    {
        PlayerPrefs.GetInt("Score", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
            other.transform.GetChild(0).GetComponent<Animator>().SetBool("die", true);

            ComponentChange(other.gameObject, false,"DeathEnemy");

            scoreAmount+=3;
            ButtonController.Instance.scoreText.text = scoreAmount.ToString();
        }

        else if (other.tag == "Ground")
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
        }
    }

    public static void ComponentChange(GameObject go, bool isEnabled,string newTag)
    {
        go.tag = newTag;
        go.GetComponent<NavMeshFollow>().enabled = isEnabled;
        go.GetComponent<NavMeshAgent>().enabled = isEnabled;
        
    }
}
