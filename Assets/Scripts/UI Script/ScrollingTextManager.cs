using UnityEngine;
using System.Collections;
using TMPro;
 
public class ScrollingTextManager : MonoBehaviour {
 
    public TextMeshProUGUI TextMeshProComponent;
    public float scrollSpeed = 5;
 
    private TextMeshProUGUI m_cloneTextObject;
 
    private RectTransform m_textRectTransform;
    private string sourceText;
    private string tempText;
 
    void Awake(){
        m_textRectTransform = TextMeshProComponent.GetComponent<RectTransform>();
    }
 
    // Use this for initialization
    IEnumerator Start () {
        float width = TextMeshProComponent.preferredWidth;
        Vector3 startPosition = m_textRectTransform.position;
 
        float scrollPosition =-9 ;
 
        while (true){
            // Re-Compute the width of the RectTransform if the text object has changed
            if (TextMeshProComponent.havePropertiesChanged){
                width = TextMeshProComponent.preferredWidth;
            }
 
            // Scroll the text across the screen by moving the RectTransform
            
 
            scrollPosition = scrollPosition + (scrollSpeed *Time.deltaTime);
            
            m_textRectTransform.position = new Vector3(-scrollPosition, startPosition.y,startPosition.z);
            if(scrollPosition>37){
                scrollPosition=-9;
            }
            //print(scrollPosition);

            yield return null;
        }
    }
}