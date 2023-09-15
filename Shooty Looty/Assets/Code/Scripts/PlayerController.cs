using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameObject bullet;
    public float cooldownTime = 1f;
    
    private Rigidbody _rb;
    private Transform _gun;
    
    private float _movementX; 
    private float _movementY;
    private bool _isCoolingDown = false;
    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        _gun = transform.Find("Gun");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void OnLook(InputValue turnValue)
    {
        Vector2 turnFloat = turnValue.Get<Vector2>();
        transform.Rotate(0.0f, turnFloat.x * 10, 0.0f);
    }
    
    private void OnFire(InputValue fireValue)
    {
        Debug.Log("Fire!");
        // if (!_isCoolingDown)
        // {
            var newBullet = Instantiate(bullet, _gun.position, _gun.rotation);
            newBullet.GetComponent<Bullet>().playerController = this;
            // _isCoolingDown = true;
            // Invoke(nameof(ResetCooldown), cooldownTime);
        // }
    }
    
    private void ResetCooldown()
    {
        _isCoolingDown = false;
    }
    
    public void AddScore(int score)
    {
        Debug.Log("Score: " + score);
    }
}
