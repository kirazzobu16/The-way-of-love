using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MainCharacterPos : MonoBehaviour
{
    private GameMaster gm;
    Animator animator;
  

    void Start()
    {

        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;


    }


    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {

       
        

            // GetComponent<player>().enabled = false;
            if (other.tag == "dead")
            {
            StartCoroutine(RespawnCoroutine());
            }

        }
    public IEnumerator RespawnCoroutine()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDead", true);
   
        yield return new WaitForSeconds(0.30f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
   


 