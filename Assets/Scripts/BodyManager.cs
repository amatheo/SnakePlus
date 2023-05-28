using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField] 
    private SnakePlayer snakePlayer;
    [SerializeField]
    private float _gapBetweenModules = 0.3f;
    
    [SerializeField]
    private List<GameObject> _modulesPrefabs = new List<GameObject>();
    private List<SnakeModule> _modules = new List<SnakeModule>();

    private void Start()
    {
        // Ensure all prefabs have SnakeModule component
        foreach (GameObject modulePrefab in _modulesPrefabs)
        {
            if (modulePrefab.GetComponent<SnakeModule>() == null)
            {
                throw new Exception("All prefabs must have SnakeModule Component");
            }
        }
    }

    private void FixedUpdate()
    {
        BodyHandler();
    }

    /**
     * Add a module to the snake
     * <p> Instantiante a module by a prefab and add it to the snake </p>
     */
    public void AddModule(GameObject module)
    {
        module = _modulesPrefabs[0];
        // Ensure module has SnakeModule component
        if (module.GetComponent<SnakeModule>() == null)
        {
            throw new Exception("Module must have SnakeModule Component");
        }
        
        // Get the last transform of the body parts
        // If the list is empty, use the transform of the head
        Transform lastTransform = snakePlayer.transform;
        if (_modules.Count > 0)
        {
            lastTransform = _modules[_modules.Count - 1].transform;
        }

        // Instantiate module
        GameObject moduleInstance = Instantiate(module, lastTransform.position, lastTransform.rotation);
        _modules.Add(moduleInstance.GetComponent<SnakeModule>());
    }
    
    public void RemoveLastModule()
    {
        _modules.RemoveAt(_modules.Count - 1);
    }
    
    public void BodyHandler()
    {
        
        if (_modules.Count == 0)
        {
            return;
        }
        
        // Snake like movement. All modules follow the previous one, the first one follows the head SnakePlayer
        // Use Rigidbody2D.MovePosition to move the modules. Take into account the gap between modules
        Transform previousTransform = snakePlayer.transform;
        for (int i = 0; i < _modules.Count; i++)
        {
            Rigidbody2D moduleRigidbody2D = _modules[i].Rigidbody2D;
            if (i > 0)
            {
                previousTransform = _modules[i - 1].transform;
            }
            Vector2 newPosition = previousTransform.position;
            float xdiff = previousTransform.position.x - moduleRigidbody2D.position.x;
            float ydiff = previousTransform.position.y - moduleRigidbody2D.position.y;
            Vector2 direction = new Vector2(xdiff, ydiff).normalized;
            
            newPosition += direction * _gapBetweenModules;
            moduleRigidbody2D.MovePosition(newPosition);
        }
    }
}
