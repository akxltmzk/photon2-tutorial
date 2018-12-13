using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvartarSetup : MonoBehaviour
{
    private PhotonView pv;
    public int characterValue;
    public GameObject myCharacter;

    public int playerHealth;
    public int playerDamage;

    public Camera myCamera;
    public AudioListener myAL;

	void Start ()
    {
        pv = GetComponent<PhotonView>();
        if(pv.IsMine)
        {
            pv.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.instance.mySelectedCharacter);
        }
        else
        {
            Destroy(myCamera);
            Destroy(myAL);
        }
	}

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        characterValue = whichCharacter;
        myCharacter = Instantiate(PlayerInfo.instance.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }
}
