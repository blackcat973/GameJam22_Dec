using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    MessageAfterThree[] currentMessagesAfterThree;
    int activeMessages = 0;
    public static bool isActive = false;
    public static bool isAfterThree = false;

    // Start is called before the first frame update

    public void OpenDialogue(Message[] messages)
    {
        currentMessages = messages;
        activeMessages = 0;
        isActive = true;
        isAfterThree = false;

        Debug.Log("Started conversation" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        //backgroundBox.transform.localScale = Vector3.one;
    }

    public void OpenDialogueAfterThree(MessageAfterThree[] messages)
    {
        currentMessagesAfterThree = messages;
        activeMessages = 0;
        isActive = true;
        isAfterThree = true;

        Debug.Log("Started conversation" + messages.Length);
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        DisplayMessage();
    }

    void DisplayMessage()
    {
        if (!isAfterThree)
        {
            Message messageToDisplay = currentMessages[activeMessages];
            messageText.text = messageToDisplay.message;
        }
        else
        {
            MessageAfterThree messageToDisplay = currentMessagesAfterThree[activeMessages];
            messageText.text = messageToDisplay.message;
        }
    }

    public void NextMessage()
    {
        activeMessages++;
        if (!isAfterThree)
        {
            if (activeMessages < currentMessages.Length)
            {
                DisplayMessage();
            }
            else
            {
                Debug.Log("Conversation ended!");
                backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                isActive = false;
            }
        }
        else
        {
            if (activeMessages < currentMessagesAfterThree.Length)
            {
                DisplayMessage();
            }
            else
            {
                Debug.Log("Conversation ended!");
                //gameObject.SetActive(false);
                backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                //backgroundBox.transform.localScale = Vector3.zero;
                isActive = false;
            }
        }
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isActive == true)
        {
            NextMessage();
        }
    }
}
