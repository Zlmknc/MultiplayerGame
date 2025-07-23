using Org.BouncyCastle.Crypto.Paddings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    private UIDocument _doc;

    public Label timerLabel; // UI Toolkit Label elementi
    private float remainingTime = 11f; // 15 saniye ile ba�lay�n
    private float lastUpdateTime = 0f; // Son zaman g�ncelleme zaman�

    // D�SPLAY G�R�N�RL�KKKKKK 
    private GroupBox groupBox;

    // Y�ld�z say�s�n� tutacak
    public int starCount;
    private Label starCounter;

    //say�lacak y�ld�zlar bu butonlarda bulunan y�ld�zlard�r
    private Button b1y;
    private Button b2y;

    
    private Button GButton;
    private Button Q1Button;
    private Button CloseButton;
    public Button restartButton;

    private int zero = 0;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        timerLabel = _doc.rootVisualElement.Q<Label>("timeLabel");


        groupBox = _doc.rootVisualElement.Q<GroupBox>("ekran2");


        starCounter = _doc.rootVisualElement.Q<Label>("counter");


        b1y = _doc.rootVisualElement.Q<Button>("b1y");
        b1y.clicked += AddOneStars;
        b2y = _doc.rootVisualElement.Q<Button>("b2y");
        b2y.clicked += AddTwoStars;

        restartButton = _doc.rootVisualElement.Q<Button>("RestartButton");
        restartButton.clicked += RestartCountdown;
        Q1Button = _doc.rootVisualElement.Q<Button>("quitoyun");
        Q1Button.clicked += QuitButtonOnClicked;
        CloseButton = _doc.rootVisualElement.Q<Button>("kapat");
        CloseButton.clicked += sekmeKapama;
        GButton = _doc.rootVisualElement.Q<Button>("gecis");
        GButton.clicked += Gecis;
    }

    private void Start()
    {
        // Y�ld�z say�s�n� PlayerPrefs'ten y�kl�yoruz
        starCount = PlayerPrefs.GetInt("KazandiginizYildizSayisi", 0);

        UpdateStarCountText(); // Ba�lang��ta y�ld�z say�s�n� g�ncelle

        lastUpdateTime = Time.time;

        groupBox.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (remainingTime >= 1)
        {
            // Zaman� s�f�r�n alt�na d���rmemek i�in kontrol et
            remainingTime -= Time.deltaTime;

            // Dakika ve saniyeleri hesapla
            var seconds = Mathf.FloorToInt(remainingTime);

            // Zamanlay�c� metnini g�ncelle
            timerLabel.text = seconds.ToString();

            // Son zaman g�ncellemeyi g�ncelle
            lastUpdateTime = Time.time;

            groupBox.style.display = DisplayStyle.None;
        }
        else if (remainingTime < 1)
        {
            // Labeli g�r�n�r yap
            groupBox.style.display = DisplayStyle.Flex;
        }
    }

 // Y�ld�zlar�n oldu�u butonlara bas�l�nca ekleme yaapan
 // ve eklemeleri update eden fonksiyonlar
    public void AddOneStars()
    {
        starCount += 1;
        UpdateStarCountText(); // Y�ld�z say�s�n� g�ncelle
    }
    public void AddTwoStars()
    {
        starCount += 2; // Y�ld�z say�s�n� 2 art�r
        UpdateStarCountText(); // Y�ld�z say�s�n� g�ncelle
    }

    void UpdateStarCountText()
    {
        starCounter.text = "Stars: " + starCount; // Y�ld�z say�s�n� ekranda g�ster

        PlayerPrefs.SetInt("KazandiginizYildizSayisi", starCount);// Y�ld�z say�s�n� PlayerPrefs ile sakla
    }

// Zamanlay�c�y� durdurmak i�in bu fonksiyonu �a��r�n
    public void RestartCountdown()
    {
        starCount = 0;
        // Zamanlay�c�y� 15 saniyeye s�f�rla ve ba�lat
        remainingTime = 11f;
        timerLabel.text = remainingTime.ToString();
        // Zamanlay�c�y� g�ncellemeyi ba�lat
        lastUpdateTime = Time.time;

        //groupBox'i gizle
        groupBox.style.display = DisplayStyle.None;

        zero = PlayerPrefs.GetInt("KazandiginizYildizSayisi");
    }
    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }
    private void sekmeKapama()
    {
        groupBox.style.display = DisplayStyle.None;
        remainingTime = 11f;
    }
    private void Gecis()
    {
        SceneManager.LoadScene("Game2"); 
    }
}
