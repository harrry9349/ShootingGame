using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        LoadSound();
        Sound.PlayBGM("ingame");
    }

    private void LoadSound()
    {
        Sound.LoadBGM("ingame", "The_End_of_Destruction");      // �C���Q�[����ʂ̉��y
        Sound.LoadBGM("warning", "warning");                    // �{�X�O�̌x��
        Sound.LoadBGM("boss", "RAIN_&amp_Co_II_2");             // �{�X�o�g���̉��y
        Sound.LoadSE("reload", "equip");                        // �����[�h
        Sound.LoadSE("reloadEnd", "reloadEnd");                             // ���U��
        Sound.LoadSE("useAbility", "taisen_card");              // �A�r���e�B�g�p
        Sound.LoadSE("pop", "Pop");                             // �A�C�e���擾
        Sound.LoadSE("heal", "heal");                           // ��
        Sound.LoadSE("damage", "damage");                       // �_���[�W
        Sound.LoadSE("Explode", "Explode");                     // ����
        Sound.LoadSE("shot", "Shot");                           // �e�۔���
        Sound.LoadSE("burstshot", "BurstShot");                 // �o�[�X�g����
        Sound.LoadSE("unableshot", "UnableShot");               // ���˂ł��Ȃ�
        Sound.LoadSE("marksmanshot", "FlickShot");              // �}�[�N�X�}���e�۔���
        Sound.LoadSE("shotgunshot", "BigFire");                 // �V���b�g�K���e�۔���
        Sound.LoadSE("cut", "Cut");                             // ���U��
        Sound.LoadSE("danger", "danger");                       // �c��HP�����Ȃ�
    }
}