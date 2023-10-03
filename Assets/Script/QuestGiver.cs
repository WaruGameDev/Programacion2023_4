using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;

    public void AddQuest()
    {
        if (QuestManager.instance.GetQuestStatus(questToGive.nameQuest) != QUEST_STATUS.ASSIGNED)
        {
            QuestManager.instance.AddQuest(questToGive);
        }
    }

    public void AddQuest(string questToAddString)
    {
        if (QuestManager.instance.GetQuestStatus(questToAddString) != QUEST_STATUS.ASSIGNED)
        {
            QuestManager.instance.AddQuest(questToAddString);
        }
        
    }
}
