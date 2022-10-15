using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChild : MonoBehaviour
{
    [SerializeField] Transform bulletPose;
    bool isActive;
    bool shooting=true;

    float randomWait;

    private void Update()
    {
        if (!isActive) return;
        if (!shooting) return;

        if (GameManager.Instance.gameState != GameState.Play) return;

        ShootControl();

    }

    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }

    void ShootControl()
    {
        StartCoroutine(ShootControlCR());
       
    }

    IEnumerator ShootControlCR()
    {
        shooting = false;

        randomWait = Random.Range(0, 0.5f);
        yield return new WaitForSeconds(randomWait);
        ObjectPooling.Instance.GetSpawnObject("Bullet", bulletPose.position, Quaternion.identity);

        
        yield return new WaitForSeconds(1.5f-randomWait);
        shooting = true;

        

    }
}
