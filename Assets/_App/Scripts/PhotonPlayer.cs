using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView pv;
    public GameObject myAvatar;

	void Start ()
    {
        pv = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.instance.spawnPoints.Length);
        if (pv.IsMine)
        {
            myAvatar=PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"),
                GameSetup.instance.spawnPoints[spawnPicker].position,
                GameSetup.instance.spawnPoints[spawnPicker].rotation, 0);

        }
	}
	
	void Update ()
    {
		
	}
}
