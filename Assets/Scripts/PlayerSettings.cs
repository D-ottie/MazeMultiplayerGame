using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PlayerSettings : NetworkBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerName;

    [SerializeField]
    private NetworkVariable<string> networkPlayerName = new NetworkVariable<string>
        ("PLAYER : 0" , NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    public override void OnNetworkSpawn()
    {
       networkPlayerName.Value = "PLAYER : "+ (OwnerClientId + 1);
       playerName.text = networkPlayerName.Value.ToString();
    }
}
