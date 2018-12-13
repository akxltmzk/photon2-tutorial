using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSetting : MonoBehaviour
{
    public static MultiplayerSetting instance;

    public bool delayStart;
    public int maxPlayers;

    public int menuScene;
    public int multiplayerScene;

    private void Awake()
    {
        if(MultiplayerSetting.instance==null)
        {
            MultiplayerSetting.instance = this;
        }
        else
        {
            if(MultiplayerSetting.instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}
}
