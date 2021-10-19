using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioSlider : MonoBehaviour
{
    public bool volumeToPercentage = false;
    public string audioMixerParameter;
    public AudioMixer audioMixer;
    private void Start()
    {
        audioMixer.GetFloat(audioMixerParameter, out float f);
        if (volumeToPercentage) f = Mathf.Pow(10, f / 20);
        GetComponent<Slider>().value = f;
        GetComponent<Slider>().onValueChanged.AddListener(ChangeValue);
    }
    public void ChangeValue(float value)
    {
        if (volumeToPercentage)
        {
            if (value != 0) value = Mathf.Log(value) * 20;
            else value = -80;
        }
        audioMixer.SetFloat(audioMixerParameter, value);
    }
}
