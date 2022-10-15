using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletController : MonoBehaviour
{
    ObjectPooling objectPooling;

    public static int scoreAmount = 0;


    Rigidbody rb;

    private void Awake()
    {
        objectPooling = ObjectPooling.Instance;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PlayerPrefs.GetInt("Score", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            objectPooling.BackToPool(gameObject, "Bullet");

            other.GetComponent<Enemy>().Die();

            scoreAmount+=3;
            ButtonController.Instance.scoreText.text = scoreAmount.ToString();
        }

    }

    private void OnEnable()
    {
        rb.AddForce(Vector3.back * 100);
        StartCoroutine(ShootSpeedControl());
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }

    IEnumerator ShootSpeedControl()
    {
        yield return new WaitForSeconds(0.05f);
        rb.velocity = rb.velocity.normalized * 50;

        yield return new WaitForSeconds(2);
        if (gameObject.activeSelf)
        {
            ObjectPooling.Instance.BackToPool(gameObject, "Bullet");
        }

    }
    
}
