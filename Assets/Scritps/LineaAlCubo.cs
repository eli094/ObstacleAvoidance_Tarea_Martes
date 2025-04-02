using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaAlCubo : MonoBehaviour
{
    public Transform x;
    public float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0.65f, 0, 1);
        //Gizmos.DrawLine(Vector3.zero, transform.position.normalized * Mathf.Min(transform.position.magnitude, 3));
        Gizmos.DrawLine(Vector3.zero, Vector3.ClampMagnitude(transform.position, 3));

        //Debug.Log(Vector3.Distance(x.position, transform.position));

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        //Debug.Log(Vector3.Distance(x.position, transform.position) <= radius);
    }
}
