using UnityEngine;

[System.Serializable]
public class levelParametersEnemy {
    [Header("addition")]
    public float addition_prop_weight = 1f;
    public float max_input_add = 10f;
    public float min_input_add = 0f;
    public int num_decimals_add = 0;

    [Header("Substaction")]
    public bool allow_negative_answers = false;
    public float substraction_prop_weight = 0f;
    public float max_input_sub = 10f;
    public float min_input_sub = 0f;
    public int num_decimals_sub = 0;

}
