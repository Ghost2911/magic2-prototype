using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Slider slider;
    public Unit playerOne;
    public Unit playerTwo;
    public TextMeshProUGUI textMesh;

    private void Start()
    {
        playerOne.OnDamage.AddListener(PlayerOneDamaged);
        playerTwo.OnDamage.AddListener(PlayerTwoDamaged);
    }

    void PlayerOneDamaged()
    {
        slider.value--;
        if (slider.value == 0)
        {
            textMesh.text = "You lose...";
            textMesh.GetComponent<Animator>().SetTrigger("Rotate");
            StartCoroutine(ReloadScene());
        }

    }

    void PlayerTwoDamaged()
    {
        slider.value++;
        if (slider.value == 10)
        {
            textMesh.text = "You WIN!";
            textMesh.GetComponent<Animator>().SetTrigger("Rotate");
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        playerOne.OnDamage.RemoveListener(PlayerOneDamaged);
        playerTwo.OnDamage.RemoveListener(PlayerTwoDamaged);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
