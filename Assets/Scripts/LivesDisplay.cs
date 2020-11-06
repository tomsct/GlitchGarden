using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 5;

    private Text LivesText { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        LivesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives--;
        if (lives <= 0)
            FindObjectOfType<LevelLoader>().LoadNextScene();
        UpdateDisplay();
    }
}
