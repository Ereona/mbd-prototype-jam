using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu.Actions
{
    public class OpenAction : MenuAction
    {
        public override void Execute(InteractiveObject obj)
        {
            // TODO: implement action
            Debug.Log("Open " + obj.ObjectId);
        }
    }
}
