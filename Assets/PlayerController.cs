using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]   private Rigidbody rb;
    [SerializeField] private float speed;

    float _verticalInput = 0;
    float _horizontalInput = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        _verticalInput = -Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector3(_verticalInput * speed*Time.deltaTime, rb.velocity.y, _horizontalInput * speed*Time.deltaTime);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed * Time.deltaTime);
    }
}
