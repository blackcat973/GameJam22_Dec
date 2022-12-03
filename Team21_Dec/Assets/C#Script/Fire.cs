using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
        }
    }
}
