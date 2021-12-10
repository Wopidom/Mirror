using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static Enums;

public class Work : MonoBehaviour
{
    public SpriteRenderer[] pieces;
    public Sprite[] buttons;
    public SpriteRenderer button;
    public float taskDelay;
    public WorkTask[] workTasks;

    private void Start()
    {
        button.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            Character character = other.GetComponent<Character>();
            character.tree.SetVariableValue("workTime", taskDelay * workTasks.Length);
            WorkTask(character);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        button.gameObject.SetActive(false);
    }


    private void WorkTask(Character character)
    {
        for (int i = 0; i < workTasks.Length; i++)
        {
            DOTask(i, character);
        }
    }

    private void DOTask(int idx, Character character)
    {
        int taskId = (int)workTasks[idx];
        DOVirtual.DelayedCall(taskDelay * idx, () => pieces[taskId].DOFade(0.8f, taskDelay / 2).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine));
        DOVirtual.DelayedCall(taskDelay * idx, () => button.gameObject.SetActive(true));
        DOVirtual.DelayedCall(taskDelay * idx, () => button.sprite = buttons[taskId]);
        //DOVirtual.DelayedCall(taskDelay * idx, () => character.transform.DOMove(pieces[taskId].transform.position, taskDelay / 2));
        DOVirtual.DelayedCall(taskDelay * idx, () => button.transform.DOMove(new Vector3(0, 1, 0), taskDelay).SetRelative(true).SetEase(Ease.InSine).From(pieces[taskId].transform.position));
    }
}
