using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway : MonoBehaviour
{
    [SerializeField] private Transform chaser = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 direction = (chaser.position - transform.position).normalized;

        float mag = direction.magnitude; // will be one
        print(mag);

        Gizmos.DrawLine(transform.position, transform.position + direction);
    }
}
