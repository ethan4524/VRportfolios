using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{
    public HingeJoint joint;

    public void Update()
    {
        //Debug.Log(joint.limits.min + " " + joint.limits.max);
    }
    public float GetLeverValue()
    {
        return joint.angle;
    }
}
