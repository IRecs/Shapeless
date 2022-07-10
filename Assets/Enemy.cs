using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 startCoords;
    [SerializeField] Objectives objectives;
    [SerializeField] bool _hunt;
    
    private void Update()
    {
        if (_hunt)
        {
            Vector3 direction = -startCoords.normalized;
            transform.localPosition += direction * speed * Time.deltaTime;
        }
    }

    public void StartHunt()
    {
        transform.localPosition = startCoords;
        _hunt = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectives.StartSecondHunt();
            StartHunt();

        }

    }
}
