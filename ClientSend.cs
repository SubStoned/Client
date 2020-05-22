using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{

    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement()
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(GameManager.players[Client.instance.myId].transform.position);
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);
            Debug.Log("dela");
            SendUDPData(_packet);
        }

    }



    public static void SphereMovement2(Vector3 _spherePosition, Quaternion _sphereRotation)
    {
        using (Packet _packet = new Packet((int)ClientPackets.sphereMovement2))
        {
            _packet.Write(_spherePosition);
            _packet.Write(_sphereRotation);
            Debug.Log("Sending");
            SendUDPData(_packet);
        }

        #endregion
    }
}