using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    // Singletons
    public static Message M;
    
    // Component references
    [SerializeField] private Text textComponent;
    private Animator _animator;

    // Audio
    [SerializeField] private AudioSource endMessageAudioSource;
    [SerializeField] private AudioSource typedLetterAudioSource;
    [SerializeField] private List<AudioClip> typedSounds;
    
    // variables
    private string _messageText;
    private bool _isTypewriter;
    private int _typewriterCurrentIndex;
    private bool _shown;
    private float _totalTime;
    private static string _displayingText;
    private float _currentTime;
    [SerializeField] private float timePerLetter;
    [SerializeField] private bool ready;
    
    // Hashes
    private static readonly int In = Animator.StringToHash("FadeIn");
    private static readonly int Out = Animator.StringToHash("FadeOut");
    
    // Controls
    [SerializeField] private KeyCode[] acceptMessage = 
    {
        KeyCode.Space
    }; 

    // Events
    public delegate void MessageAcceptedEventHandler(object source, EventArgs args);
    public static event MessageAcceptedEventHandler MessageAccepted;
    
    private void Start()
    {
        M = this;
        
        _animator = GetComponent<Animator>();
    }

    public static void NewMessage(string text, bool isTypewriter = false)
    {
        if(!M._shown) FadeIn();
        
        M._isTypewriter = isTypewriter;
        
        if (isTypewriter)
        {
            M.StartTypewriter(text);
        }
        else
        {
            M.textComponent.text = text;
        }
    }

    

    private void StartTypewriter(string text)
    {
        _displayingText = text;

        _typewriterCurrentIndex = 0;
        _totalTime = timePerLetter * text.Length;
        _currentTime = 0f;
        ready = false;
    }
    
    
    private void Typewriter()
    {
        var showText = "";
        _currentTime += Time.unscaledDeltaTime;

        if ((_currentTime / timePerLetter) > _typewriterCurrentIndex)
        {
            var r = UnityEngine.Random.Range(0, typedSounds.Count);

            typedLetterAudioSource.Stop();
            typedLetterAudioSource.clip = typedSounds[r];
            typedLetterAudioSource.Play();
        }
        
        if (_currentTime > _totalTime) showText = _displayingText;
        else
        {
            for (var i = 0; i < _currentTime / timePerLetter; i++) showText += _displayingText[i];
        }

        //textComponent.text = showText.ToUpper();
        textComponent.text = showText;

        if (_currentTime > _totalTime)
        {
            ready = true;
        }
    }

    private void Update()
    {
        if (!_shown) return;
        if (_isTypewriter)
        {
            if (ready)
            {
                if (CanAccept())
                {
                    OnMessageAccepted(this);
                }
            }
            else
            {
                if (CanAccept())
                {
                    ready = true;
                    _currentTime = _totalTime;
                }
                Typewriter();
            }
        }
        else
        {
            if (CanAccept())
            {
                OnMessageAccepted(this);
            }
        }
    }

    private bool CanAccept()
    {
        foreach (var key in acceptMessage)
        {
            if (Input.GetKeyDown(key))
            {
                if (endMessageAudioSource) endMessageAudioSource.Play();
                return true;
            }
        }

        return false;
    }

    public static void FadeIn()
    {
        M._animator.SetTrigger(In);
        M._shown = true;
    }

    public static void FadeOut()
    {
        M._animator.SetTrigger(Out);
        M._shown = false;
    }
    protected virtual void OnMessageAccepted(object source)
    {
        MessageAccepted?.Invoke(source, EventArgs.Empty);
    }

}
