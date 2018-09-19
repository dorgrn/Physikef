using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModestTree;
using UnityEngine;
using UnityEngine.UI;

public class InfoScrollViewController : MonoBehaviour
{
    private Text infoText;

    async void Start()
    {
        infoText = GetComponent<Text>();
    }

    public async Task UpdateInfoTextAsync(string userid)
    {
        infoText.text = userid == null ? "" : await TeachersOptionsController.GetStudentStatsAnalysisAsync(userid);
    }
}