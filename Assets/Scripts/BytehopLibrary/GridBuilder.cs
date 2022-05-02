using System;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace BytehopLibrary
{
    public class GridBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject ObjectPrefab;

        [Header("Units In Each Direction")] [SerializeField]
        private Vector3 GridMatrix;

        [Header("Distance Between Objects")] [SerializeField]
        private Vector3 Distance;

        [Header("Parent Object Name")] [SerializeField]
        private string gridParentObjectName = "GridParent_";

        [Header("Should GridAndParent Self Destruct ?")] [SerializeField]
        bool selfDestruct;
        [SerializeField] float timeToSelfDestruct;
        
        [Header("Should Objects have alternate colors when instantiated?")] [SerializeField]
        bool addAlternateColorToGrid;
        [SerializeField] private Material mat1;
        [SerializeField] private Material mat2;
        
        [Header("Original ObjectSize - Not Editable")] [SerializeField]
        private Vector3 debugReadOnly_ObjectSize;

        private Transform parentObject;
        
        void Start()
        {
            Build();
        }

        private void OnValidate()
        {
            if (GridMatrix.x * GridMatrix.y * GridMatrix.z > 500)
            {
                Debug.LogWarning("The Number of Objects You are trying to instantiate might cause a lag on start()");
            }
        }

        [ContextMenu("Build Grid")]
        void Build()
        {
            debugReadOnly_ObjectSize = ObjectPrefab.GetComponent<MeshRenderer>().bounds.size;
            Vector3 lastPos = Vector3.zero;
            parentObject = new GameObject().transform;

            // 3D ONLY FOR NOW, NEEDS TO BE FIXED FOR 2D SUPPORT
            for (int i = 0; i < GridMatrix.x; i++)
            {
                if (GridMatrix.y > 0)
                {
                    for (int j = 0; j < GridMatrix.y; j++)
                    {
                        Vector3 newPos = new Vector3(lastPos.x, lastPos.y + (Distance.y * (j + 1)), lastPos.z);
                        var lastObjectY = Instantiate(ObjectPrefab, newPos, Quaternion.identity);
                        lastObjectY.transform.parent = parentObject;
                        AddMaterialToObject(lastObjectY);

                        for (int k = 0; k < GridMatrix.z - 1; k++)
                        {
                            Vector3 newPos2 = new Vector3(lastPos.x, newPos.y, lastPos.z + (Distance.z * (k + 1)));
                            var lastObjectZ = Instantiate(ObjectPrefab, newPos2, Quaternion.identity);
                            lastObjectZ.transform.parent = parentObject;
                            AddMaterialToObject(lastObjectZ);
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < GridMatrix.z; k++)
                    {
                        Vector3 newPos2 = new Vector3(lastPos.x, lastPos.y, lastPos.z + (Distance.z * (k + 1)));
                        var lastObjectZ = Instantiate(ObjectPrefab, newPos2, Quaternion.identity);
                        lastObjectZ.transform.parent = parentObject;
                        AddMaterialToObject(lastObjectZ);
                    }
                }

                lastPos.x += Distance.x;
            }

            gridParentObjectName += GridMatrix.x + " x " + GridMatrix.y + " x " + GridMatrix.z;
            parentObject.name = gridParentObjectName;

            // Reset Center Of Parent
            CenterOnChildren(parentObject);

            if (selfDestruct) Invoke("DestroyObject", timeToSelfDestruct);
        }

        void CenterOnChildren(Transform aParent)
        {
            var childs = aParent.Cast<Transform>().ToList();
            var pos = Vector3.zero;
            foreach (var C in childs)
            {
                pos += C.position;
                C.parent = null;
            }

            pos /= childs.Count;
            aParent.position = pos;
            foreach (var C in childs)
                C.parent = aParent;
        }
        void DestroyObject()
        {
            DestroyImmediate(parentObject.GameObject(), true);
        }

        #region AddAlternateColorToEveryObjectInGrid

        private bool colorState;

        void AddMaterialToObject(GameObject colorObject)
        {
           
            if(addAlternateColorToGrid == false) return;
            
            if (colorState)
            {
               if(mat1 != null)  colorObject.GetComponent<MeshRenderer>().material = mat1;
                colorState = false;
            }
            else
            { 
                if(mat2 != null) colorObject.GetComponent<MeshRenderer>().material = mat2;
                colorState = true;
            }
        }

        #endregion
    }
}