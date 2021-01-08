 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed;
    public float Angle;

    private Transform _transform;
     
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }
    private void FixedUpdate()
    {
        Vector3 velocity = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle)) * Speed;
        _transform.position = _transform.position + (velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.tag == "Monster")
        {

            other.GetComponent<Monsters>().Damage(1);
            Destroy(gameObject);
        }

         else if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        } 
         else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
