using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound
{
    /// <summary> SEを流せるチャンネル数 </summary>
    private const int SE_CHANNEL = 4;

    /// <summary> サウンド種別 </summary>
    private enum eType
    {
        BGM, 
        SE,  
    }
    /// <summary> シングルトン </summary>
    private static Sound _singleton = null;

    /// <summary> インスタンスの取得 </summary>
    public static Sound GetInstance()
    {
        return _singleton ?? (_singleton = new Sound());
    }

    /// <summary> サウンド再生のためのゲームオブジェクト </summary>
    private GameObject? _object = null;

    /// <summary> サウンドリソース </summary>
    private AudioSource? _sourceBGM = null;
    private AudioSource? _sourceSEDefault = null;
    private AudioSource[] _sourceSEArray;

    /// <summary> BGMにアクセスするためのテーブル </summary>
    private Dictionary<string, _Data> _poolBGM = new Dictionary<string, _Data>();

    /// <summary> SEにアクセスするためのテーブル </summary>
    private Dictionary<string, _Data> _poolSE = new Dictionary<string, _Data>();

    ///  <summary>保持するデータ </summary>
    public class _Data
    {

        ///  <summary>アクセス用のキー </summary>
        public string Key;

        ///  <summary>リソース名 </summary>
        public string ResName;

        ///  <summary>AudioClip </summary>
        public AudioClip Clip;

        /// <summary> Dataのコンストラクタ </summary>
        public _Data(string key, string res)
        {
            Key = key;
            ResName = "Sounds/" + res;
            Clip = Resources.Load(ResName) as AudioClip;
        }
    }
    /// <summary> Soundのコンストラクタ </summary>
    public Sound()
    {
        _sourceSEArray = new AudioSource[SE_CHANNEL];
    }

    /// <summary> AudioSourceの取得 </summary>
    private AudioSource _GetAudioSource(eType type, int channel = -1)
    {
        
        if (_object == null)
        {
            // GameObjectがなければ作る
            _object = new GameObject("Sound");

            // 破棄しないようにする
            GameObject.DontDestroyOnLoad(_object);

            // AudioSourceを作成
            _sourceBGM = _object.AddComponent<AudioSource>();
            _sourceSEDefault = _object.AddComponent<AudioSource>();
            for (int i = 0; i < SE_CHANNEL; i++)
            {
                _sourceSEArray[i] = _object.AddComponent<AudioSource>();
            }
        }

        if (type == eType.BGM)
        {
            // BGM
            return _sourceBGM;
        }
        else
        {
            // SE
            if (0 <= channel && channel < SE_CHANNEL)
            {
                // チャンネルを指定している場合
                return _sourceSEArray[channel];
            }
            else
            {
                // チャンネルを指定していない場合（デフォルト）
                return _sourceSEDefault;
            }
        }
    }

    /// <summary> BGMの読み込み </summary>
    public static void LoadBGM(string key, string resName)
    {
        GetInstance()._LoadBGM(key, resName);
    }

    /// <summary> SEの読み込み </summary>
    public static void LoadSE(string key, string resName)
    {
        GetInstance()._LoadSE(key, resName);
    }
    private void _LoadBGM(string key, string resName)
    {
        if (_poolBGM.ContainsKey(key))
        {
            // すでに登録済みの場合いったん消す
            _poolBGM.Remove(key);
        }
        _poolBGM.Add(key, new _Data(key, resName));
    }
    private void _LoadSE(string key, string resName)
    {
        if (_poolSE.ContainsKey(key))
        {
            // すでに登録済みの場合いったん消す
            _poolSE.Remove(key);
        }
        _poolSE.Add(key, new _Data(key, resName));
    }
    /// <summary> BGMの再生 </summary>
    /// ※事前にLoadBGMでロードしておくこと
    public static bool PlayBGM(string key)
    {
        return GetInstance()._PlayBGM(key);
    }
    private bool _PlayBGM(string key)
    {
        if (_poolBGM.ContainsKey(key) == false)
        {
            // 対応するキーがない場合
            return false;
        }

        // BGMは一つしか流れないのでいったん止める
        _StopBGM();

        // リソースの取得
        var _data = _poolBGM[key];

        // 再生
        var source = _GetAudioSource(eType.BGM);
        source.loop = true;
        source.clip = _data.Clip;
        source.Play();

        return true;
    }

    /// <summary> BGMの停止 </summary>
    public static bool StopBGM()
    {
        return GetInstance()._StopBGM();
    }
    private bool _StopBGM()
    {
        _GetAudioSource(eType.BGM).Stop();

        return true;
    }

    /// <summary> SEの再生 </summary>
    /// ※事前にLoadSEでロードしておくこと
    public static bool PlaySE(string key, int channel = -1)
    {
        return GetInstance()._PlaySE(key, channel);
    }
    private bool _PlaySE(string key, int channel = -1)
    {
        if (_poolSE.ContainsKey(key) == false)
        {
            // 対応するキーがない場合
            return false;
        }

        // リソースの取得
        var _data = _poolSE[key];

        if (0 <= channel && channel < SE_CHANNEL)
        {
            // チャンネル指定がある場合
            var source = _GetAudioSource(eType.SE, channel);
            source.clip = _data.Clip;
            source.Play();
        }
        else
        {
            // チャンネル指定がない場合（デフォルト）
            var source = _GetAudioSource(eType.SE);
            source.PlayOneShot(_data.Clip);
        }

        return true;
    }
}