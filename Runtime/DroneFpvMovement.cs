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

    [SerializeField] private float m_pitch;
    [SerializeField] private float m_roll;
    [SerializeField] private float m_yaw;
    [SerializeField] private float m_thrusterSpeed;


    private float m_axisValuePitch = 0;
    private float m_axisValueRoll = 0;
    private float m_axisValueYaw = 0;
    private float m_axisValueThruster = 0;

    public void DroneReset()
    {
        transform.position += new Vector3(0, 5, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
        m_axisValuePitch = 0;
        m_axisValueRoll = 0;
        m_axisValueYaw = 0;
        m_axisValueThruster = 0;
    }

    public void PitchInputValue(float _value)
    {
        m_axisValuePitch = _value;
    }

    public void RollInputValue(float _value)
    {
        m_axisValueRoll = _value;
    }

    public void YawInputValue(float _value)
    {
        m_axisValueYaw = _value;
    }

    public void ThrusterInputValue(float _value)
    {
        m_axisValueThruster = _value;
    }

    private void Update()
    {

        transform.Rotate(Vector3.right * Time.deltaTime * m_pitch * m_axisValuePitch); //pitch

        transform.Rotate(Vector3.forward * Time.deltaTime * m_roll * m_axisValueRoll * -1); //roll

        transform.Rotate(Vector3.up * Time.deltaTime * m_yaw * m_axisValueYaw); //yaw


        if (m_axisValueThruster > 0)
        {
            rb.AddForce(transform.up * m_thrusterSpeed * m_axisValueThruster); //thruster
        }



        print("Pitch : " + m_axisValuePitch + ", Roll : " + m_axisValueRoll + ", Yaw : " + m_axisValueYaw);
    }
}
