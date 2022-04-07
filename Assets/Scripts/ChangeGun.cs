using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunTypes { Red, Blue,Green };

public class ChangeGun : MonoBehaviour
{
    [SerializeField] private GunTypes gunType;

    [SerializeField] GameObject bulletParent,playerParent;

    [SerializeField] Material redMat, blueMat, greenMat;

    Color green, red, blue;

    private void Start()
    {
        green = new Color(0.061f, 0.51f, 0.036f);
        red = new Color(0.85f, 0.22f, 0.052f);
        blue = new Color(0.072f, 0.63f, 0.68f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            switch (gunType)
            {
                case GunTypes.Red:

                    GunBulletChange(redMat, red);

                    break;

                case GunTypes.Blue:

                    GunBulletChange(blueMat, blue);

                    break;

                case GunTypes.Green:

                    GunBulletChange(greenMat, green);

                    break;

                default:
                    break;
            }
            
            
        }
    }

    void GunBulletChange(Material mat, Color color)
    {
        for (int i = 0; i < playerParent.transform.childCount; i++)
        {
            playerParent.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = mat;
        }
        for (int i = 0; i < bulletParent.transform.childCount; i++)
        {
            bulletParent.transform.GetChild(i).GetComponent<TrailRenderer>().startColor = color;
        }
    }
}
