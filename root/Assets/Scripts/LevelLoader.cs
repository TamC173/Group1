using UnityEngine;
using System.Collections;

public class LevelLoader : Singleton<LevelLoader> 
{
    public void MainMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }

    public void MapScene()
    {
        Application.LoadLevel("map_layout");
    }

    public void Level1()
    {
        Application.LoadLevel("FallingOpening");
    }

    public void StartLevel1()
    {
        Application.LoadLevel("Falling");
    }

    public void StartLevel2()
    {
        Application.LoadLevel("NakedGame");
    }

    public void Level2Opening()
    {
        Application.LoadLevel("NakedOpening");
    }
 
}
