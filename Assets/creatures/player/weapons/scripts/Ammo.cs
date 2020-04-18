using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int speed;
    public Firearm gun;
    public string enemytag;

    Vector3 movementDirection;

    private void Start()
    {
        movementDirection = gun.transform.forward;
    }
    private void Update()
    {
        Movement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enemytag){
            other.GetComponent<Enemy>().getDamage(gun);
            Destroy(gameObject);
        }
    }
    void Movement()
    {
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
