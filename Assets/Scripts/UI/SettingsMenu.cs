using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider lookSensitivitySlider;
    [SerializeField] private Slider adsSensitivitySlider;
    PlayerStateMachine playerStateMachine;

    void Awake()
    {
        playerStateMachine = GameObject.FindWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    private void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        lookSensitivitySlider.onValueChanged.AddListener(SetLookSensitivity);
        adsSensitivitySlider.onValueChanged.AddListener(SetADSSensitivity);
    }

    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
        lookSensitivitySlider.onValueChanged.RemoveListener(SetLookSensitivity);
        adsSensitivitySlider.onValueChanged.RemoveListener(SetADSSensitivity);
    }

    private void Start()
    {
        audioMixer.GetFloat("master", out float volume);
        volumeSlider.value = Mathf.Pow(10, volume / 20f);
        lookSensitivitySlider.value = playerStateMachine.FreeMouseSensitivity / 100f;
        adsSensitivitySlider.value = playerStateMachine.ADSMouseSensitivity / 100f;
    }

    private void SetVolume(float volume)
    {
        float dbValue = volume > 0 ? Mathf.Log10(volume) * 20f : -80f;
        audioMixer.SetFloat("master", dbValue);
    }

    private void SetLookSensitivity(float lookSensitivity)
    {
       playerStateMachine.FreeMouseSensitivity = lookSensitivity * 100f;
    }

    private void SetADSSensitivity(float adsSensitivity)
    {
        playerStateMachine.ADSMouseSensitivity = adsSensitivity * 100f;
    }
}
