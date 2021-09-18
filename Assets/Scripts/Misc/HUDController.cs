using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The part of the health that decreases")]
    private RectTransform m_HealthBar;

    [SerializeField]
    [Tooltip("The text component housing the current score")]
    private Text m_CurrentScore;
    #endregion

    #region Private Variables
    private float p_HealthBarOrigWidth;
    private string p_DefaultCurrentScoreText;
    #endregion

    #region Initialization
    private void Awake() {
    	p_HealthBarOrigWidth = m_HealthBar.sizeDelta.x;
    	p_DefaultCurrentScoreText = m_CurrentScore.text;
    }
    #endregion

    #region Main Updates
    private void Update() {
    	UpdateCurrentScore();
    }
    #endregion

    #region Update Health m_HealthBar
    public void UpdateHealth(float percent) {
    	m_HealthBar.sizeDelta = new Vector2(p_HealthBarOrigWidth * percent, m_HealthBar.sizeDelta.y);
    }
    #endregion

    #region Current Score Methods
    private void UpdateCurrentScore() {
    	m_CurrentScore.text = p_DefaultCurrentScoreText.Replace("%S", ScoreManager.singleton.GetCurScore().ToString());
    }
    #endregion
}
