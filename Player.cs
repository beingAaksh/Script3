using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player PlayerObject;
   private const float PLAYER_SPEED = 20;

    private const float SPELL_MAX_COOLDOWN = 0.2f;
    private float SpellCoolDown;
    private bool Alive = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {

            if (SpellCoolDown > 0) SpellCoolDown -= Time.deltaTime;

            if (SpellCoolDown <= 0)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    SpellCoolDown = SPELL_MAX_COOLDOWN;
                    GameObject projectile = Instantiate(Resources.Load("Spell")) as GameObject;

                    projectile.transform.position = transform.position;
                    projectile.GetComponent<Projectile>().Speed = 100;
                    projectile.GetComponent<Projectile>().Angle = Mathf.Atan2(Input.mousePosition.y - Screen.height / 2f, Input.mousePosition.x - Screen.width / 2f);
                }
            }
        }
    }

    private void FixedUpdate()
    {

        //moving controls

        if(Alive)
        {
            float moveX = 0;
            float moveY = 0;

            if (Input.GetKey(KeyCode.D)) moveX += 1;
            if (Input.GetKey(KeyCode.A)) moveX -= 1;
            if (Input.GetKey(KeyCode.W)) moveY += 1;
            if (Input.GetKey(KeyCode.S)) moveY -= 1;

            Vector2 newVelocity = new Vector2(moveX, moveY).normalized * PLAYER_SPEED;

            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
    }
}
