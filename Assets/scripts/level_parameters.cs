using UnityEngine;

[System.Serializable]
public class level_parameters {
    public int level;

    [Header("addition")]
    public bool do_addition = true;
    public float max_answer_add = 10f;

    public float min_answer_add = 0f;

    [Header("Substaction")]
    public bool do_substaction = false;
    public float max_answer_sub = 10f;

    public float min_answer_sub = 0f;

}
