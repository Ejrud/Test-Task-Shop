using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    public static int MENU_SCENE_INDEX = 1;

    [Inject] private DataService _dataService;
    [Inject] private DataInteraction _dataInteraction;
    [Inject] private VaultController _vaultController;
    
    private void Start()
    {
        _dataService.Initialize();
        _dataInteraction.Initialize();
        _vaultController.Initialize();
        
        Debug.Log("All systems are initialized");
        
        SceneManager.LoadScene(MENU_SCENE_INDEX);
    }
}
