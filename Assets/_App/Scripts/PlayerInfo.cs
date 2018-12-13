using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public int mySelectedCharacter;
    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if(PlayerInfo.instance == null)
        {
            PlayerInfo.instance = this;
        }
        else
        {
            if(PlayerInfo.instance != this)
            {
                Destroy(PlayerInfo.instance.gameObject);
                PlayerInfo.instance = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start ()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
	}
	

}
