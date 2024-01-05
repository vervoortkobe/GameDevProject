﻿using gamedevproject.Interfaces;
using gamedevproject.LevelClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace gamedevproject.GameStateClasses
{
    public enum GameStates
    {
        STARTSCREEN, LEVEL1, LEVEL2, LEVEL3, VICTORY, GAMEOVER
    }

    public class GameStateManager
    {
        private Level _level1;
        private Level _level2;
        private Level _level3;
        private GameState _gameState;

        #region Loading
        public GameStateManager(IServiceProvider Services)
        {
            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 1)))
                _level1 = new Level(Services, fileStream, 1);

            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 2)))
                _level2 = new Level(Services, fileStream, 2);

            using (Stream fileStream = TitleContainer.OpenStream(string.Format("Content/Levels/Level{0}.txt", 3)))
                _level3 = new Level(Services, fileStream, 3);

            _gameState = new GameState();
        }
        #endregion

        #region Update GameState
        public void Update(GameTime gameTime, GameState gameState)
        {
            switch (gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    _level1.Update(gameTime);
                    break;
                case GameStates.LEVEL2:
                    _level2.Update(gameTime);
                    break;
                case GameStates.LEVEL3:
                    _level3.Update(gameTime);
                    break;
                case GameStates.VICTORY:
                    break;
                case GameStates.GAMEOVER:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Draw GameState
        public void Draw(GameTime gameTime, SpriteBatch _spriteBatch, GameState gameState)
        {
            switch (gameState.GameStateValue)
            {
                case GameStates.STARTSCREEN:
                    break;
                case GameStates.LEVEL1:
                    _level1.Draw(gameTime, _spriteBatch);
                    break;
                case GameStates.LEVEL2:
                    _level2.Update(gameTime);
                    break;
                case GameStates.LEVEL3:
                    _level3.Update(gameTime);
                    break;
                case GameStates.VICTORY:
                    break;
                case GameStates.GAMEOVER:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
