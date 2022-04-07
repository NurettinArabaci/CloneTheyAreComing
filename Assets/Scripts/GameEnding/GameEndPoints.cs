using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using Cinemachine;

public class GameEndPoints : MonoBehaviour
{
    [SerializeField] GameObject prefab,playerParent,enemiesParent;

    [SerializeField]CinemachineVirtualCameraBase vcam;

    public static GameObject[] endPoint = new GameObject[120];

    public static Vector3 startPointPos;

    public static int playerQueue=0;

    public static int endPointNumber=0;

    public static bool isEnd=false;

    private void Awake()
    {
        startPointPos = transform.position;
    }

    void Start()
    {
        endPointNumber = 0;
        isEnd = false;
        playerQueue = 0;
        for (int i = 0; i < 10; i++)
        {
            startPointPos = transform.position;
            startPointPos += Vector3.forward * 2*i;
            for (int j = 0; j < 12; j++)
            {
                endPoint[endPointNumber] = Instantiate(prefab, startPointPos,Quaternion.identity,transform.parent);
                startPointPos += Vector3.left * 2;
                endPointNumber++;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PlayerChild")
        {

            //other.transform.parent = endPoint[playerQueue].transform;
            other.transform.DOMove(endPoint[playerQueue].transform.position, 1.5f);

            //isEnd = true;

            other.GetComponent<NavMeshFollow>().enabled = false;
            other.GetComponent<NavMeshAgent>().enabled = false;

            
            playerQueue++;
            other.transform.GetChild(2).GetComponent<Animator>().enabled = false;
            other.tag ="TempTag";


        }
        if (other.tag == "Player")
        {
            vcam.m_Priority = 12;
            other.transform.GetChild(1).gameObject.SetActive(false);
            LevelController.Instance.LevelCompleted();

            Invoke(nameof(StopPlayerParent), 0.5f);
            Invoke(nameof(SuccessLevel), 5f);
            
        }
    }

   void StopPlayerParent()
    {
        GameManager.Instance.StopMovement();
    }

    void SuccessLevel()
    {
        ButtonController.Instance.nextLevelBut.gameObject.SetActive(true);
        GameManager.Instance.EnabledOpenClose(playerParent, enemiesParent, false);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + BulletController.scoreAmount);

        ButtonController.Instance.totalScore.text = PlayerPrefs.GetInt("Score").ToString();
        

    }
}
