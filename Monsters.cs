using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monsters : MonoBehaviour
{

    public int MaxHealth;
    public Sprite[] Sprites;

    private int Health;

    private const float SPEED = 30;


    private void FixedUpdate()
    {

        float distance = Vector2.Distance(Player.PlayerObject.transform.position, transform.position);

        if(distance <= 80)

        {

            float angle = Random.Range(-1.5f, 1.5f) + Mathf.Atan2(Player.PlayerObject.transform.position.y - transform.position.y, Player.PlayerObject.transform.position.x - transform.position.x);

            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * SPEED;

        }
        else
        {

            float angle = Random.Range(0, Mathf.PI * 2f);

            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * SPEED;
        }
    }

    public void Damage(int dmg)

    {

        Health -= dmg;

        if ( Health <= 0)
        {
            gameObject.SetActive(false);

        }

        else
        {

            GetComponent<SpriteRenderer>().sprite = Sprites[Health - 1];
        }
    }


    private void OnCollisionEnter2D ( Collision2D other)
    {

        if (other.gameObject.CompareTag("PlayerWizard")) SceneManager.LoadScene("Level1");
    }
}
