using UnityEngine;

public class Menu : MonoBehaviour
{
   public void StartGame()
   {
      GameManager.instance.LoadGameAndGUI();
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
