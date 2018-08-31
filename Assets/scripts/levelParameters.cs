using UnityEngine;

[System.Serializable]
public class levelParameters {
    public int level = 1;
    public int next_level_score = 1000;

    [Header("addition")]
    public float addition_prop_weight = 1f;
    public float max_answer_add = 10f;
    public float min_answer_add = 0f;
    public int num_decimals_add = 0;

    [Header("Substaction")]
    public float substraction_prop_weight = 0f;
    public float max_answer_sub = 10f;
    public float min_answer_sub = 0f;
    public int num_decimals_sub = 0;

}
