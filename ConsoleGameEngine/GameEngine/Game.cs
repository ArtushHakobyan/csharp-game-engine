﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace GameEngine
{
    public delegate void KeyPressEvent(GameObjects gameObjects);
    /// <summary>
    /// The main Game class.
    /// Handles game process
    /// </summary>
    public class Game
    {
        private GameObjects gameObjects = new GameObjects();
        private bool gameEnd = false;

        public int FPS { get; set; }
        /// <summary>
        /// Adds new game object to main gameObject list.
        /// </summary>
        /// <param name="gameObject"></param>
        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        /// <summary>
        /// Removes the game object.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool Remove(GameObject gameObject)
        {
            return gameObjects.Remove(gameObject);
        }
        /// <summary>
        /// Starts the game cycle
        /// </summary>
        public void Start()
        {
            foreach (GameObject item in gameObjects)
            {
                item.Start();
            }

            while (!gameEnd)
            {
                Console.Clear();
                Update();
                Render();
                Thread.Sleep(1000/FPS);
            }
        }
        /// <summary>
        /// Updates the frame.
        /// </summary>
        public void Update()
        {
            foreach (GameObject obj1 in gameObjects)
            {
                foreach (GameObject obj2 in gameObjects)
                {
                    if(!obj1.Equals(obj2) && obj1.Pos == obj2.Pos)
                    {
                        obj2.Collision(obj1);
                    }
                }
            }
            foreach (GameObject item in gameObjects)
            {
                item.Update();
            }
        }
        /// <summary>
        /// Rendering game.
        /// </summary>
        public void Render()
        {
            foreach (GameObject item in gameObjects)
            {
                item.Render();
            }
        }
        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            gameEnd = true;
        }
        /// <summary>
        /// Destroying object.
        /// Removes game object from gameObjects list.
        /// </summary>
        /// <param name="obj"></param>
        public void DestroyObject(GameObject obj)
        {
            obj.Destroy();
            gameObjects.Remove(obj);
        }
    }
}
