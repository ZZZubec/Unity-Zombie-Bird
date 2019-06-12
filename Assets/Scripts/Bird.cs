using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public WorldManager worldManager;
    public GameManager gm;

    public Vector2 velocity;
    private float rotation;

    float t = 0.1f;
    SpriteRenderer sprite;
    int current_sprite = 0;
    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        reset();
    }

    public void reset()
    {
        velocity = new Vector2(0, 0);
        rotation = 0;
        transform.localPosition = new Vector3(0, 0, -1);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        current_sprite = 0;
        sprite.sprite = gm.wm.bird_sprites[current_sprite];
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 0.2f)
        {
            t = 0;
            current_sprite++;
            if (current_sprite >= gm.wm.bird_sprites.Length)
                current_sprite = 0;
            sprite.sprite = gm.wm.bird_sprites[current_sprite];
        }

        if (gm.gameState != GameManager.GameState.PAUSE)
        {

            velocity.y -= 0.03f * Time.deltaTime;

            if (velocity.y > 0.15f)
            {
                velocity.y = 0.15f;
            }

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + velocity.y, -1);

            // Повернуть против часовой стрелки
            if (velocity.y < 0)
            {
                rotation -= 100 * Time.deltaTime;
                if (rotation < -45)
                    rotation = -45;
                transform.localEulerAngles = new Vector3(0, 0, rotation);

            }
            else
            {
                rotation = 30;
                transform.localEulerAngles = new Vector3(0, 0, rotation);
            }
        }
    }

    public Boolean isJump()
    {
        return velocity.y > 0f;
    }

    public Boolean shouldntFlap()
    {
        return velocity.y > 70/100;
    }

    public void Jump()
    {
        if(velocity.y < 0f)
            velocity.y = 0.015f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gm.gameState != GameManager.GameState.PAUSE)
        {
            String name = collision.gameObject.name;
            if (name != "pipeTop" && name != "pipeBottom" && name != "skullTop" && name != "skullBottom")
            {
                Debug.Log(name);
                gm.AddCoin();
            }
            else
                gm.Dead();
        }
    }
}
