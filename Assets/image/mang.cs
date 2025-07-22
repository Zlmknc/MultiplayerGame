using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class mang : MonoBehaviour
{
    [SerializeField]  Slider volumeSlider;

    [SerializeField] private Text volumeTextUI = null;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }
        
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }



  
}
