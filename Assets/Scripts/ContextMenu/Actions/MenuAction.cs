using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu.Actions
{
    public abstract class MenuAction
    {
        public abstract void Execute(InteractiveObject obj);
    }
}
