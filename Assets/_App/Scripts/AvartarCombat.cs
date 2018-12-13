using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvartarCombat : MonoBehaviour {

    private PhotonView pv;
    private AvartarSetup avartarSetup;
    public Transform rayOrigin;

	void Start ()
    {
        pv = GetComponent<PhotonView>();
        avartarSetup = GetComponent<AvartarSetup>();
	}
	
	void Update ()
    {
        if(!pv.IsMine)
        {
            return;
        }

	    if(Input.GetMouseButtonDown(0))
        {
            pv.RPC("RPC_Shooting",RpcTarget.All);
      
        }
	}
    [PunRPC]
    void RPC_Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.transform.position,
                rayOrigin.transform.TransformDirection(Vector3.forward),
                out hit,
                Mathf.Infinity,
                1000))
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did HIT!!");
            if (hit.transform.tag == "Avartar")
            {
                hit.transform.gameObject.GetComponent<AvartarSetup>().playerHealth -= avartarSetup.playerDamage;
            }
        }
        else
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not HIT!!");
        }
    }
}
