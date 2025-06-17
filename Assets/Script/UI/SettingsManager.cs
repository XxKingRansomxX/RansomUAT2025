using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Sliders")]
    [SerializeField] private Slider sfxSlider;   // Assign in Inspector
    [SerializeField] private Slider musicSlider; // Assign in Inspector

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;   // Assign your SFX AudioSource (optional)
    [SerializeField] private AudioSource musicSource; // Assign your Music AudioSource (optional)
    [SerializeField] private AudioClip sliderTickClip; // Assign a tick/click sound in Inspector
    [SerializeField] private AudioSource uiAudioSource; // Assign a dedicated AudioSource for UI sounds

    public KeyCode returnToMenuKey = KeyCode.Escape; // Optional: key to return to main menu

    private void Start()
    {
        // Load saved values or set to max by default
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        if (musicSlider != null)
        {
            musicSlider.value = musicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        SetSFXVolume(sfxVolume);
        SetMusicVolume(musicVolume);
    }

    private void Update()
    {
        // Optional: allow returning to main menu with a key
        if (Input.GetKeyDown(returnToMenuKey))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetSFXVolume(float value)
    {
        if (sfxSource != null)
            sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);

        if (uiAudioSource != null && sliderTickClip != null)
            uiAudioSource.PlayOneShot(sliderTickClip);
    }

    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
            musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);

        if (uiAudioSource != null && sliderTickClip != null)
            uiAudioSource.PlayOneShot(sliderTickClip);
    }

    // Call this from your Exit/Back button's OnClick event in the Inspector
    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}