using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject dieMenu_UI;
    public static bool gameIsOver = false;

    [SerializeField]Snake snakeScript;
    public int score = 0;

    public float currentTimeScale = 0.20f;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y as plus d'une instance de GameManager dans la scène");
        }

        instance = this;
    }

    public void gameOver()  //Quand le joueur perd
    {
        Time.timeScale = 0;
        dieMenu_UI.SetActive(true);
    }

    public void ReloadGame()    //Quand le joueur appuie sur le bouton rejouer
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
