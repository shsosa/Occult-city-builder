using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterManager monster;
    public ResourceManager ResourceManager;
    public int numOfCursedTiles;
    public Tiles[] listOfTiles;
    private bool hasLost,hasWon;
    /*
     * timer -> to UI
     * points - resources -> to UI
     * sceneManger
     */


    // Start is called before the first frame update
    void Start()
    {
        numOfCursedTiles = 0;
        listOfTiles = FindObjectsOfType<Tiles>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LoseCondition()
    {
        if(numOfCursedTiles>=listOfTiles.Length)
        {
            hasLost = true;
        }
    }
    private void WinCondition()
    {
        if(monster.isBanished)
        {
            hasWon = true;
        }
    }
}