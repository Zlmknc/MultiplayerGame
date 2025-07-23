using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;


public class SettMng : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private Sprite _mutedSprite;
    [SerializeField]
    private Sprite _unmutedSprite;
    private bool _muted;

    private UIDocument _doc;
 

    private Button _quitB;
    private Button _muteB;
    private Button _previousB;


    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _quitB = _doc.rootVisualElement.Q<Button>("QuitButton");
        _quitB.clicked += QuitButtonOn;


        _muteB = _doc.rootVisualElement.Q<Button>("Sound");
        _muteB.clicked += MuteButtonC;

        _previousB = _doc.rootVisualElement.Q<Button>("Previous");
        _previousB.clicked += PrevButton;
    }

    private void QuitButtonOn()
    {
        Application.Quit();
    }
    private void MuteButtonC()
    {
        _muted = !_muted;
        var bg = _muteB.style.backgroundImage;
        bg.value = Background.FromSprite(_muted ? _mutedSprite : _unmutedSprite);
        _muteB.style.backgroundImage = bg;

        AudioListener.volume = _muted ? 0 : 1;
    }

    private void PrevButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
