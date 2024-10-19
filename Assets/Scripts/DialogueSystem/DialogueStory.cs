using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueStory : MonoBehaviour
{
    [SerializeField] private Story[] _stories;
    private Dictionary<string, Story> _storyDictionary;
    public event Action<Story> ChangedStory;

    [Serializable]
    public struct Story
    {
        [field: SerializeField] public string Tag { get; private set; }
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public Answer[] Answers { get; private set; }
    }
    [Serializable]
    public struct Answer
    {
        [field: SerializeField] public string Text { get; private set; }
        [field: SerializeField] public string ReposeText { get; private set; }
    }
    private void Start()
    {
        _storyDictionary = _stories.ToDictionary(key => key.Tag, element => element);

        ChangedStory?.Invoke(_stories[0]);

    }
    public void ChangeStory(string tag) => ChangedStory?.Invoke(_storyDictionary[tag]);

}
