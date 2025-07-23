using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControl : MonoBehaviour
{

    [Header("Mute Button")]
    [SerializeField]
    private Sprite _mutedSprite;
    [SerializeField]
    private Sprite _unmutedSprite;
    private bool _muted;


    private UIDocument _doc;

    private Button _playButton;
    private Button _settingsButton;
    private Button _quitButton;
    private Button _muteButton;



    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _playButton = _doc.rootVisualElement.Q<Button>("StartButton");
        _playButton.clicked += PlayButtonOnClicked;

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
        _settingsButton.clicked += SettingsButtonOnClicked;

        _quitButton = _doc.rootVisualElement.Q<Button>("QuitButton");
        _quitButton.clicked += QuitButtonOnClicked;

        _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
        _muteButton.clicked += MuteButtonClicked;
    }

    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("OyunGecisi");
    }

    private void SettingsButtonOnClicked()
    {
        SceneManager.LoadScene("Settings");
    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    private void MuteButtonClicked()
    {
        _muted = !_muted;
        var bg = _muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(_muted ? _mutedSprite : _unmutedSprite);
        _muteButton.style.backgroundImage = bg;

        AudioListener.volume = _muted ? 0 : 1;
    }

}
