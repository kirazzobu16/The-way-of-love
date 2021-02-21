using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterPos : MonoBehaviour
{
    private GameMaster gm;
    Animator animator;
    public GameObject olum;
    void Start()
    {

        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        
        animator.SetBool("IsDead", false);
    }
  
    
   

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "dead")
        {

            // GetComponent<player>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
    
}