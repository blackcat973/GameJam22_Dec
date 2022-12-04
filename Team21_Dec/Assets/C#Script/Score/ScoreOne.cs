using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOne : MonoBehaviour
{
    [SerializeField] private Fire fire;
    [SerializeField] private Image WoodScoreCircle;

    // Start is called before the first frame update
    void Start()
    {
        //WoodScoreCircle = GetComponent<Image>();
        fire = FindObjectOfType<Fire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.score >= 1)
        {
            Debug.Log("Fire Work");
            WoodScoreCircle.color = Color.green;
        }
    }
}
