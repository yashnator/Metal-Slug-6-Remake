// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthBar;
    private void Start() {
        totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update() {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
