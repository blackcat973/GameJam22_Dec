using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Message[] messages;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            StartDialogue();
        }
    }
}

[System.Serializable]
public class Message
{
    public string message;
}