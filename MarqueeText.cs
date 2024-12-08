using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarqueeText : MonoBehaviour
{

    [Range(0f, 30f)]
    public float ScrollSpeed = 4;

    [SerializeField]
    [Min(1)]
    int _maxClones = 6;

    public int ScrollDirection = 1; // -1 for right-to-left, 1 for left-to-right

    float _textPreferredWidth;
    readonly LinkedList<RectTransform> _textTransforms = new();

    public TextMeshProUGUI TextMesh => _textTransforms.First.Value.GetComponent<TextMeshProUGUI>();

    public vid_url_test videoController; // Reference to the vid_url_test component

    void Awake()
    {
        _textTransforms.AddFirst((RectTransform)transform.GetChild(0));
        _textPreferredWidth = _textTransforms.First.Value.GetComponent<TextMeshProUGUI>().preferredWidth;

        CreateClones();
    }

    void Update()
    {
        MoveTransforms();
        //ToggleDirection();

    }


    public void ToggleDirection()
    {
        if (videoController.GetCurrentIndex() >= 0) // Assuming valid indices are non-negative
            {
                ScrollDirection *= -1; // Toggle scroll direction
                Debug.Log($"ScrollDirection toggled. New value: {ScrollDirection}");
            }
        else
            {
                Debug.LogWarning("Invalid index, cannot toggle scroll direction.");
            }
    }


    public void UpdateClones()
    {
        RectTransform firstTrans = _textTransforms.First.Value;
        _textTransforms.RemoveFirst();

        foreach (RectTransform rectTrans in _textTransforms)
        {
            Destroy(rectTrans.gameObject);
        }
        _textTransforms.Clear();

        _textTransforms.AddFirst(firstTrans);

        _textPreferredWidth = firstTrans.GetComponent<TextMeshProUGUI>().preferredWidth;
        CreateClones();
    }

    void MoveTransforms()
    {
        float distance = ScrollSpeed * 30 * Time.deltaTime * ScrollDirection;

        foreach (RectTransform transform in _textTransforms)
        {
            Vector3 newPos = transform.localPosition;
            newPos.x += distance;
            transform.localPosition = newPos;
        }

        CheckBounds();
    }

    void CheckBounds()
    {
        RectTransform firstTransform = _textTransforms.First.Value;
        RectTransform lastTransform = _textTransforms.Last.Value;

        // Handle right-to-left scrolling
        if (ScrollDirection == -1 && firstTransform.localPosition.x + _textPreferredWidth <= 0)
        {
            ReattachFirstTransformAtTheEnd();
        }
        // Handle left-to-right scrolling
        else if (ScrollDirection == 1 && lastTransform.localPosition.x >= GetComponent<RectTransform>().rect.width)
        {
            ReattachLastTransformAtTheStart();
        }
    }

    void AttachTransformAtTheEnd(RectTransform rectTransform)
    {
        float lastTransPosX = _textTransforms.Last.Value.localPosition.x;

        Vector3 newPos = rectTransform.localPosition;
        newPos.x = lastTransPosX + _textPreferredWidth;

        rectTransform.localPosition = newPos;
    }

    void ReattachFirstTransformAtTheEnd()
    {
        float lastTransPosX = _textTransforms.Last.Value.localPosition.x;

        LinkedListNode<RectTransform> node = _textTransforms.First;

        Vector3 newPos = node.Value.localPosition;
        newPos.x = lastTransPosX + _textPreferredWidth;
        node.Value.localPosition = newPos;

        _textTransforms.RemoveFirst();
        _textTransforms.AddLast(node);
    }

    void ReattachLastTransformAtTheStart()
    {
        float firstTransPosX = _textTransforms.First.Value.localPosition.x;

        LinkedListNode<RectTransform> node = _textTransforms.Last;

        Vector3 newPos = node.Value.localPosition;
        newPos.x = firstTransPosX - _textPreferredWidth;
        node.Value.localPosition = newPos;

        _textTransforms.RemoveLast();
        _textTransforms.AddFirst(node);
    }

    void CreateClones()
    {
        int clones = CalculateNecessaryClones();

        for (int i = 1; i <= clones; i++)
        {
            RectTransform cloneTransform = Instantiate(_textTransforms.First.Value, transform);
            AttachTransformAtTheEnd(cloneTransform);
            _textTransforms.AddLast(cloneTransform);
        }
    }

    int CalculateNecessaryClones()
    {
        int clones = 0;
        RectTransform maskTransform = GetComponent<RectTransform>();

        do
        {
            clones++;

            if (clones == _maxClones)
            {
                Debug.LogWarning($"Scrolling Text stopped after {_maxClones} clones, increase the limit if necessary");
                break;
            }
        }
        while (maskTransform.rect.width / (_textPreferredWidth * clones) >= 1);

        return clones;
    }
}
