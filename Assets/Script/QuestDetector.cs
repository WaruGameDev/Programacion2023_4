using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDetector : MonoBehaviour
{
    public UnityEvent onQuestDetected;
    public Quest questTodetect;

    public void Detect()
    {
        if (QuestManager.instance.GetQuestStatus(questTodetect.nameQuest)
            == questTodetect.statusQuest)
        {
            onQuestDetected?.Invoke();
        }
    }

    public void Update()
    {
        Detect();
    }
}
