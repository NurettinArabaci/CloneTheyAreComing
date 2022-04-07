using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCount : MonoBehaviour
{
    public static TextMeshProUGUI playerCount;

    private void Awake()
    {
        playerCount = GetComponent<TextMeshProUGUI>();
    }
}
