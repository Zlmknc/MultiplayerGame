using Org.BouncyCastle.Crypto.Paddings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    private UIDocument _doc;

    public Label timerLabel; // UI Toolkit Label elementi
    private float remainingTime = 11f; // 15 saniye ile baþlayýn
    private float lastUpdateTime = 0f; // Son zaman güncelleme zamaný

    // DÝSPLAY GÖRÜNÜRLÜKKKKKK 
    private GroupBox groupBox;

    // Yýldýz sayýsýný tutacak
    public int starCount;
    private Label starCounter;

    //sayýlacak yýldýzlar bu butonlarda bulunan yýldýzlardýr
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
        // Yýldýz sayýsýný PlayerPrefs'ten yüklüyoruz
        starCount = PlayerPrefs.GetInt("KazandiginizYildizSayisi", 0);

        UpdateStarCountText(); // Baþlangýçta yýldýz sayýsýný güncelle

        lastUpdateTime = Time.time;

        groupBox.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (remainingTime >= 1)
        {
            // Zamaný sýfýrýn altýna düþürmemek için kontrol et
            remainingTime -= Time.deltaTime;

            // Dakika ve saniyeleri hesapla
            var seconds = Mathf.FloorToInt(remainingTime);

            // Zamanlayýcý metnini güncelle
            timerLabel.text = seconds.ToString();

            // Son zaman güncellemeyi güncelle
            lastUpdateTime = Time.time;

            groupBox.style.display = DisplayStyle.None;
        }
        else if (remainingTime < 1)
        {
            // Labeli görünür yap
            groupBox.style.display = DisplayStyle.Flex;
        }
    }

 // Yýldýzlarýn olduðu butonlara basýlýnca ekleme yaapan
 // ve eklemeleri update eden fonksiyonlar
    public void AddOneStars()
    {
        starCount += 1;
        UpdateStarCountText(); // Yýldýz sayýsýný güncelle
    }
    public void AddTwoStars()
    {
        starCount += 2; // Yýldýz sayýsýný 2 artýr
        UpdateStarCountText(); // Yýldýz sayýsýný güncelle
    }

    void UpdateStarCountText()
    {
        starCounter.text = "Stars: " + starCount; // Yýldýz sayýsýný ekranda göster

        PlayerPrefs.SetInt("KazandiginizYildizSayisi", starCount);// Yýldýz sayýsýný PlayerPrefs ile sakla
    }

// Zamanlayýcýyý durdurmak için bu fonksiyonu çaðýrýn
    public void RestartCountdown()
    {
        starCount = 0;
        // Zamanlayýcýyý 15 saniyeye sýfýrla ve baþlat
        remainingTime = 11f;
        timerLabel.text = remainingTime.ToString();
        // Zamanlayýcýyý güncellemeyi baþlat
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
