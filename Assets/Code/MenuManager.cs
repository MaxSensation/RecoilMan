using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PressedStart()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void PressedOption()
    {
        
    }
    
    public void PressedExit()
    {
        Application.Quit();
    }
}
