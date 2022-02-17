using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound
{
    /// <summary> SE�𗬂���`�����l���� </summary>
    private const int SE_CHANNEL = 4;

    /// <summary> �T�E���h��� </summary>
    private enum eType
    {
        BGM, 
        SE,  
    }
    /// <summary> �V���O���g�� </summary>
    private static Sound _singleton = null;

    /// <summary> �C���X�^���X�̎擾 </summary>
    public static Sound GetInstance()
    {
        return _singleton ?? (_singleton = new Sound());
    }

    /// <summary> �T�E���h�Đ��̂��߂̃Q�[���I�u�W�F�N�g </summary>
    private GameObject? _object = null;

    /// <summary> �T�E���h���\�[�X </summary>
    private AudioSource? _sourceBGM = null;
    private AudioSource? _sourceSEDefault = null;
    private AudioSource[] _sourceSEArray;

    /// <summary> BGM�ɃA�N�Z�X���邽�߂̃e�[�u�� </summary>
    private Dictionary<string, _Data> _poolBGM = new Dictionary<string, _Data>();

    /// <summary> SE�ɃA�N�Z�X���邽�߂̃e�[�u�� </summary>
    private Dictionary<string, _Data> _poolSE = new Dictionary<string, _Data>();

    ///  <summary>�ێ�����f�[�^ </summary>
    public class _Data
    {

        ///  <summary>�A�N�Z�X�p�̃L�[ </summary>
        public string Key;

        ///  <summary>���\�[�X�� </summary>
        public string ResName;

        ///  <summary>AudioClip </summary>
        public AudioClip Clip;

        /// <summary> Data�̃R���X�g���N�^ </summary>
        public _Data(string key, string res)
        {
            Key = key;
            ResName = "Sounds/" + res;
            Clip = Resources.Load(ResName) as AudioClip;
        }
    }
    /// <summary> Sound�̃R���X�g���N�^ </summary>
    public Sound()
    {
        _sourceSEArray = new AudioSource[SE_CHANNEL];
    }

    /// <summary> AudioSource�̎擾 </summary>
    private AudioSource _GetAudioSource(eType type, int channel = -1)
    {
        
        if (_object == null)
        {
            // GameObject���Ȃ���΍��
            _object = new GameObject("Sound");

            // �j�����Ȃ��悤�ɂ���
            GameObject.DontDestroyOnLoad(_object);

            // AudioSource���쐬
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
                // �`�����l�����w�肵�Ă���ꍇ
                return _sourceSEArray[channel];
            }
            else
            {
                // �`�����l�����w�肵�Ă��Ȃ��ꍇ�i�f�t�H���g�j
                return _sourceSEDefault;
            }
        }
    }

    /// <summary> BGM�̓ǂݍ��� </summary>
    public static void LoadBGM(string key, string resName)
    {
        GetInstance()._LoadBGM(key, resName);
    }

    /// <summary> SE�̓ǂݍ��� </summary>
    public static void LoadSE(string key, string resName)
    {
        GetInstance()._LoadSE(key, resName);
    }
    private void _LoadBGM(string key, string resName)
    {
        if (_poolBGM.ContainsKey(key))
        {
            // ���łɓo�^�ς݂̏ꍇ�����������
            _poolBGM.Remove(key);
        }
        _poolBGM.Add(key, new _Data(key, resName));
    }
    private void _LoadSE(string key, string resName)
    {
        if (_poolSE.ContainsKey(key))
        {
            // ���łɓo�^�ς݂̏ꍇ�����������
            _poolSE.Remove(key);
        }
        _poolSE.Add(key, new _Data(key, resName));
    }
    /// <summary> BGM�̍Đ� </summary>
    /// �����O��LoadBGM�Ń��[�h���Ă�������
    public static bool PlayBGM(string key)
    {
        return GetInstance()._PlayBGM(key);
    }
    private bool _PlayBGM(string key)
    {
        if (_poolBGM.ContainsKey(key) == false)
        {
            // �Ή�����L�[���Ȃ��ꍇ
            return false;
        }

        // BGM�͈��������Ȃ��̂ł�������~�߂�
        _StopBGM();

        // ���\�[�X�̎擾
        var _data = _poolBGM[key];

        // �Đ�
        var source = _GetAudioSource(eType.BGM);
        source.loop = true;
        source.clip = _data.Clip;
        source.Play();

        return true;
    }

    /// <summary> BGM�̒�~ </summary>
    public static bool StopBGM()
    {
        return GetInstance()._StopBGM();
    }
    private bool _StopBGM()
    {
        _GetAudioSource(eType.BGM).Stop();

        return true;
    }

    /// <summary> SE�̍Đ� </summary>
    /// �����O��LoadSE�Ń��[�h���Ă�������
    public static bool PlaySE(string key, int channel = -1)
    {
        return GetInstance()._PlaySE(key, channel);
    }
    private bool _PlaySE(string key, int channel = -1)
    {
        if (_poolSE.ContainsKey(key) == false)
        {
            // �Ή�����L�[���Ȃ��ꍇ
            return false;
        }

        // ���\�[�X�̎擾
        var _data = _poolSE[key];

        if (0 <= channel && channel < SE_CHANNEL)
        {
            // �`�����l���w�肪����ꍇ
            var source = _GetAudioSource(eType.SE, channel);
            source.clip = _data.Clip;
            source.Play();
        }
        else
        {
            // �`�����l���w�肪�Ȃ��ꍇ�i�f�t�H���g�j
            var source = _GetAudioSource(eType.SE);
            source.PlayOneShot(_data.Clip);
        }

        return true;
    }
}