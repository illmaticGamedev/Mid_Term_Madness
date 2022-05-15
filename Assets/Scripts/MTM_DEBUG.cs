using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace MidTermMadness
{
    public class MTM_DEBUG : MonoBehaviour
    {
        public List<string> AllMessages = new List<string>();
        public List<GameObject> AllObjects = new List<GameObject>();
        [SerializeField] private RectTransform parentObject;
        [SerializeField] private GameObject textPrefab; 
        private void Awake()
        {
            //AllObjects.Capacity = AllMessages.Capacity;
            InstantiateAllFields();
        }

        void InstantiateAllFields()
        {
            foreach (var item in AllMessages)
            {
                if (item.Length > 0)
                {
                    GameObject newUIObject = Instantiate(textPrefab,parentObject);
                    AllObjects.Add(newUIObject);
                }
            }
        }

        private void Update()
        {
            AllObjects[0].GetComponent<TextMeshProUGUI>().text = currentFPSCount();
            AllObjects[1].GetComponent<TextMeshProUGUI>().text = "RAW VEC - " +  InputManager.Instance.MovementDirectionRaw.ToString();
        }

        string currentFPSCount()
        {
            int fps = 0;
            fps = (int) (Time.frameCount / Time.time);
            return "Fps - " + fps.ToString();
        }
    }
}
