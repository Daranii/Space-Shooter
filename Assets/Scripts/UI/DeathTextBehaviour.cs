using System.Collections;
using Helper;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeathTextBehaviour : MonoBehaviour
    {
        private Coroutine _flickerCoroutine;
        private Text _textComponent;

        private void OnEnable()
        {
            if(!_textComponent) _textComponent = gameObject.GetComponent<Text>();
            _flickerCoroutine = StartCoroutine(Flicker());
        }

        private void OnDisable()
        {
            StopCoroutine(_flickerCoroutine);
        }

        private IEnumerator Flicker()
        {
            while (true)
            {
                _textComponent.text = "GAME OVER";
            
                yield return new WaitForSeconds(UiValues.FlickerTimeInSeconds);

                _textComponent.text = "";
            
                yield return new WaitForSeconds(UiValues.FlickerTimeInSeconds);
            }
        }
    }
}