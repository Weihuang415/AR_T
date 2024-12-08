using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class title_effect : MonoBehaviour
{
    public string randomText = "!<>-_\\/[]{}—=+*^?#________";
    public Color textNormalColor = Color.white; // Final title color
    public Color textRandomColor = Color.gray;  // Scrambled text color

    private Text textControl;
    private List<TitleScrambleData> textScrambles = new List<TitleScrambleData>(); // Renamed list
    private string oldText = "";
    private bool isAnim = false;

    void Start()
    {
        textControl = GetComponent<Text>();
        textControl.color = textNormalColor; // Default color
    }

    public void SetText(string newText)
    {
        if (textControl == null)
            return;

        // Clear existing animation states
        textScrambles.Clear();

        // Prepare new scramble data
        oldText = textControl.text;
        int textLength = Mathf.Max(oldText.Length, newText.Length);

        for (int i = 0; i < textLength; i++)
        {
            TitleScrambleData ts = new TitleScrambleData // Updated class name
            {
                from = i < oldText.Length ? oldText.Substring(i, 1) : "",
                to = i < newText.Length ? newText.Substring(i, 1) : "",
                randomText = randomChar()
            };

            textScrambles.Add(ts);
        }

        // Start the scramble animation
        StartCoroutine(DisplayScrambleEffect());
    }

    private IEnumerator DisplayScrambleEffect()
    {
        isAnim = true;

        for (int frame = 0; frame <= 30; frame++) // Transition over 30 frames
        {
            string outputText = "";

            for (int i = 0; i < textScrambles.Count; i++)
            {
                if (frame >= 30) // Final frame: display the final text
                {
                    outputText += textScrambles[i].to;
                }
                else
                {
                    if (Random.value < 0.5f) // Occasionally change random characters
                    {
                        textScrambles[i].randomText = randomChar();
                    }

                    // Show scrambled characters in a different color
                    outputText += $"<color=#{ColorUtility.ToHtmlStringRGBA(textRandomColor)}>{textScrambles[i].randomText}</color>";
                }
            }

            // Update the text display
            textControl.text = outputText;
            yield return new WaitForSeconds(0.05f); // Delay between frames
        }

        // Set final text and finish animation
        textControl.text = string.Join("", textScrambles.ConvertAll(ts => ts.to));
        isAnim = false;
    }

    private string randomChar()
    {
        return randomText[Random.Range(0, randomText.Length)].ToString();
    }
}

public class TitleScrambleData // Renamed class
{
    public string from;
    public string to;
    public string randomText;
}
