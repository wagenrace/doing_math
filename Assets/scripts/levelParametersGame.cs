using UnityEngine;

[System.Serializable]
public class levelParametersGame {
    public int score_for_this_level = 0;
    public string name = "";
    public string message = "Well done";
    private int level_num = 0;

    public void set_level(int _l){level_num = _l;}
    public int get_level(){return level_num;}
}
