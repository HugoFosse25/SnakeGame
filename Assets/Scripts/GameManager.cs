using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject dieMenu_UI;
    public static bool gameIsOver = false;

    [SerializeField]Snake snakeScript;
    [SerializeField]Text scoreText;
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
        //Time.timeScale = 0;
        dieMenu_UI.SetActive(true);
    }

    public void ReloadGame()    //Quand le joueur appuie sur le bouton rejouer
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadScoreDisplay()
    {
        scoreText.text = "SCORE : " + score.ToString();

        switch(score)
        {
            case 10:
                currentTimeScale = Time.timeScale = 0.25f;
            break;
            case 50:
                currentTimeScale = Time.timeScale = 0.35f;
            break;
            case 100:
                currentTimeScale = Time.timeScale = 0.50f;
            break;
        }
    }

}
