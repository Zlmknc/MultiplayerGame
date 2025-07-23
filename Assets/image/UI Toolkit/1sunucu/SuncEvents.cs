using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    private Button _button1;
    private Button CloseButton;
    private GroupBox Giris;
    private TextField playerNameField;
    private Label Kendi;
    private Label Rakip;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q<Button>("PlayButton");
        _button.clicked += PlayGame;

        _button1 = _document.rootVisualElement.Q<Button>("QButton");
        _button1.clicked += QuitButtonOnClicked;

        CloseButton = _document.rootVisualElement.Q<Button>("kapat");
        CloseButton.clicked += sekmeKapama;

        Giris = _document.rootVisualElement.Q<GroupBox>("ilkGelen");
        playerNameField = _document.rootVisualElement.Q<TextField>("playergiris");
        Kendi = _document.rootVisualElement.Q<Label>("Player1");
        Rakip = _document.rootVisualElement.Q<Label>("Player2");
    }

    private void Start()
    {
        Giris.style.display = DisplayStyle.Flex;

        // Ýsim deðiþtiðinde PlayerPrefs'e kaydetme
        playerNameField.RegisterCallback<ChangeEvent<string>>(evt =>
        {
            PlayerPrefs.SetString("PlayerName", evt.newValue);
            PlayerPrefs.Save();
            UpdateLabels();

        });
        UpdateLabels();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    private void sekmeKapama()
    {
        Giris.style.display = DisplayStyle.None;
    }

    private void UpdateLabels()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "VarsayilanKendiIsim");
        Kendi.text = playerName;
    }
    public void UpdateName(string name)
    {
        Kendi.text = name;
    }
    public void UpdateName2(string name2)
    {
        Rakip.text = name2;
    }
}



