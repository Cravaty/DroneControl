using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneController : MonoBehaviour
{
    Rigidbody rigidbody;
    float up_down_axis, forward_backward_axis, right_left_axis;
    float forward_backward_angel = 0, right_left_angel = 0, Rot = 0;
    [SerializeField]
    float speed = 1.3f, angel = 25, speedRot = 100;

    private void Start()
    {
        rigidbody= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Controls();
        
        transform.localEulerAngles = Vector3.back * right_left_angel + Vector3.right * forward_backward_angel + Vector3.up * Rot;
       

    }

    private void FixedUpdate()
    {
        rigidbody.AddRelativeForce(right_left_axis, up_down_axis, forward_backward_axis);
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            up_down_axis = 10 * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            up_down_axis = 8;
        }
        else
        {
            up_down_axis = 9.81f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, angel, Time.deltaTime);
            forward_backward_axis = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, -angel, Time.deltaTime);
            forward_backward_axis = -speed;
        }
        else
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, 0, Time.deltaTime);
            forward_backward_axis = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            right_left_angel = Mathf.Lerp(right_left_angel, angel, Time.deltaTime);
            right_left_axis = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            right_left_angel = Mathf.Lerp(right_left_angel, -angel, Time.deltaTime);
            right_left_axis = -speed;
        }
        else
        {
            right_left_angel = Mathf.Lerp(right_left_angel, 0, Time.deltaTime);
            right_left_axis = 0;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, angel, Time.deltaTime);
            right_left_angel = Mathf.Lerp(right_left_angel, angel, Time.deltaTime);
            forward_backward_axis = 0.5f * speed;
            right_left_axis = 0.5f * speed;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, angel, Time.deltaTime);
            right_left_angel = Mathf.Lerp(right_left_angel, -angel, Time.deltaTime);
            forward_backward_axis = 0.5f * speed;
            right_left_axis = -0.5f * speed;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, -angel, Time.deltaTime);
            right_left_angel = Mathf.Lerp(right_left_angel, angel, Time.deltaTime);
            forward_backward_axis = -0.5f * speed;
            right_left_axis = 0.5f * speed;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            forward_backward_angel = Mathf.Lerp(forward_backward_angel, -angel, Time.deltaTime);
            right_left_angel = Mathf.Lerp(right_left_angel, -angel, Time.deltaTime);
            forward_backward_axis = -0.5f * speed;
            right_left_axis = -0.5f * speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rot += speedRot * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rot += -speedRot * Time.deltaTime; 
        }

        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("OutdoorsScene");
        }
    }
}
