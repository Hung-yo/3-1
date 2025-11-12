using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI volumeText;
    public UnityEngine.UI.Slider volumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnVolumeSliderChanged(float value)
    {
        volumeText.text = Mathf.RoundToInt(value * 100).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Get slider value
        volumeText.text = Mathf.RoundToInt(volumeSlider.value).ToString();
    }
}
