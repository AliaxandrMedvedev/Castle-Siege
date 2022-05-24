using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    
    void Start()
    {
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        if (size == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
