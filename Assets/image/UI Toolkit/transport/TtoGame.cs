using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;


public class TtoGame : MonoBehaviour
{
    private UIDocument _doc;

    private Button _quitB;
    private Button _previousB;

    private Button _toGame1;
    private Button _toGame2;
    private Button _toSw;


    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _quitB = _doc.rootVisualElement.Q<Button>("q1");
        _quitB.clicked += QuitButtonOn;

        _previousB = _doc.rootVisualElement.Q<Button>("prev1");
        _previousB.clicked += PreviousButton;


        _toGame1 = _doc.rootVisualElement.Q<Button>("toG1");
        _toGame1.clicked += Goto1;

        _toGame2 = _doc.rootVisualElement.Q<Button>("toG2");
        _toGame2.clicked += Goto2;

        _toSw = _doc.rootVisualElement.Q<Button>("toSw");
        _toSw.clicked += Goto2;

    }
    private void QuitButtonOn()
    {
        Application.Quit();
    }

    private void PreviousButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Goto1()
    {
        SceneManager.LoadScene("Game1");
    }
    private void Goto2()
    {
        SceneManager.LoadScene("Game2");
    }

 }
