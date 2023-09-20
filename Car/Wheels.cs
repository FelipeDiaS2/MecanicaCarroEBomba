using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wCollider;
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float torque, friction, brake, angle;

    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < wheels.Length; i++)
        {
            wCollider[i].ConfigureVehicleSubsteps(1, 12, 15);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < wCollider.Length; i++) {

            wCollider[i].motorTorque = Input.GetAxis("Vertical") * torque;
            wCollider[i].brakeTorque = (Input.GetKey(KeyCode.Space)) ? brake : friction - Mathf.Abs(Input.GetAxis("Vertical") * friction);

            if (i < 2) { wCollider[i].steerAngle = Mathf.Lerp(wCollider[i].steerAngle, angle * Input.GetAxis("Horizontal"), Time.deltaTime); }

        }

    }

    void Drive()
    {
        for (int i = 0; i < wCollider.Length; i++)
        {
            wCollider[i].GetWorldPose(out position, out rotation);
            wheels[i].position = position;
            wheels[i].rotation = rotation;
        }
    }
}
