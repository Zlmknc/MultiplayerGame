using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UIElements;

public class Player2 : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnUsernameChanged))] private string playerName;

    void Start()
    {
        if (isLocalPlayer)
        {
            // Kullan�c� ad�
            string playerName = PlayerPrefs.GetString("PlayerName", "VarsayilanKendiIsim");
            CmdSetPlayerName(playerName);
        }
    }

    [Command]
    private void CmdSetPlayerName(string newName)
    {
        this.playerName = newName;

    }

    // Kullan�c� ad� de�i�ti�inde istemciyi g�ncelle
    private void OnUsernameChanged(string oldUsername, string newUsername)
    {
        G1 game = FindObjectOfType<G1>();
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

    private void RpcUpdatePlayer1Score(int score)
    {
        G1 game = FindObjectOfType<G1>();
        if (isLocalPlayer)
        {
            game.UpdateSkor(score.ToString()); // Player 1 skoru Player 1 yerine yaz�lacak
        }
        else
        {
            game.UpdateSkor2(score.ToString()); // Player 1 skoru Player 2 yerine yaz�lacak
        }
    }
    [ClientRpc]
    private void RpcUpdatePlayer2Score(int score)
    {
        G1 game = FindObjectOfType<G1>();
        if (isLocalPlayer)
        {
            game.UpdateSkor(score.ToString()); // Player 2 skoru Player 1 yerine yaz�lacak
        }
        else
        {
            game.UpdateSkor2(score.ToString()); // Player 2 skoru Player 2 yerine yaz�lacak
        }
    }
}
