using UnityEngine;
using System.Collections;

 
 public class HandTest : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    private float rotZ = 1.66f;
    Rigidbody rb;
    [SerializeField] float testMove = 10f;

    void Start()
    {
        Vector3 rot = transform.localPosition;
        rotY = rot.y;
        rotX = rot.x;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        
            float mouseX = Input.GetAxis("Mouse Y");
            float mouseY = -Input.GetAxis("Mouse X");

            rotY -= mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Vector3 localPosition = new Vector3(-rotX, -rotY, rotZ);
            transform.position = localPosition;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Translate(Vector3.forward * testMove * Time.deltaTime);
            rotZ = transform.position.z;
            rb.AddForce(0f, 0f, 20f);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.back * testMove * Time.deltaTime);
            rotZ = transform.position.z;
        }
    }
}