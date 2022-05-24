using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Image[] images;
    private int _deathCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        images[_deathCount].gameObject.SetActive(true);
        _deathCount++;

        if (_deathCount == images.Length)
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
}
