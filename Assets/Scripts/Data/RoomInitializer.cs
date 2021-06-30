using MurderByDeath.ContextMenu;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MurderByDeath.Data
{
    public class RoomInitializer : MonoBehaviour
    {
        [SerializeField]
        private string _fileName;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            TextAsset objects = Resources.Load<TextAsset>(_fileName);
            RoomData parsed = JsonUtility.FromJson<RoomData>(objects.text);
            InitObjects(parsed.objects);
        }

        private void InitObjects(List<InteractiveObjectData> data)
        {
            InteractiveObject[] interactiveObjects = FindObjectsOfType<InteractiveObject>();
            Dictionary<string, InteractiveObjectData> objDict = data.ToDictionary(c => c.objectId);
            foreach (InteractiveObject obj in interactiveObjects)
            {
                if (objDict.TryGetValue(obj.ObjectId, out InteractiveObjectData value))
                {
                    obj.SetData(value);
                }
            }
        }
    }
}
