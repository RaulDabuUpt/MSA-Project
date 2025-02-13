using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogRotation : MonoBehaviour
{
    [System.Serializable]
    private class RotationElement
    {
        public float Speed;
        public float Duration;
    }

    [SerializeField]
    private RotationElement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("PlayRotationPattern");
    }

    private IEnumerator PlayRotationPattern()
    {

        for (int i = 0; i < rotationPattern.Length; i++)
        {
            rotationPattern[i].Speed = Random.Range(-250, 350);
            rotationPattern[i].Duration = Random.Range(1, 3);
        }



        int rotationIndex = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();

            motor.motorSpeed = rotationPattern[rotationIndex].Speed;
            motor.maxMotorTorque = 10000;
            wheelJoint.motor = motor;

            yield return new WaitForSecondsRealtime(rotationPattern[rotationIndex].Duration);
            rotationIndex++;
            rotationIndex = rotationIndex < rotationPattern.Length ? rotationIndex : 0;
        }
    }
}
