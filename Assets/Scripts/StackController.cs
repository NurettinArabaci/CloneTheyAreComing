using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public enum OperatorTypes { Sum, Mult };

public class StackController : MonoBehaviour
{
    [SerializeField] private OperatorTypes sumOrMult;
    [SerializeField] private int operatorAmount;

    GameObject playerParent, operatorParent;

    TextMeshProUGUI operatorText;
    TextMeshProUGUI sembolText;

    public static int playerChildAmount;

    int sumNumber;
    int multNumber;

    private void Awake()
    {
        VariableReferences();   
    }

    private void Start()
    {
        playerChildAmount = 1;
        operatorText.text = operatorAmount.ToString();
        sembolText.text = sumOrMult == OperatorTypes.Sum ? "+" : "x";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            SumMultOperator();
            Spawn();

            OperatorColliderAndTweening();
        }
    }


    public void SumMultOperator()
    {
        if (sumOrMult == OperatorTypes.Sum)
        {
            sumNumber = operatorAmount;
            playerChildAmount += sumNumber;
            operatorAmount = sumNumber;
            PlayerCount.playerCount.text = playerChildAmount.ToString();
        }
        else if (sumOrMult == OperatorTypes.Mult)
        {
            multNumber = operatorAmount;
            operatorAmount = (multNumber - 1) * playerChildAmount;
            playerChildAmount = multNumber * playerChildAmount;
            PlayerCount.playerCount.text = playerChildAmount.ToString();
        }
    }

    public void Spawn()
    {
        
        for (int i = 0; i < operatorAmount; i++)
        {

         ObjectPooling.Instance.GetSpawnObject("PlayerChild", playerParent.transform.position, Quaternion.Euler(0, 180, 0));
        }

    }

    void VariableReferences()
    {
        sembolText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        operatorText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        playerParent = GameObject.FindGameObjectWithTag("PlayerParent");
        operatorParent = transform.parent.gameObject;

    }

    void OperatorColliderAndTweening()
    {
        
        for (int i = 0; i < 2; i++)
        {
            operatorParent.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
        }
        operatorParent.transform.DOMoveY(-6f, 1.5f);
        


    }

}
