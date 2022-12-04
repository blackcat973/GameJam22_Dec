using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueAfterScoreThree : MonoBehaviour
{
    public MessageAfterThree[] messages;
    [SerializeField] Fire fire;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogueAfterThree(messages);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(fire.score);

        if (collider.gameObject.CompareTag("Player") && fire.score == 3)
        {
            Destroy(this.gameObject);
            StartDialogue();
        }
    }
}

[System.Serializable]
public class MessageAfterThree
{
    public string message;
}