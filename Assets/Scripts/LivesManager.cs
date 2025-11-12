using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GameManager.lives.ToString();
    }
}
