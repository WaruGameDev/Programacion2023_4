using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterChangeQuest : MonoBehaviour
{
   public Quest quest;
   public UnityEvent onChangeQuest;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         QuestManager.instance.ChangeQuestStatus(quest.nameQuest, quest.statusQuest);
         onChangeQuest?.Invoke();
      }
   }
}
