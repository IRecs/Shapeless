using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private void FixedUpdate() =>
        transform.position = _target.position;
}
