using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Written by: SpeedTutor on Youtube, see https://www.youtube.com/watch?v=FrJogRBSzFo&t=698s
                Partially tweaked and edited for game by Daniel Colina
    --ButtonManager--
    Handles logic of buttons in various menu screens, not actually instanced.
*/
public class ButtonManager : MonoBehaviour
{
	public GameObject m_Loading;
	public GameObject m_Background;

	void Start()
	{
		m_Loading.SetActive (false);
		m_Background.SetActive (false);
	}
    public void LoadLevelByName(string newGameLevel)
    {
		if (newGameLevel == "Level_Zero(Tutorial)" || newGameLevel == "Level_One" || newGameLevel == "Level_Two") 
		{
			m_Background.SetActive (true);
			m_Loading.SetActive (true);
		}
        SceneManager.LoadScene(newGameLevel, LoadSceneMode.Single);
		Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    
}
