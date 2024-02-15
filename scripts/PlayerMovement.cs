using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(0, 0, speed * Time.deltaTime);
            //transform.Translate(0, 0, speed* Time.deltaTime);
            animator.SetFloat("Velocity", rb.velocity.magnitude);
        }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(0, 0, -speed * Time.deltaTime);
            //transform.Translate(0, 0, -speed * Time.deltaTime);
            animator.SetFloat("Velocity", rb.velocity.magnitude);
        }else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddRelativeForce(-speed * Time.deltaTime, 0, 0);
            //transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetFloat("Velocity", rb.velocity.magnitude);
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddRelativeForce(speed * Time.deltaTime, 0, 0);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetFloat("Velocity", rb.velocity.magnitude);
        }
        else
        {
            rb.AddRelativeForce(0, 0, 0);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetFloat("Velocity", 0);
        }

        float mouseX = Input.GetAxis("Mouse X");
        rb.AddRelativeTorque(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        //transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }
}
