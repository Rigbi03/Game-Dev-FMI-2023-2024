using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndConditions : MonoBehaviour
{

    bool gameHasEnded = false;

    public void EndGame ()
    {
        if (!gameHasEnded) 
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       // if (collision.gameObject.CompareTag("Finish") && FindObjectOfType<>}
    }
}
