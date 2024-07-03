using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class DroneFpvMovement : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField] private float m_pich;
    [SerializeField] private float m_roll;
    [SerializeField] private float m_yaw;
    [SerializeField] private float m_thrusterSpeed;


    //[SerializeField] private float m_forwardSpeed;
    //[SerializeField] private float m_rotateSpeed;
    //[SerializeField] private float m_upSpeed;

    //[SerializeField] private GameObject m_forcezone;
    // Start is called before the first frame update

    private bool m_goForward = false;
    private bool m_goBackward = false;
    private bool m_goLeft = false;
    private bool m_goRight = false;
    private bool m_goUp = false;
    private bool m_goDown = false;
    private bool m_goreset = false;


    private float m_axisValueForward = 0;
    private float m_axisValueRight = 0;
    private float m_axisValueRotate = 0;
    private float m_axisValueUp = 0;

    public void QuadReset()
    {
        transform.position += new Vector3(0, 5, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
        m_axisValueForward = 0;
        m_axisValueRight = 0;
        m_axisValueRotate = 0;
        m_axisValueUp = 0;
    }

    public void ForwardANDBackward(float _value)
    {
        m_axisValueForward = _value;
    }

    public void LeftANDRight(float _value)
    {
        m_axisValueRight = _value;
    }

    public void RotateAxis(float _value)
    {
        m_axisValueRotate = _value;
    }

    public void UpANDDown(float _value)
    {
        m_axisValueUp = _value;
    }

    private void Update()
    {

        transform.Rotate(Vector3.right * Time.deltaTime * m_pich * m_axisValueForward); //pitch

        transform.Rotate(Vector3.forward * Time.deltaTime * m_roll * m_axisValueRight * -1); //roll

        transform.Rotate(Vector3.up * Time.deltaTime * m_yaw * m_axisValueRotate); //yaw


        if (m_axisValueUp > 0)
        {
            rb.AddForce(transform.up * m_thrusterSpeed * m_axisValueUp); //thruster
        }



        print("Pitch : " + m_axisValueForward + ", Roll : " + m_axisValueRight + ", Yaw : " + m_axisValueRotate);
    }
}
