using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public const float JUMP_POWER = 20;
    public int itemCount;
    public GameManager manager;
    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        isJump = false;
        itemCount = 0;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JUMP_POWER, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            manager.GetItem(itemCount);
            GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                if(manager.stage == 2)
                {
                    SceneManager.LoadScene("RollingBall_0");
                }
                else
                {
                    SceneManager.LoadScene("RollingBall_" + (manager.stage + 1).ToString());
                }
            }
            else
            {
                SceneManager.LoadScene("RollingBall_" + (manager.stage).ToString());
            }

        }
        else if(other.tag == "Gameover")
        {
            SceneManager.LoadScene("RollingBall_" + (manager.stage).ToString());
        }
    }
}
