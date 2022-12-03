using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreThree : MonoBehaviour
{
    Fire fire;
    private Image WoodScoreCircle;

    // Start is called before the first frame update
    void Start()
    {
        WoodScoreCircle = GetComponent<Image>();
        fire = FindObjectOfType<Fire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.score >= 3)
            WoodScoreCircle.color = Color.green;
    }
}
