using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int stage;
    public Text stageCountText;
    public Text playerCountText;
    public int totalItemCount { get; set; }

    void Awake()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        totalItemCount = items.Length;
        stageCountText.text = "/ " + totalItemCount.ToString();
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }

}