using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        player.transform.position = transform.position;
        player.AssignCoinText();
        player.GetComponent<Animator>().SetTrigger("Reset Animations");
        player.canMove = true;
    }
}
