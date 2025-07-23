using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class G2 : MonoBehaviour
{
    private UIDocument _doc;

    private Button _quitButton;
    private Button _pButton;
    private Button _restartButton;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _quitButton = _doc.rootVisualElement.Q<Button>("qButton");
        _quitButton.clicked += QuitButtonOnClicked;

        _pButton = _doc.rootVisualElement.Q<Button>("pButton");
        _pButton.clicked += PreviousButton;

        _restartButton = _doc.rootVisualElement.Q<Button>("RestartButton");
        _restartButton.clicked += RestartButton;
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
        SceneManager.LoadScene("Game2");
    }
}
