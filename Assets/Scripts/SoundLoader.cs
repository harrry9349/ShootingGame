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
        Sound.LoadBGM("ingame", "The_End_of_Destruction");      // インゲーム画面の音楽
        Sound.LoadBGM("warning", "warning");                    // ボス前の警告
        Sound.LoadBGM("boss", "RAIN_&amp_Co_II_2");             // ボスバトルの音楽
        Sound.LoadSE("reload", "equip");                        // リロード
        Sound.LoadSE("reloadEnd", "reloadEnd");                             // 剣攻撃
        Sound.LoadSE("useAbility", "taisen_card");              // アビリティ使用
        Sound.LoadSE("pop", "Pop");                             // アイテム取得
        Sound.LoadSE("heal", "heal");                           // 回復
        Sound.LoadSE("damage", "damage");                       // ダメージ
        Sound.LoadSE("Explode", "Explode");                     // 爆発
        Sound.LoadSE("shot", "Shot");                           // 弾丸発射
        Sound.LoadSE("burstshot", "BurstShot");                 // バースト発射
        Sound.LoadSE("unableshot", "UnableShot");               // 発射できない
        Sound.LoadSE("marksmanshot", "FlickShot");              // マークスマン弾丸発射
        Sound.LoadSE("shotgunshot", "BigFire");                 // ショットガン弾丸発射
        Sound.LoadSE("cut", "Cut");                             // 剣攻撃
        Sound.LoadSE("danger", "danger");                       // 残りHPが少ない
    }
}