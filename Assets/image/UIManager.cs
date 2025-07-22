using Mirror;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private UIDocument _doc;
    private Label starCounter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _doc = GetComponent<UIDocument>();
        starCounter = _doc.rootVisualElement.Q<Label>("counter");
    }

    public void UpdateStarCounts(Dictionary<int, int> stars)
    {
        // Burada UI elementlerinizi g�ncelleyebilirsiniz.
        // �rne�in, sadece �u anki oyuncunun y�ld�z say�s�n� g�sterelim:
        int currentPlayerId = NetworkClient.connection.connectionId;
        if (stars.ContainsKey(currentPlayerId))
        {
            starCounter.text = "Stars: " + stars[currentPlayerId];
        }
    }
}

