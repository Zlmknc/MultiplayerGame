using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Names : MonoBehaviour
{
    private UIDocument _doc;
    private Label Kendi;
    private Label Rakip;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        Kendi = _doc.rootVisualElement.Q<Label>("Player1");
        Rakip = _doc.rootVisualElement.Q<Label>("Player2");
    }

    private void Start()
    {
        // Kendi ismini PlayerPrefs'ten �ekin
        string kendiIsim = PlayerPrefs.GetString("PlayerName", "VarsayilanKendiIsim");

        // Rakibin ismini PlayerPrefs'ten �ekin (Bu k�sm� uygun �ekilde g�ncellemelisiniz)
        string rakipIsim = PlayerPrefs.GetString("RakipIsim", "VarsayilanRakipIsim");

        // Label ��elerine isimleri yazd�r�n
        Kendi.text = kendiIsim;
        Rakip.text = rakipIsim;
    }

    // Bu metodla rakip ismini g�ncelleyebilirsiniz
    public void SetRakipIsim(string isim)
    {
        Rakip.text = isim;
    }
}
