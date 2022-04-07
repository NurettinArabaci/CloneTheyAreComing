using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    public static ShootControl Instance;

    GameObject bullet;

    Rigidbody bulletRb;

    int bulletForce = 50;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }

    public void Fire()
    {
        bullet= ObjectPooling.Instance.GetSpawnObject("Bullet", transform.position, Quaternion.identity);
        bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.back * bulletForce);
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Fire), 0.1f, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    
    
}
