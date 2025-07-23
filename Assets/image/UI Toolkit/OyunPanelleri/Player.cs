using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerGiris : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnPlayerNameChanged))] private string playerName;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Player"), true);

        if (isLocalPlayer)
        {
            // Kullanýcý adý
            string playerName = PlayerPrefs.GetString("PlayerName", "VarsayilanKendiIsim");
            CmdSetPlayerName(playerName);
        }
       
    }

    [Command]
    private void CmdSetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    private void OnPlayerNameChanged(string oldname,string newUsername)
    {
        NewBehaviourScript game = FindObjectOfType<NewBehaviourScript>();
        if (game != null)
        {
            if (isLocalPlayer)
            {
                game.UpdateName(newUsername);
            }
            else
            {
                game.UpdateName2(newUsername);
            }
        }
    }
}

