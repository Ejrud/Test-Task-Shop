using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    public static int MENU_SCENE_INDEX = 1;

    private void Start()
    {
        SceneManager.LoadScene(MENU_SCENE_INDEX);
    }
}
