using System.Linq;
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

        [ContextMenu("Build Grid")]
        void Build()
        {
            Vector3 lastPos = Vector3.zero;

           // 3D ONLY FOR NOW, NEEDS TO BE FIXED FOR 2D SUPPORT
            for (int i = 0; i < GridMatrix.x; i++)
            {
                if (GridMatrix.y > 0)
                {
                    for (int j = 0; j < GridMatrix.y; j++)
                    {
                        Vector3 newPos = new Vector3(lastPos.x, lastPos.y + (Distance.y * (j + 1)), lastPos.z);
                        var lastObjectY = Instantiate(ObjectPrefab, newPos, Quaternion.identity);
                        lastObjectY.transform.parent = transform;

                   
                        for (int k = 0; k < GridMatrix.z-1; k++)
                        {
                            Vector3 newPos2 = new Vector3(lastPos.x, newPos.y, lastPos.z + (Distance.z * (k + 1)));
                            var lastObjectZ = Instantiate(ObjectPrefab, newPos2, Quaternion.identity);
                            lastObjectZ.transform.parent = transform;
                        }
                    }
                }
 
                lastPos.x += Distance.x;
            }
            
            // Reset Center Of Parent
            CenterOnChildren(transform);
        }
        
        public void CenterOnChildren(Transform aParent)
        {
            var childs = aParent.Cast<Transform>().ToList();
            var pos = Vector3.zero;
            foreach(var C in childs)
            {
                pos += C.position;
                C.parent = null;
            }
            pos /= childs.Count;
            aParent.position = pos;
            foreach(var C in childs)
                C.parent = aParent;
        }   
    }
    
    
 
}