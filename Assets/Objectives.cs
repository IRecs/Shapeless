using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{

    [SerializeField] private float _deltaTreasHold;
    [SerializeField] Transform firstObjectiveTransform;
    [SerializeField] Transform secondObjectiveTransform;
    [SerializeField] Transform _currentObjectiveTransform;
    [SerializeField] Vector3 firstObjective;

    [SerializeField] Vector3 secondObjective;

    [SerializeField] Objective firstObjectiveScript;

    private Vector3 _deltaPos;
    private Vector3 _lastPos;


    public float distance;


    private void Start()
    {
        _lastPos = transform.position;
        StartFirstHunt();
    }


    void StartFirstHunt()
    {
        _currentObjectiveTransform = firstObjectiveTransform;
        _currentObjectiveTransform.localPosition = new Vector3 ( firstObjective.x,_currentObjectiveTransform.localPosition.y,firstObjective.z);
    }

    private void FixedUpdate()
    {
        _deltaPos = transform.position - _lastPos;
        _lastPos = transform.position;

        if (_deltaPos.magnitude < _deltaTreasHold)
        {
            _currentObjectiveTransform.localPosition -= _deltaPos;

            distance = _currentObjectiveTransform.localPosition.magnitude;

        }


    }

    public void StartSecondHunt()
    {
        _currentObjectiveTransform = secondObjectiveTransform;
        _currentObjectiveTransform.localPosition = new Vector3(secondObjective.x, _currentObjectiveTransform.localPosition.y, secondObjective.z);
    }
    }
