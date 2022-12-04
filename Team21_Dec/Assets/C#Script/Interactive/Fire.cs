using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int score;
    public AudioSource dropSound;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wood"))
        {
            dropSound.Play();
            Destroy(collision.gameObject);
            Debug.Log("Fire worked");
            score += 1;
            

        }
    }
}
