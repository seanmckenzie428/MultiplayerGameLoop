using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerController playerController;
    
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * 1000);
        Invoke(nameof(Despawn), 2);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.AddScore(1);
            playerController.DropCoin();
            Despawn();
        }
    }
    
    private void Despawn()
    {
        Destroy(gameObject);
    }
}
