using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float force;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && other.gameObject != player){
            other.GetComponent<PlayerMovement>().TakeDamage(player.transform.position, force);
        }
    }
}
