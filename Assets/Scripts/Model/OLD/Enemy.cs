public class Enemy
{
    /// <summary>�ړ����x</summary>
    private float moveSpeed;

    /// <summary>�̗�</summary>
    private int Health;

    /// <summary>�_���[�W</summary>
    private int Damage;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="movespeed">�ړ����x</param>
    /// <param name="health">�̗�</param>
    /// <param name="damage">�_���[�W</param>
    public Enemy(int health, int damage)
    {
        Health = health;
        Damage = damage;
    }

    /// <summary>
    /// �_���[�W�̎擾
    /// </summary>
    /// <returns>�_���[�W</returns>
    public int GetDamage()
    {
        return Damage;
    }

    /// <summary>�_���[�W�v�Z </summary>
    /// <param name="selflayername">�����̃I�u�W�F�N�g�̃��C���[</param>
    /// <param name="collayername">�ڐG�����I�u�W�F�N�g�̃��C���[</param>
    public int CalcDamage(string selflayername, string collayername)
    {
        int dmg = 0;
        // �v���C���[�̒e
        if (collayername == "PlayerBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 120;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 60;
            }
        }
        // �}�E�X�̒e
        else if (collayername == "MouseBullet")
        {
            if (selflayername == "Enemy")
            {
                dmg = 30;
            }
            else if (selflayername == "FlickEnemy")
            {
                dmg = 120;
            }
        }
        return dmg;
    }
}