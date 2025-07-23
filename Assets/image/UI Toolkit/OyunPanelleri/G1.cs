using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class G1 : MonoBehaviour
{
    private UIDocument _doc;

    private Button _quitButton;
    private Button _pButton;
    private Button _restartButton;
    private Label Kendi;
    private Label o1;
    private Label o2;
    private Label _label3;
    private Label _label4;


    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _quitButton = _doc.rootVisualElement.Q<Button>("qButton");
        _quitButton.clicked += QuitButtonOnClicked;

        _pButton = _doc.rootVisualElement.Q<Button>("pButton");
        _pButton.clicked += PreviousButton;

        _restartButton = _doc.rootVisualElement.Q<Button>("RestartButton");
        _restartButton.clicked += RestartButton;

        Kendi = _doc.rootVisualElement.Q<Label>("Player1");
        o1 = _doc.rootVisualElement.Q<Label>("player1");
        o2 = _doc.rootVisualElement.Q<Label>("player2");

        _label3 = _doc.rootVisualElement.Q<Label>("player1Skor");
        _label4 = _doc.rootVisualElement.Q<Label>("player2Skor");
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string PlayerName = PlayerPrefs.GetString("PlayerName", "KendiIsim");
            Kendi.text = PlayerName;
        }
        string playerName = PlayerPrefs.GetString("PlayerName", "KendiIsim");
        o1.text = playerName;
    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    private void PreviousButton()
    {
        SceneManager.LoadScene("OyunGecisi");
    }

    private void RestartButton()
    {
        SceneManager.LoadScene("Game1");
    }

    public void UpdateName(string name)
    {
        o1.text = name;
    }
    public void UpdateName2(string name2)
    {
        o2.text = name2;
    }
    public void UpdateSkor(string skor)
    {
        _label3.text = skor;
    }

    public void UpdateSkor2(string skor)
    {
        _label4.text = skor;
    }
}
