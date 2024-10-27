using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jelly : MonoBehaviour
{
    [Header("# Jelly Stats")]
    public int id;
    public int exp;
    public int maxExp;
    public int level;
    public int value;
    [Header("# Jelly Movement")]
    Rigidbody2D rigid;
    public Vector2 nextMove;
    public float speed;
    [Header("# Jelly Animation")]
    Animator anim;
    SpriteRenderer spriter;
    Vector3 mousePositionOffset;
    bool onGround;
    bool isSelling;
    bool holding;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Init(SpawnData data)
    {
        maxExp = data.maxExp;
        spriter.sprite = GameManager.instance.jellySpriteList[data.spriteType];
        id = data.entityId;
        value = data.value;
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        anim.runtimeAnimatorController = GameManager.instance.animControl[0];
        level = 1;
        StartCoroutine(RandomMove());
        onGround = true;
        isSelling = false;
        value = 100;
        holding = false;
    }

    private void FixedUpdate()
    {
        rigid.velocity = nextMove * speed;
        
    }

    private void LateUpdate()
    {   
        if (nextMove != Vector2.zero)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
        
        if (nextMove.x != 0)
        {
            spriter.flipX = nextMove.x < 0;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePositionOffset = transform.position - GetMouseWorldPosition();

            anim.SetBool("doTouch", true);
            GameManager.instance.jelatin += (id + 1) * level;
            exp++;

            if (exp > maxExp && level < 3)
            {
                exp = 0;
                maxExp *= 2;
                level++;
                value *= 2;
                changeAnim();
            }
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
        holding = true;
    }

    private void OnMouseExit()
    {
        if (onGround == false && isSelling == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        holding = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            nextMove = new Vector2(-nextMove.x, -nextMove.y);
            onGround = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
        
    }


    

    private void changeAnim()
    {
        anim.runtimeAnimatorController = GameManager.instance.animControl[level - 1];
    }

    public void selling()
    {
        if (holding == true)
        {
            isSelling = true;
        }
    }

    public void sold()
    {
        if (isSelling == true)
        {
            isSelling = false;
            gameObject.SetActive(false);
            GameManager.instance.gold += value * level;

        }
    }


    IEnumerator RandomMove()
    {
        while (true) // Infinite loop for continuous movement
        {
            if (Random.Range(0, 8) == 3)
            {
                nextMove = new Vector2(0, 0);
            }
            else
            {
                float randomY = Random.Range(-1f, 1f);
                float randomX = Random.Range(-1f, 1f);
                nextMove = new Vector2(randomX, randomY);
            }
            // Wait for 5 seconds before changing direction again
            yield return new WaitForSeconds(Random.Range(3,5));
        }
    }

    
}
