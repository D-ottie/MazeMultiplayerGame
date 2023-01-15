using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
//using Unity.Netcode.NetworkVariable;
using UnityEngine;
using UnityEngine.UI;
using DilmerGames.Core.Singletons;

[System.Serializable]
public class UIManager : NetworkBehaviour
{
    [SerializeField]
    private Button hostButton;

    [SerializeField]
    private Button clientButton;
    
    [SerializeField]
    private TextMeshProUGUI playerCountText;

    private NetworkVariable<int>playersNum = new NetworkVariable<int>(0,NetworkVariableReadPermission.Everyone);



    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    private void Update()
    {
        playerCountText.text = "PLAYERS JOINED: " + playersNum.Value.ToString();
        if(!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;

    }
    
}