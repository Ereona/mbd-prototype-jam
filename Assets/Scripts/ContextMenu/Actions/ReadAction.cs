using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu.Actions
{
    public class ReadAction : MenuAction
    {
        public override void Execute(InteractiveObject obj)
        {
            // TODO: implement action
            Debug.Log("Read " + obj.ObjectId);
        }
    }
}
