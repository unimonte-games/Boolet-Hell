using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using Object = System.Object;

public class MessageTeleporter : MonoBehaviour
{
    private bool _isActive;
    
    [SerializeField] private int _currentIndex;
    [SerializeField] private int _currentPostIndex;
    [SerializeField] private bool isTypewriter;
    
    [Space(10f)]
    [Tooltip("Lista de mensagens que serao demonstradas antes das acoes de teleporte"), SerializeField]
    private List<string> messagesPreTeleport;
    [Tooltip("Lista de mensagens que serao demonstradas depois das acoes de teleporte"), SerializeField]
    private List<string> messagesPostTeleport;

    [Space(10f)]
    [Tooltip("Lista de objetos que serao destruidos entre o pre e o post"),SerializeField]
    private List<GameObject> objectsToDestroyMiddle;
    [Tooltip("Lista de objetos que aparecerao entre o pre e o post"), SerializeField]
    private List<GameObject> nextShownObjectsMiddle;
    
    [Space(10f)]
    [Tooltip("Lista de objetos que serao destruidos no final da execucao"),SerializeField]
    private List<GameObject> objectsToDestroyPost;
    [Tooltip("Lista de objetos que aparecerao no final da execucao"), SerializeField]
    private List<GameObject> nextShownObjectsPost;
    
    private void StartMessage()
    {
        if(_isActive) return;
        _isActive = true;
        
        _currentIndex = 0;
        _currentPostIndex = 0;
        
        // TODO adicionar no jogador um bool que trave todo o movimento ou testar trocando tirando o comentario abaixo
        Time.timeScale = 0f; // Esse metodo pode funcionar, porem pode bugar os tiros. Preferivel de se colocar um bool em todas as entidades e travar ela aqui
        
        Message.MessageAccepted += NextAction;
        
        NextAction(null, EventArgs.Empty);
    }

    private void NextMessage(bool post = false)
    {
        // Dispara a proxima mensagem da lista atual (preTeleport ou PostTeleport)
        Message.NewMessage(post ? messagesPostTeleport[_currentPostIndex] : messagesPreTeleport[_currentIndex], isTypewriter);
    }

    private void NextAction(object obj, EventArgs args)
    {
        if (_currentIndex < messagesPreTeleport.Count)
        {
            NextMessage();
            _currentIndex++;
        }
        else if (_currentPostIndex < messagesPostTeleport.Count)
        {
            if (_currentPostIndex == 0)
            {
                MiddleEvents();
            }
            NextMessage(true);
            _currentPostIndex++;
        }
        else
        {
            FinishMessages();
        }
    }

    private void MiddleEvents()
    {
        foreach (var obj in objectsToDestroyMiddle)
        {
            Destroy(obj);
        }

        foreach (var obj in nextShownObjectsMiddle)
        {
            obj.SetActive(true);
        }
    }
    
    private void FinishMessages()
    {
        Message.FadeOut();
        _isActive = false;
        Time.timeScale = 1f;
        
        foreach (var obj in objectsToDestroyPost)
        {
            Destroy(obj);
        }

        foreach (var obj in nextShownObjectsPost)
        {
            obj.SetActive(true);
        }
        Message.MessageAccepted -= NextAction;
    }
    
    // TODO O jogo de vocês é em 3D, remova os 2D da função e do parametro
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartMessage();
        }
    }

    private void OnDestroy()
    {
        try
        {
            Message.MessageAccepted -= NextAction;
            Time.timeScale = 1f;
        }
        catch
        {
            // ignored
        }
    }
}
