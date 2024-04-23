using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Move : MonoBehaviour
{
    public Tilemap tile;
    public GameObject spawnParent;
    public SpriteRenderer sprite;
    public Collider2D box;
    public HeartSystem health;
    public SwipeControls swipe;
    float timer = 5;
    float pauseTime = 2;
    float lockTime = 2;
    float countdown = 1;
    float passtime = 4;
    float invintime = 10;
    public AudioSource bg_song;
    public AudioSource invi_song;
    public AudioSource damg_sound;
    Animator anim;
    Transform[] spawns;
    [HideInInspector] public float speed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int spawnPoint;
    [HideInInspector] public bool moving = false;
    [HideInInspector] public bool playing = true;
    [HideInInspector] public bool stunned = false;
    [HideInInspector] public bool passed = false;
    [HideInInspector] public bool damaged = false;
    [HideInInspector] public bool damgstart = false;
    [HideInInspector] public bool invincible = false;
    [HideInInspector] public bool invinstart = false;
    [HideInInspector] public bool locked = false;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        spawns = spawnParent.GetComponentsInChildren<Transform>();
        // Initialize the character's position.
        transform.position = spawns[2].position;
        spawnPoint = 2;
        //speed = .85f;
        speed = 1.85f;
        currentSpeed = speed;
        bg_song.Play();
    }

    private void Update()
    {
        MoveCharacter();
        PlayerSpeed();
        Passing();
        Invincible();
        EndGame();
    }

    private void MoveCharacter()
    {
        int dir_Up = Input.GetButtonDown("Up") ? 1 : 0;
        int dir_Down = Input.GetButtonDown("Down") ? 1 : 0;
        spawnPoint = Mathf.Clamp(spawnPoint + dir_Down - dir_Up, 1, 3);
        //Add a second input system that checks for swipe inputs
        spawnPoint = Mathf.Clamp(spawnPoint + swipe.direction, 1, 3);

        Moving(spawnPoint);
        //Vector2 direction = Vector2.up * (dir_Up - dir_Down);
        //SnapToNearestPosition(direction)
        if (dir_Up != 0 || dir_Down != 0)
        {
        moving = true;
        }
    }

    private void TilePosition(Vector2 direction)
    {
        Vector3 currentPosition = transform.position;
        Vector3Int cellPosition = tile.WorldToCell(currentPosition);
        Vector3Int gridDirection = new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        Vector3Int targetCellPosition = cellPosition + gridDirection;
        Vector3 targetPosition = tile.GetCellCenterWorld(targetCellPosition);
        float distance = Vector3.Distance(currentPosition, targetPosition);
    }

    private void Passing()
    {
        if(passed)
        {
            bool visible = Mathf.FloorToInt(8 * Time.time) % 2 == 0;
            sprite.enabled = visible;
            passtime -= countdown * Time.deltaTime;
            if(passtime <= 0)
            {
                passed = false;
                passtime = 3;
                sprite.enabled = true;
            }
        }
    }

    private void Invincible()
    {
        if(invincible)
        {
            invintime -= countdown * Time.deltaTime;
            bg_song.Pause();
            anim.SetBool("invincible", true);
            if(!invinstart)
            {
                invi_song.Play();
                invinstart = true;
            }

            if(invintime <= 0)
            {
                invincible = false;
                invinstart = false;
                passed = true;
                passtime = 2;
                invintime = 10;
                bg_song.UnPause();
                invi_song.Stop();
                anim.SetBool("invincible", false);
            }
        }
    }

    private void PlayerSpeed()
    {
        if (!damaged){
        timer -= countdown * Time.deltaTime;

        if (timer <= 0){
        //speed += .095f * Time.deltaTime;
        speed += .0245f * Time.deltaTime;
        }
        }

        else{
        timer = 5;
        }


        if (damaged)
        {
            locked = true;
            passed = true;
            currentSpeed = currentSpeed;
            speed = 0;
            pauseTime -= countdown * Time.deltaTime;
            timer = 3;
            anim.SetBool("damaged", true);
            if(!damgstart)
            {
                damg_sound.Play();
                damgstart = true;
            }
            if(pauseTime <= 0)
            {
                //speed = Mathf.Clamp(currentSpeed -.5f, 1, currentSpeed);
                speed = currentSpeed;
                pauseTime = 2;
                damaged = false;
                locked = false;
                damgstart = false;
                anim.SetBool("damaged", false);
            }
        }
        else
        {
            currentSpeed = speed;
        }


        if (stunned)
        {
            locked = true;
            lockTime -= countdown * Time.deltaTime;
            if(lockTime <= 0)
            {
                lockTime = 2;
                stunned = false;
                locked = false;
            }
        }
    }

    private void Moving(int place)
    {
        if(!locked && !health.dead)
        {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = spawns[place].position;
        float distance = Vector3.Distance(currentPosition, targetPosition);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, .25f);
        moving = false;
        }
        //transform.Translate(direction * distance * Time.deltaTime);
        //transform.position = targetPosition;
        //debug.text = "Current: " + currentPosition.ToString() + "\nTarget: " +  targetPosition.ToString() + "\nDistance: " +  distance.ToString();
    }

    void EndGame()
    {
        if(health.dead == true)
        {
            speed = 0;
            bg_song.Stop();
            anim.SetBool("gameover", true);
            swipe.arrows.SetActive(false);

        }
    }
}
