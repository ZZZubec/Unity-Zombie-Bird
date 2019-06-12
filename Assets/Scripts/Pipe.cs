using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameManager gm;
    public GameObject pipeTop, pipeBottom;
    public GameObject skullTop, skullBottom;

    public float height;

    
    void Start()
    {
        reset();
    }

    public void reset()
    {
        //gameObject.SetActive(false);
        transform.localPosition = new Vector3(2f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.PAUSE)
        {
            pipeTop.transform.localScale = new Vector3(1, gm.wm.pipeMaxScale * (1f - height - 0.3f), 1);
            skullTop.transform.localPosition = new Vector3(0, (gm.wm.scull_maxPos - height) - 0.4f, 0);

            pipeBottom.transform.localScale = new Vector3(1, gm.wm.pipeMaxScale * height, 1);
            skullBottom.transform.localPosition = new Vector3(0, height, 0);

            if (transform.localPosition.x > -0.7f)
                transform.localPosition = new Vector3(transform.localPosition.x - 1 * Time.deltaTime, 0, 0);
            else
            {
                reset();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //gm.AddCoin();
    }
}
