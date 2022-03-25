using UnityEngine;

[CreateAssetMenu]
public class Score : ScriptableObject
{
    /// <summary>最終的に倒した敵の数</summary>
    [SerializeField]
    public int[] numShootDown;

    /// <summary>最終スコア</summary>
    [SerializeField]
    public int totalScore;
}