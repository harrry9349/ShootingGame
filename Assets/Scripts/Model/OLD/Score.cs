using UnityEngine;

[CreateAssetMenu]
public class Score : ScriptableObject
{
    /// <summary>�ŏI�I�ɓ|�����G�̐�</summary>
    [SerializeField]
    public int[] numShootDown;

    /// <summary>�ŏI�X�R�A</summary>
    [SerializeField]
    public int totalScore;
}