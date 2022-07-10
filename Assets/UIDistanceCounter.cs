using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDistanceCounter : MonoBehaviour
{
    [SerializeField] TMP_Text UICounter;
    [SerializeField] Objectives objectives;

    private void Update()
    {

        UICounter.text = ((int)objectives.distance).ToString();    }
}
