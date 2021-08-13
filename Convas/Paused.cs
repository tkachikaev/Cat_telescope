using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
