using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zoca.VirtualInputSystem.Examples
{
    public class TapAndSwipeTester : MonoBehaviour
    {
        [SerializeField]
        GameObject log;

        Text logText;

        float logTime = 0.5f;
        float logElapsed = 0;
        float redLogElapsed = 0;

        // Start is called before the first frame update
        void Start()
        {
            logText = log.GetComponentInChildren<Text>();
            log.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            Data.TapData tapData;
            if(VirtualInput.GetTap(out tapData))
            {
               
                (log.transform as RectTransform).anchoredPosition = tapData.position;
                logElapsed = logTime;
                logText.text = "Tap";
                log.SetActive(true);

            }

            Data.SwipeData swipeData;
            if (VirtualInput.GetSwipe(out swipeData))
            {
                (log.transform as RectTransform).anchoredPosition = swipeData.position;
                logElapsed = logTime;
                logText.text = "Swipe";
                log.SetActive(true);

            }

            CheckLog();
            
        }

        void CheckLog()
        {
            if (logElapsed > 0)
            {
                logElapsed -= Time.deltaTime;
                if (logElapsed <= 0)
                    log.SetActive(false);
            }
        }

    }

}
