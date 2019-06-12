using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject bird;
    public Sprite[] bird_sprites;
    public Pipe[] pipes;

    public float skull_height = 0.1394f;
    public float skull_m = 0.3f;
    public float pipeMaxScale = 35f;
    public float scull_maxPos = 1.073f;
}
