using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class canvasGameOverDirector : MonoBehaviour {
    public TMPro.TextMeshProUGUI score_text;
	
	public void set_score(int _score){
		score_text.text = _score.ToString();
	}
}
