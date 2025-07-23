using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;



public class Yıldızkalp : MonoBehaviour
{

    private UIDocument _doc;

    private Button b1y;
    private Button b2y;
   
    // Yıldız sayısını tutacak
    public int starCount;

    private Label starCounter;



    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        // Diğer buton tanımlamalarınız...
        b1y = _doc.rootVisualElement.Q<Button>("b1y");
        b1y.clicked += AddOneStars;

        b2y = _doc.rootVisualElement.Q<Button>("b2y");
        b2y.clicked += AddTwoStars;

        starCounter = _doc.rootVisualElement.Q<Label>("counter");


    }

    void Start()
    {
        starCount = 0; // Yıldız sayısını sıfırla
        UpdateStarCountText(); // Başlangıçta yıldız sayısını güncelle
    }

    public void AddOneStars()
    {
        starCount += 1;
        UpdateStarCountText(); // Yıldız sayısını güncelle
    }
    public void AddTwoStars()
    {
        starCount += 2; // Yıldız sayısını 2 artır
        UpdateStarCountText(); // Yıldız sayısını güncelle
    }

    void UpdateStarCountText()
    {
        starCounter.text = "Stars: " + starCount; // Yıldız sayısını ekranda göster
    }
}
