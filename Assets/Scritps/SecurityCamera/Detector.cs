using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Transform target;
    public Transform securityCamera;
    public GameObject alertImage;
    public float detectionRange;
    public float detectionAngle;
    public LayerMask obstaclesMask;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Is in distance: " + CheckDistance(target) + ", Is in angle: " + CheckAngle(target) + ", Is visible: " + CheckView(target)); 
        }
        alertImage.SetActive(target && CheckDistance(target) && CheckAngle(target) && CheckView(target));
    }

    public bool CheckDistance(Transform target)
    {
        float distance = Vector3.Distance(target.position, securityCamera.position);
        return distance <= detectionRange;
    }

    public bool CheckAngle(Transform target)
    {
        //Dirección hacia un objetivo

        //A = Origin
        //B = Target
        //Direccion = Target - Origin
        //B - A

        Vector3 dir = target.position - securityCamera.position;
        float angle = Vector3.Angle(securityCamera.forward, dir);
        return angle <= detectionAngle / 2;
    }

    public bool CheckView(Transform target)
    {
        Vector3 dir = target.position - securityCamera.position;

        return !Physics.Raycast(securityCamera.position, dir.normalized, dir.magnitude, obstaclesMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(securityCamera.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(securityCamera.position, Quaternion.Euler(0, detectionAngle / 2, 0) * securityCamera.forward * detectionRange);
        Gizmos.DrawRay(securityCamera.position, Quaternion.Euler(0, -detectionAngle / 2, 0) * securityCamera.forward * detectionRange);

    }
}
