using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        PAUSE, GAME
    }

    public WorldManager wm;
    public GameState gameState;
    public Bird bird;

    public Text score;

    private int coin;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.PAUSE;
        bird = wm.bird.GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.PAUSE)
        {
            if (Input.GetMouseButtonDown(0))
            {
                reset();
                bird.Jump();
                ChangeGameMode(GameState.GAME);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                bird.Jump();
        }
    }

    public void reset()
    {
        foreach (Pipe pipe in wm.pipes)
            pipe.reset();
        bird.reset();
        coin = 0;
        score.text = "0";
    }

    private void ChangeGameMode(GameState gs)
    {
        if(gs != gameState)
        {
            this.gameState = gs;
        }
    }

    public void AddCoin()
    {
        if (gameState != GameState.PAUSE)
        {
            Debug.Log("add coin");
            coin++;
            score.text = coin.ToString();
        }
    }

    public void Dead()
    {
        ChangeGameMode(GameState.PAUSE);
    }
}
