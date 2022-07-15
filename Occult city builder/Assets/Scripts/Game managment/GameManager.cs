using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MonsterManager monster;
    public ResourceData resources;
    public int numOfCursedTiles,numOfErelevantTiles;
    public Tiles[] listOfTiles;
    private bool hasLost, hasWon;
    public static int numOfTilesToWin;
    private int curentSceneIndex;
     [SerializeField] private int reasoursesOnStart;

    public static bool isEventUIActive = false;

    public static bool isPaused = false;
    /*
     * timer -> to UI
     * points - resources -> to UI
     * sceneManger
     */


    // Start is called before the first frame update

    public static void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;


    }


    public static void  ResumeGame()
    {
      
            Time.timeScale = 1;
            isPaused = false;

    }
        
    
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            listOfTiles = FindObjectsOfType<Tiles>();
            SetingBlessedTiles();
            //ResetingResources();
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GoToMainMenu();
            SetingCursedTilesNumberAndLoseCondition();
            WinCondition();
            LoadingOnWinLose();
        }
    }
    private void WinCondition()
    {
        if (numOfTilesToWin>=numOfErelevantTiles)
        {
            hasWon = true;
        }
    }
    private void LoadingOnWinLose()
    {
        if(hasWon)
        {
            hasWon = false;
            Loader(SceneManager.GetActiveScene().buildIndex + 1);    
        }
        if(hasLost)
        {
            hasLost = false;
            Loader(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
    public void Loader(int scene)
    {
        ResetingResources();
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void GoToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Loader(0);
        }
    }
    private void SetingCursedTilesNumberAndLoseCondition()
    {
        for(int i=0;i<listOfTiles.Length;i++)
        {
            if(listOfTiles[i].isCursed)
            {
                numOfCursedTiles++;
            }
        }
        if (numOfCursedTiles >= listOfTiles.Length - numOfErelevantTiles)
        {
            hasLost = true;
        }
        else
        {
            numOfCursedTiles = 0;
        }
    }
    private void SetingBlessedTiles()
    {
        for (int i = 0; i < listOfTiles.Length; i++)
        {
            if (listOfTiles[i].isErelevantToLoseCondition)
            {
                numOfErelevantTiles++;
            }
        }
    }
   private void ResetingResources()
    {
        resources.wood = reasoursesOnStart;
        resources.gold = reasoursesOnStart;
        resources.vilagers = reasoursesOnStart;
        resources.researchPoints = reasoursesOnStart;
        resources.cattle = reasoursesOnStart;
        numOfCursedTiles = 0;
    }
}