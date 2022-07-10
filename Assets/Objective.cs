using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool found = false;
    [SerializeField] private GameObject _skin;
    [SerializeField] private Objectives objectives;
    [SerializeField] private bool secondObjective;
    [SerializeField] private GameObject _winText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!secondObjective)
            {
                _skin.SetActive(false);
                objectives.StartSecondHunt();
                this.gameObject.SetActive(false);
            }
            else
            {
                _skin.SetActive(false);
                _winText.SetActive(true);

            }
        }
        }
    }
