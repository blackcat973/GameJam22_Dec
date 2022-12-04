using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] Fire fire;

    public string InteractionPrompt => _prompt;

    public int levelNum;

    public bool IsPickable()
    {
        return false;
    }

    public bool IsHouse()
    {
        return false;
    }

    public void Pick(Transform objectGrabPointTransform)
    {
        return;
    }

    public bool Interact(Interactor interactor)
    {
        if (fire.score == 3)
        {
            Debug.Log("Sleeping");
            levelNum += 1;
            Debug.Log(levelNum);
            LoadNextLevel(levelNum);
        }
        return true;
    }

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
}
