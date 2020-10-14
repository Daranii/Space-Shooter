using System.Collections.Generic;
using Entities;
using Helper;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UiManager : BehaviourSingleton<UiManager>
    {
        [SerializeField] private Player playerScript;
        [SerializeField] private List<Sprite> livesSprites = new List<Sprite>();

        private GameObject _playUi;
        private GameObject _deathUi;
        private Image _livesImage;
        private Text _scoreNumber;

        private void Start()
        {
            CreateUIContainers();
            CreatePlayUI();
            CreateDeathUI();
            playerScript.SetOnPlayerDeath(OnPlayerDeath);
        }

        public void UpdateScore(int value)
        {
            _scoreNumber.text = value.ToString();
        }

        public void UpdateLives(int value)
        {
            _livesImage.sprite = livesSprites[value];
        }

        private void CreateUIContainers()
        {
            _playUi = GameObjectWithParent("PlayUI", transform)
                .AddRectTransform(Presets.Stretch, Vector2.zero, Vector2.zero);
            _deathUi = GameObjectWithParent("DeathUI", transform)
                .AddRectTransform(Presets.Stretch, Vector2.zero, Vector2.zero);
            _deathUi.SetActive(false);
        }

        private void CreatePlayUI()
        {
            // Current hardcoded values, will be determined via code later on
            GameObjectWithParent("ScoreText", _playUi.transform)
                .AddRectTransform(Presets.TopRight, new Vector2(70, 25), anchoredPosition: new Vector2(-155, -30))
                .AddText("Score:", Color.white, TextAnchor.MiddleCenter, UiValues.ScoreFontSize);

            _scoreNumber = GameObjectWithParent("ScoreNumber", _playUi.transform)
                .AddRectTransform(Presets.TopRight, new Vector2(100, 25), anchoredPosition: new Vector2(-70, -30))
                .AddText("0", Color.white, TextAnchor.MiddleCenter, UiValues.ScoreFontSize);

            _livesImage = GameObjectWithParent("LivesDisplay", _playUi.transform)
                .AddRectTransform(Presets.BottomLeft, new Vector2(75, 37), anchoredPosition: new Vector2(37.5f, 18.5f))
                .AddImage(livesSprites[PlayerValues.MaxLives]);
        }

        private void CreateDeathUI()
        {
            // Current hardcoded values, will be determined via code later on
            GameObjectWithParent("GameOverText", _deathUi.transform)
                .AddRectTransform(Presets.Centered, new Vector2(150, 150))
                .AddText("GAME OVER", Color.red, TextAnchor.MiddleCenter, UiValues.GameOverFontSize)
                .gameObject.AddComponent<DeathTextBehaviour>();
        }

        private static GameObject GameObjectWithParent(string objName, Transform parent)
        {
            var playUi = new GameObject { name = objName };
            playUi.transform.parent = parent;
            
            return playUi;
        }
        
        
        private void OnPlayerDeath()
        {
            _playUi.SetActive(false);
            _deathUi.SetActive(true);
        }
    }
}