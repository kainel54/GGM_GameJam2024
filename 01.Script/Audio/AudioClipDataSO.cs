using UnityEngine;

[System.Serializable]
public enum EAudioName
{
    AreaAttack,
    Bomb,
    EquipItem,
    Fire,
    Laser,
    BGM,
    Megabullet,
    NearAttack,
    UltCharge,
    Dash,
    Hit
}
[System.Serializable]
public enum EAudioType
{
    BGM,
    SFX
}

[CreateAssetMenu(fileName = "ClipDataSO", menuName = "SO/Audio/ClipData")]
public class AudioClipDataSO : ScriptableObject
{
    public EAudioName audioName;
    public EAudioType audioType;
    [Range(0f, 1f)]
    public float volume;
    public float duration;
    [Tooltip("������ �Ѹ� Duration�� ������� �ʽ��ϴ�.")]
    public bool isLoop = false;
    public bool is3D = true;
    public bool isDonDestroy;
    public AudioClip clip;
}
