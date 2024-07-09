using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        CheckForPlayers();
    }

    private void CheckForPlayers()
    {
        // Find all game objects with the "Player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Check if there are any active players
        bool anyPlayerActive = false;
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                anyPlayerActive = true;
                break;
            }
        }

        // If no active players are found, restart the game
        if (!anyPlayerActive)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Reload the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}