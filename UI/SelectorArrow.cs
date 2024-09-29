using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip selectorSound;
    [SerializeField] private AudioClip enterSound;
    private int currentPos;
    private RectTransform rect;
    private void Awake() {
        rect = GetComponent<RectTransform>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangePosition(-1);
        } else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            ChangePosition(1);
        } else if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E)) {
            Press();
        }
    }
    private void ChangePosition(int _change) {
        if(_change != 0) SoundManager.instance.PlaySound(selectorSound);
        currentPos += _change;
        if(currentPos < 0) {
            currentPos = options.Length - 1;
        }
        if(currentPos > options.Length - 1) {
            currentPos = 0;
        }
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);
    }

    private void Press() {
        SoundManager.instance.PlaySound(enterSound);
        options[currentPos].GetComponent<Button>().onClick.Invoke();
    }
}
