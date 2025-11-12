using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public GameObject mutedVisual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mutedVisual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ToggleMusic()
    {
        if (GameManager.backgroundMusic.isPlaying)
        {
            GameManager.backgroundMusic.Pause();
            mutedVisual.SetActive(true);
        }
        else
        {
            GameManager.backgroundMusic.Play();
            mutedVisual.SetActive(false);
        }
    }
}
