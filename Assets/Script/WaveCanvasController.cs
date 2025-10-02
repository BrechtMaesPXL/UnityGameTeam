// using UnityEngine;
// using UnityEngine.UI;

// public class WaveCanvasController : MonoBehaviour
// {
//     public Button nextButton;           
//     private GameManager gameManager;
//     public  GameManager Instance;

//     void Awake()
//     {
//         gameManager = GameManager.Instance;

//         if (nextButton != null)
//             nextButton.onClick.AddListener(OnNextClicked);
//         else
//             Debug.LogError("NextButton is not assigned in WaveCanvasController!");

//         if (gameManager == null)
//             Debug.LogError("GameManager.Instance is null! Make sure GameManager exists in the scene.");

//         gameObject.SetActive(false);
//     }

//     public void ShowCanvas()
//     {
//         gameObject.SetActive(true);
//     }

//     public void HideCanvas()
//     {
//         gameObject.SetActive(false);
//     }

//     private void OnNextClicked()
//     {
//         HideCanvas();
//         gameManager.NextWave();
//         gameManager.StartGame(); 
//     }
// }
