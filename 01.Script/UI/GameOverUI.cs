using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button _titleBtn, _retryBtn;
    [SerializeField] private TextMeshProUGUI _point, _comp, _level, _wave;
    [SerializeField] private GameObject _gameOverPannel;

    private void Awake()
    {
        _titleBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale / 200;
            SceneManager.LoadScene("TitleScene");
        });
        _retryBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale / 200;
            SceneManager.LoadScene("GameScene");
        });
    }

    public void Open()
    {
        _point.text = "���� ���� �� : " + PlayerManager.Instance.CurrentPlayerPoint;
        _comp.text = "���� ���� Ƚ�� : " + PlayerManager.Instance.CurrentPlayerReShapeCount;
        _level.text = "������ ���� : " + PlayerManager.Instance.CurrentPlayerLevel;
        _wave.text = WaveManager.Instance.waveCount - 1 + " WAVE";

        _gameOverPannel.SetActive(true);
    }
}
