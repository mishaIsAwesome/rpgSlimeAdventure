using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    private float chestCount = 0;
    private float healthCount;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI chestText;
    public TextMeshProUGUI winText;
    Color winStartingColor;
    public DamageableCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        winStartingColor = winText.color;
        chestText.text = chestCount.ToString();
        healthCount = player.Health;
        healthText.text = healthCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (chestCount >= 5)
        {
            winText.color = new Color(winStartingColor.r, winStartingColor.g, winStartingColor.b, 1);
            player.Targetable = false;
        }
        if (player.Health <= 0)
        {
            winText.text = "You Lose!";
            winText.color = new Color(winStartingColor.r, winStartingColor.g, winStartingColor.b, 1);
        }
    }

    public void OnAddCount()
    {
        chestCount += 1;
        chestText.text = chestCount.ToString();
    }

    public void SetHealth(float healthNum)
    {
        healthText.text = healthNum.ToString();
    }
    
    public void OnMinusHealth()
    {
        healthCount -= 1;
        healthText.text = healthCount.ToString();
    }
}
