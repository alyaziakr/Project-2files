using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour
{
    private GameObject player;
    public GameObject transpos;

    void Start()
    {
        player = Camera.main.transform.parent.gameObject;
    }

    public void OnPointerClick()
    {
        // move the player to its position
        // speed depends on the distance between player and the spot
        float distance = Vector3.Distance(transform.position, player.transform.position);
        LeanTween.move(player, transpos.transform.position, distance / 2f);
        
    }
}