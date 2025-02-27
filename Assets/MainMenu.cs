using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        player.canMove = false;
    }

    // Update is called once per frame
    public void PlayGame()
    {
        player.canMove = true;
        Destroy(gameObject);
    }
}
