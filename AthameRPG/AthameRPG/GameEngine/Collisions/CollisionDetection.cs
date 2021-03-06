﻿namespace AthameRPG.GameEngine.Collisions
{
    using System;
    using System.Collections.Generic;
    using AthameRPG.Contracts;
    using AthameRPG.Controls;
    using AthameRPG.GameEngine.Managers;
    using AthameRPG.Objects.Characters.Heroes;
    using AthameRPG.Objects.Characters.WarUnits;
    using AthameRPG.Objects.Maps;
    using AthameRPG.Objects.Weapons.Arrows;
    using Microsoft.Xna.Framework;

    public static class CollisionDetection
    {
        private static int minPixelCollison = 4;

        public static float WarUnitGoUp(IDraw currentUnit, float moveSpeed, IReadOnlyDictionary<WarUnit, decimal> playerUnits, IReadOnlyDictionary<WarUnit, decimal> enemyUnits)
        {
            float unitTop;
            float unitBottom;
            float unitLeft;
            float unitRight;

            float pUp = currentUnit.DrawCoord.Y;
            float pDown = currentUnit.DrawCoord.Y + currentUnit.CropHeight;
            float pLeft = currentUnit.DrawCoord.X;
            float pRight = currentUnit.DrawCoord.X + currentUnit.CropWidth;

            if (pUp - moveSpeed <= 0)
            {
                return 0;
            }

            foreach (var unit in playerUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pUp, unitBottom, pLeft, unitRight, pRight, unitLeft, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            foreach (var unit in enemyUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pUp, unitBottom, pLeft, unitRight, pRight, unitLeft, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            return moveSpeed;
        }

        public static float WarUnitGoDown(IDraw currentUnit, float moveSpeed, IReadOnlyDictionary<WarUnit, decimal> playerUnits, IReadOnlyDictionary<WarUnit, decimal> enemyUnits)
        {
            float unitTop;
            float unitBottom;
            float unitLeft;
            float unitRight;

            float pUp = currentUnit.DrawCoord.Y;
            float pDown = currentUnit.DrawCoord.Y + currentUnit.CropHeight;
            float pLeft = currentUnit.DrawCoord.X;
            float pRight = currentUnit.DrawCoord.X + currentUnit.CropWidth;

            if ( pDown + moveSpeed >= ScreenManager.SCREEN_HEIGHT)
            {
                return 0;
            }

            foreach (var unit in playerUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pDown, unitTop, pLeft, unitRight, pRight, unitLeft, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            foreach (var unit in enemyUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pDown, unitTop, pLeft, unitRight, pRight, unitLeft, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            return moveSpeed;
        }

        public static float WarUnitGoRight(IDraw currentUnit, float moveSpeed, IReadOnlyDictionary<WarUnit, decimal> playerUnits, IReadOnlyDictionary<WarUnit, decimal> enemyUnits)
        {
            float unitTop;
            float unitBottom;
            float unitLeft;
            float unitRight;

            float pUp = currentUnit.DrawCoord.Y;
            float pDown = currentUnit.DrawCoord.Y + currentUnit.CropHeight;
            float pLeft = currentUnit.DrawCoord.X;
            float pRight = currentUnit.DrawCoord.X + currentUnit.CropWidth;

            if (pRight + moveSpeed >= ScreenManager.SCREEN_WIDTH)
            {
                return 0;
            }

            foreach (var unit in playerUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pRight, unitLeft, pUp, unitBottom, pDown, unitTop, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            foreach (var unit in enemyUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pRight, unitLeft, pUp, unitBottom, pDown, unitTop, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            return moveSpeed;
        }

        public static float WarUnitGoLeft(IDraw currentUnit, float moveSpeed, IReadOnlyDictionary<WarUnit, decimal> playerUnits, IReadOnlyDictionary<WarUnit, decimal> enemyUnits)
        {
            float unitTop;
            float unitBottom;
            float unitLeft;
            float unitRight;

            float pUp = currentUnit.DrawCoord.Y;
            float pDown = currentUnit.DrawCoord.Y + currentUnit.CropHeight;
            float pLeft = currentUnit.DrawCoord.X;
            float pRight = currentUnit.DrawCoord.X + currentUnit.CropWidth;

            if (pLeft - moveSpeed <= 0)
            {
                return 0;
            }

            foreach (var unit in playerUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pLeft, unitRight, pUp, unitBottom, pDown, unitTop, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            foreach (var unit in enemyUnits.Keys)
            {
                unitTop = unit.DrawCoord.Y;
                unitBottom = unit.DrawCoord.Y + unit.CropHeight;
                unitLeft = unit.DrawCoord.X;
                unitRight = unit.DrawCoord.X + unit.CropWidth;

                moveSpeed = HaveCollision(pLeft, unitRight, pUp, unitBottom, pDown, unitTop, moveSpeed);

                if (moveSpeed == 0)
                {
                    return 0;
                }
            }

            return moveSpeed;
        }

        public static float GoUp(Vector2 playerPositon, float moveSpeedPlayer, Vector2 coordPlayer, int cropWidth, int cropHeight)
        {
            float result = moveSpeedPlayer;

            foreach (Vector2 coordinates in Map.Obstacles)
            {

                float mapDetectionFromTop = coordinates.Y + playerPositon.Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + playerPositon.Y;
                float mapDetectionFromLeft = coordinates.X + playerPositon.X;//
                float mapDetectionFromRight = coordinates.X + 50f + playerPositon.X;

                float pUp = coordPlayer.Y;
                float pDown = coordPlayer.Y + cropHeight;
                float pLeft = coordPlayer.X;
                float pRight = coordPlayer.X + cropWidth;


                /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                result = HaveCollision(pUp, mapDetectionFromBottom, pLeft, mapDetectionFromRight, pRight, mapDetectionFromLeft, moveSpeedPlayer);

                if (result == 0)
                {
                    result = 0;
                    break;
                }

            }

            if (result != 0)
            {
                int count = 0;

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    
                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + Enemy.cropHeight;
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + Enemy.cropWidth;

                    float pUp = coordPlayer.Y;
                    float pDown = coordPlayer.Y + cropHeight;
                    float pLeft = coordPlayer.X;
                    float pRight = coordPlayer.X + cropWidth;

                    count++;

                    /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                    result = HaveCollision(pUp, enemyBottom, pLeft, enemyRight, pRight, enemyLeft, moveSpeedPlayer);

                    if (result == 0)
                    {
                        result = 0;
                        break;
                    }

                }
            }


            return result;
        }

        public static float GoDown(Vector2 playerPositon, float moveSpeedPlayer, Vector2 coordPlayer, int cropWidth, int cropHeight)
        {
            float result = moveSpeedPlayer;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + playerPositon.Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + playerPositon.Y;
                float mapDetectionFromLeft = coordinates.X + playerPositon.X;//
                float mapDetectionFromRight = coordinates.X + 50f + playerPositon.X;

                float pUp = coordPlayer.Y;
                float pDown = coordPlayer.Y + cropHeight;
                float pLeft = coordPlayer.X;
                float pRight = coordPlayer.X + cropWidth;

                result = HaveCollision(pDown, mapDetectionFromTop, pLeft, mapDetectionFromRight, pRight, mapDetectionFromLeft, moveSpeedPlayer);

                if (result == 0)
                {
                    break;
                }
            }

            if (result != 0)
            {
                int count = 0;

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    count++;

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + Enemy.cropHeight;
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + Enemy.cropWidth;

                    float pUp = coordPlayer.Y;
                    float pDown = coordPlayer.Y + cropHeight;
                    float pLeft = coordPlayer.X;
                    float pRight = coordPlayer.X + cropWidth;

                    /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                    result = HaveCollision(pDown, enemyTop, pLeft, enemyRight, pRight, enemyLeft, moveSpeedPlayer);

                    if (result == 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public static float GoLeft(Vector2 playerPositon, float moveSpeedPlayer, Vector2 coordPlayer, int cropWidth, int cropHeight)
        {
            float result = moveSpeedPlayer;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + playerPositon.Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + playerPositon.Y;
                float mapDetectionFromLeft = coordinates.X + playerPositon.X;//
                float mapDetectionFromRight = coordinates.X + 50f + playerPositon.X;

                float pUp = coordPlayer.Y;
                float pDown = coordPlayer.Y + cropHeight;
                float pLeft = coordPlayer.X;
                float pRight = coordPlayer.X + cropWidth;

                result = HaveCollision(pLeft, mapDetectionFromRight, pUp, mapDetectionFromBottom, pDown, mapDetectionFromTop, moveSpeedPlayer);

                if (result == 0)
                {
                    break;
                }

            }
            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + Enemy.cropHeight;
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + Enemy.cropWidth;

                    float pUp = coordPlayer.Y;
                    float pDown = coordPlayer.Y + cropHeight;
                    float pLeft = coordPlayer.X;
                    float pRight = coordPlayer.X + cropWidth;

                    /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                    result = HaveCollision(pLeft, enemyRight, pUp, enemyBottom, pDown, enemyTop, moveSpeedPlayer);

                    if (result == 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public static float GoRight(Vector2 playerPositon, float moveSpeedPlayer, Vector2 coordPlayer, int cropWidth, int cropHeight)
        {
            float result = moveSpeedPlayer;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + playerPositon.Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + playerPositon.Y;
                float mapDetectionFromLeft = coordinates.X + playerPositon.X;//
                float mapDetectionFromRight = coordinates.X + 50f + playerPositon.X;

                float pUp = coordPlayer.Y;
                float pDown = coordPlayer.Y + cropHeight;
                float pLeft = coordPlayer.X;
                float pRight = coordPlayer.X + cropWidth;

                /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                result = HaveCollision(pRight, mapDetectionFromLeft, pUp, mapDetectionFromBottom, pDown, mapDetectionFromTop, moveSpeedPlayer);

                if (result == 0)
                {
                    break;
                }

            }
            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + Enemy.cropHeight;
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + Enemy.cropWidth;

                    float pUp = coordPlayer.Y;
                    float pDown = coordPlayer.Y + cropHeight;
                    float pLeft = coordPlayer.X;
                    float pRight = coordPlayer.X + cropWidth;

                    /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                    result = HaveCollision(pRight, enemyLeft, pUp, enemyBottom, pDown, enemyTop, moveSpeedPlayer);

                    if (result == 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public static float EnemyGoUp(Vector2 DetectionEnemyCoord, Vector2 drawCoordEnemy, int cropHeight, int cropWidth, float moveSpeedEnemy)
        {
            float result = moveSpeedEnemy;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromLeft = coordinates.X + CharacterManager.barbarian.CoordP().X;
                float mapDetectionFromRight = coordinates.X + 50f + CharacterManager.barbarian.CoordP().X;

                float pUp = DetectionEnemyCoord.Y;
                float pDown = DetectionEnemyCoord.Y + cropHeight;
                float pLeft = DetectionEnemyCoord.X;
                float pRight = DetectionEnemyCoord.X + cropWidth;

                result = HaveCollision(pUp, mapDetectionFromBottom, pLeft, mapDetectionFromRight, pRight, mapDetectionFromLeft, moveSpeedEnemy);

                if (result == 0)
                {
                    break;
                }

            }

            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    //if (drawCoordGargamel.X != enemy.X && drawCoordGargamel.Y != enemy.Y )
                    // Does not WORK with this ckeck ...
                    // when there are on same X ... they don't detect collision

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + (cropHeight);
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + (cropWidth);

                    float pUp = drawCoordEnemy.Y;
                    float pDown = drawCoordEnemy.Y + cropHeight;
                    float pLeft = drawCoordEnemy.X;
                    float pRight = drawCoordEnemy.X + cropWidth;

                    ////////////////////// if (1 -2) ...... if (3 > 4) ||   (5 lower than 6) 
                    result = HaveCollision(pUp, enemyBottom, pLeft, enemyRight, pRight, enemyLeft, moveSpeedEnemy);

                    if (result == 0)
                    {
                        break;
                    }

                }
            }

            if (result != 0)
            {
                result = DetectionWithPlayerEnemyGoesUp(moveSpeedEnemy, drawCoordEnemy, cropWidth, cropHeight);
            }
            
            return result;
        }
        
        public static float EnemyGoDown(Vector2 DetectionEnemyCoord, Vector2 drawCoordEnemy, int cropHeight, int cropWidth, float moveSpeedEnemy)
        {
            float result = moveSpeedEnemy;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromLeft = coordinates.X + CharacterManager.barbarian.CoordP().X;
                float mapDetectionFromRight = coordinates.X + 50f + CharacterManager.barbarian.CoordP().X;

                float pUp = DetectionEnemyCoord.Y;
                float pDown = DetectionEnemyCoord.Y + cropHeight;
                float pLeft = DetectionEnemyCoord.X;
                float pRight = DetectionEnemyCoord.X + cropWidth;

                result = HaveCollision(pDown, mapDetectionFromTop, pLeft, mapDetectionFromRight, pRight, mapDetectionFromLeft, moveSpeedEnemy);

                if (result == 0)
                {
                    break;
                }

            }

            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    //if (drawCoordGargamel.X != enemy.X && drawCoordGargamel.Y != enemy.Y )
                    // Does not WORK with this ckeck ...
                    // when there are on same X ... they don't detect collision

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + (cropHeight);
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + (cropWidth);

                    float pUp = drawCoordEnemy.Y;
                    float pDown = drawCoordEnemy.Y + cropHeight;
                    float pLeft = drawCoordEnemy.X;
                    float pRight = drawCoordEnemy.X + cropWidth;

                    ////////////////////// if (1 -2) ...... if (3 > 4) ||   (5 lower than 6) 
                    result = HaveCollision(pDown, enemyTop, pLeft, enemyRight, pRight, enemyLeft, moveSpeedEnemy);

                    if (result == 0)
                    {
                        break;
                    }

                }
            }

            if (result != 0)
            {
                result = DetectionWithPlayerEnemyGoesDown(moveSpeedEnemy, drawCoordEnemy, cropWidth, cropHeight);
            }
            return result;
        }

        public static float EnemyGoLeft(Vector2 DetectionEnemyCoord, Vector2 drawCoordEnemy, int cropHeight, int cropWidth, float moveSpeedEnemy)
        {
            float result = moveSpeedEnemy;

            foreach (Vector2 coordinates in Map.Obstacles)
            {
                float mapDetectionFromTop = coordinates.Y + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromLeft = coordinates.X + CharacterManager.barbarian.CoordP().X;
                float mapDetectionFromRight = coordinates.X + 50f + CharacterManager.barbarian.CoordP().X;

                float pUp = DetectionEnemyCoord.Y;
                float pDown = DetectionEnemyCoord.Y + cropHeight;
                float pLeft = DetectionEnemyCoord.X;
                float pRight = DetectionEnemyCoord.X + cropWidth;

                result = HaveCollision(pLeft, mapDetectionFromRight, pUp, mapDetectionFromBottom, pDown, mapDetectionFromTop, moveSpeedEnemy);

                if (result == 0)
                {
                    break;
                }

            }
            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    //if (drawCoordGargamel.X != enemy.X && drawCoordGargamel.Y != enemy.Y )
                    //{

                    //}

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + (cropHeight);
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + (cropWidth);

                    float pUp = drawCoordEnemy.Y;
                    float pDown = drawCoordEnemy.Y + cropHeight;
                    float pLeft = drawCoordEnemy.X;
                    float pRight = drawCoordEnemy.X + cropWidth;

                    /// if (1 -2) ...... if 3 > 4 | 5 lower than 6 
                    result = HaveCollision(pLeft, enemyRight, pUp, enemyBottom, pDown, enemyTop, moveSpeedEnemy);

                    if (result == 0)
                    {
                        break;
                    }

                }
            }

            if (result != 0)
            {
                result = DetectionWithPlayerEnemyGoesLeft(moveSpeedEnemy, drawCoordEnemy, cropWidth, cropHeight);
            }
            return result;
        }
        
        public static float EnemyGoRight(Vector2 DetectionEnemyCoord, Vector2 drawCoordEnemy, int cropHeight, int cropWidth, float moveSpeedEnemy)
        {
            float result = moveSpeedEnemy;

            foreach (Vector2 coordinates in Map.Obstacles)
            {


                float mapDetectionFromTop = coordinates.Y + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromBottom = coordinates.Y + 50f + CharacterManager.barbarian.CoordP().Y;
                float mapDetectionFromLeft = coordinates.X + CharacterManager.barbarian.CoordP().X;
                float mapDetectionFromRight = coordinates.X + 50f + CharacterManager.barbarian.CoordP().X;

                float pUp = DetectionEnemyCoord.Y;
                float pDown = DetectionEnemyCoord.Y + cropHeight;
                float pLeft = DetectionEnemyCoord.X;
                float pRight = DetectionEnemyCoord.X + cropWidth;

                result = HaveCollision(mapDetectionFromLeft, pRight, pUp, mapDetectionFromBottom, pDown, mapDetectionFromTop, moveSpeedEnemy);

                if (result == 0)
                {
                    break;
                }

            }

            if (result != 0)
            {

                foreach (var enemy in CharacterManager.EnemiesPositionList)
                {
                    //if (drawCoordGargamel.X != enemy.X && drawCoordGargamel.Y != enemy.Y )
                    // Does not WORK with this ckeck ...
                    // when there are on same X ... they don't detect collision

                    float enemyTop = enemy.Value.Y;
                    float enemyBottom = enemy.Value.Y + (cropHeight);
                    float enemyLeft = enemy.Value.X;
                    float enemyRight = enemy.Value.X + (cropWidth);

                    float pUp = drawCoordEnemy.Y;
                    float pDown = drawCoordEnemy.Y + cropHeight;
                    float pLeft = drawCoordEnemy.X;
                    float pRight = drawCoordEnemy.X + cropWidth;

                    ////////////////////// if (1 -2) ...... if (3 > 4) ||   (5 lower than 6) 
                    result = HaveCollision(pRight, enemyLeft, pUp, enemyBottom, pDown, enemyTop, moveSpeedEnemy);

                    if (result == 0)
                    {
                        break;
                    }

                }
            }

            if (result != 0)
            {
                result = DetectionWithPlayerEnemyGoesRight(moveSpeedEnemy, drawCoordEnemy, cropWidth, cropHeight);
            }
            return result;
        }

        private static float DetectionWithPlayerEnemyGoesUp(float moveSpeedEnemy, Vector2 drawCoordEnemy, int cropWidth, int cropHeight)
        {

            float playerTop = Character.DrawCoordPlayer.Y;
            float playerBottom = Character.DrawCoordPlayer.Y + Character.PlayerCropHeight;
            float playerLeft = Character.DrawCoordPlayer.X;
            float playerRight = Character.DrawCoordPlayer.X + Character.PlayerCropWidth;

            float enemyTop = drawCoordEnemy.Y;
            float enemyBottom = drawCoordEnemy.Y + cropHeight;
            float enemyLeft = drawCoordEnemy.X;
            float enemyRight = drawCoordEnemy.X + cropWidth;

            moveSpeedEnemy = HaveCollision(enemyTop, playerBottom, enemyLeft, playerRight, enemyRight, playerLeft, moveSpeedEnemy);

            return moveSpeedEnemy;
        }

        private static float DetectionWithPlayerEnemyGoesDown(float moveSpeedEnemy, Vector2 drawCoordEnemy, int cropWidth, int cropHeight)
        {

            float playerTop = Character.DrawCoordPlayer.Y;
            float playerBottom = Character.DrawCoordPlayer.Y + Character.PlayerCropHeight;
            float playerLeft = Character.DrawCoordPlayer.X;
            float playerRight = Character.DrawCoordPlayer.X + Character.PlayerCropWidth;

            float enemyTop = drawCoordEnemy.Y;
            float enemyBottom = drawCoordEnemy.Y + cropHeight;
            float enemyLeft = drawCoordEnemy.X;
            float enemyRight = drawCoordEnemy.X + cropWidth;

            moveSpeedEnemy = HaveCollision(enemyBottom, playerTop, enemyLeft, playerRight, enemyRight, playerLeft, moveSpeedEnemy);

            return moveSpeedEnemy;
        }

        private static float DetectionWithPlayerEnemyGoesLeft(float moveSpeedEnemy, Vector2 drawCoordEnemy, int cropWidth, int cropHeight)
        {

            float playerTop = Character.DrawCoordPlayer.Y;
            float playerBottom = Character.DrawCoordPlayer.Y + Character.PlayerCropHeight;
            float playerLeft = Character.DrawCoordPlayer.X;
            float playerRight = Character.DrawCoordPlayer.X + Character.PlayerCropWidth;

            float enemyTop = drawCoordEnemy.Y;
            float enemyBottom = drawCoordEnemy.Y + cropHeight;
            float enemyLeft = drawCoordEnemy.X;
            float enemyRight = drawCoordEnemy.X + cropWidth;

            moveSpeedEnemy = HaveCollision(enemyLeft, playerRight, enemyTop, playerBottom, enemyBottom, playerTop, moveSpeedEnemy);

            return moveSpeedEnemy;
        }

        private static float DetectionWithPlayerEnemyGoesRight(float moveSpeedEnemy, Vector2 drawCoordEnemy, int cropWidth, int cropHeight)
        {

            float playerTop = Character.DrawCoordPlayer.Y;
            float playerBottom = Character.DrawCoordPlayer.Y + Character.PlayerCropHeight;
            float playerLeft = Character.DrawCoordPlayer.X;
            float playerRight = Character.DrawCoordPlayer.X + Character.PlayerCropWidth;

            float enemyTop = drawCoordEnemy.Y;
            float enemyBottom = drawCoordEnemy.Y + cropHeight;
            float enemyLeft = drawCoordEnemy.X;
            float enemyRight = drawCoordEnemy.X + cropWidth;

            moveSpeedEnemy = HaveCollision(enemyRight, playerLeft, enemyTop, playerBottom, enemyBottom, playerTop, moveSpeedEnemy);

            return moveSpeedEnemy;
        }

        private static float HaveCollision(float pSide, float enemySide, float pCheckFirstSide, float enemyOpositeFirstSide, float pCheckSecondSide, float enemyOpositeSecondSide, float moveSpeedPlayer)
        {
            float result = moveSpeedPlayer;

            if (Math.Abs(pSide - enemySide) <= minPixelCollison)
            {
                if ((pCheckFirstSide > enemyOpositeFirstSide) || (pCheckSecondSide < enemyOpositeSecondSide))
                {
                    result = moveSpeedPlayer;
                }
                else
                {
                    result = 0;
                }
            }

            return result;
        }

        public static bool HaveCollisionWithCurrentRadius(float pSide, float enemySide, float pCheckFirstSide, float enemyOpositeFirstSide, float pCheckSecondSide, float enemyOpositeSecondSide, int radius)
        {
            bool result = false;

            if (Math.Abs(pSide - enemySide) <= radius)
            {
                if ((pCheckFirstSide > enemyOpositeFirstSide) || (pCheckSecondSide < enemyOpositeSecondSide))
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsNear(float playerDrawPosition, float enemyDrawPosition, int radius)
        {
            if (Math.Abs(playerDrawPosition - enemyDrawPosition) < radius)
            {
                return true;
            }
            
            return false;
        }

        public static bool IsBehindOrInFrontUsForAttack(WarUnit currentUnit, WarUnit targetUnit)
        {
            //int distance = 0;
            //if (currentUnit.AmIArcherOrMage)
            //{
            //    distance = currentUnit.MinAttackDistance;
            //}
            //else
            //{
            //    distance = (int)currentUnit.AvailableMove;
            //}

            bool isBehind = IsNear(currentUnit.DrawCoord.X + currentUnit.CropWidth, targetUnit.DrawCoord.X,
                currentUnit.MinAttackDistance);

            bool inFront = IsNear(currentUnit.DrawCoord.X, targetUnit.DrawCoord.X + targetUnit.CropWidth,
                currentUnit.MinAttackDistance);

            bool nearUsByY = currentUnit.DrawCoord.Y >= targetUnit.DrawCoord.Y - 15 &&
                             currentUnit.DrawCoord.Y <= targetUnit.DrawCoord.Y + targetUnit.CropHeight;

            bool nearUsByYCrop = currentUnit.DrawCoord.Y + currentUnit.CropHeight >= targetUnit.DrawCoord.Y &&
                                 currentUnit.DrawCoord.Y + currentUnit.CropHeight <=
                                 targetUnit.DrawCoord.Y + targetUnit.CropHeight + 15;

            bool byY = nearUsByY || nearUsByYCrop;

            bool result = (isBehind && byY) || (inFront && byY);
            
            return result;
        }

        public static double CalculateDistanceTravelled(Vector2 lastCoords, Vector2 currentCoords)
        {
            return Math.Sqrt((Math.Pow(lastCoords.X - currentCoords.X, 2)) +
                          (Math.Pow(lastCoords.Y - currentCoords.Y, 2)));
        }

        public static bool IsMouseOverObject(Vector2 currentObject, int width, int height, GameTime gameTime)
        {
            bool betweenX = MouseExtended.Current.GetState(gameTime).X > currentObject.X &&
                            MouseExtended.Current.GetState(gameTime).X < (currentObject.X + width);

            bool betweenY = MouseExtended.Current.GetState(gameTime).Y > currentObject.Y &&
                            MouseExtended.Current.GetState(gameTime).Y < (currentObject.Y + height);

            return betweenX && betweenY;
        }

        public static bool HaveCollisonBetweenTwoObj(WarUnit target, Arrow arrow)
        {
            bool collisionByX = (arrow.DrawCoords.X > target.DrawCoord.X &&
                                 arrow.DrawCoords.X < (target.DrawCoord.X + target.CropWidth))
                                ||
                                ((arrow.DrawCoords.X + arrow.CropWidth) > target.DrawCoord.X &&
                                 (arrow.DrawCoords.X + arrow.CropWidth) < (target.DrawCoord.X + target.CropWidth));

            bool collisionByY = arrow.DrawCoords.Y > target.DrawCoord.Y &&
                                arrow.DrawCoords.Y < (target.DrawCoord.Y + target.CropHeight);

            return collisionByX ;//&& collisionByY;
        }

        
        /// ---------------------------------------   NE TRII -----------------------------
        
        //private void MovingWithMouse()
        //{
        //    if (mouse.LeftButton == ButtonState.Pressed)
        //    {
        //        // take position where need to go
        //        lastMouseClickPosition.X = mouse.X;
        //        lastMouseClickPosition.Y = mouse.Y;

        //    }

        //    PlayerCenterCoordX = coordPlayer.X + (cropWidth / 2);
        //    PlayerCenterCoordY = coordPlayer.Y + (cropHeight / 2);

        //    if (PlayerCenterCoordX != lastMouseClickPosition.X || PlayerCenterCoordY != lastMouseClickPosition.Y)
        //    {
        //        if (lastMouseClickPosition.X > PlayerCenterCoordX)
        //        {
        //            coordPlayer.X += ObstacleDetectionWhenGoesRight(moveSpeedPlayer);
        //        }
        //        if (lastMouseClickPosition.X < PlayerCenterCoordX)
        //        {
        //            coordPlayer.X -= ObstacleDetectionWhenGoesLeft(moveSpeedPlayer);
        //        }
        //        if (lastMouseClickPosition.Y > PlayerCenterCoordY)
        //        {
        //            coordPlayer.Y += ObstacleDetectionWhenGoesDown(moveSpeedPlayer);
        //        }
        //        if (lastMouseClickPosition.Y < PlayerCenterCoordY)
        //        {
        //            coordPlayer.Y -= ObstacleDetectionWhenGoesUp(moveSpeedPlayer);
        //        }
        //    }
        //}

        //private float ObstacleDetectionWhenGoesUp(float moveSpeedPlayer)
        //{

        //    float result = moveSpeedPlayer;

        //    foreach (Vector2 coordinates in Map.Obstacles)
        //    {
        //        mapDetectionFromTop = coordinates.Y;
        //        mapDetectionFromBottom = coordinates.Y + 50f;
        //        mapDetectionFromLeft = coordinates.X;//
        //        mapDetectionFromRight = coordinates.X + 50f;

        //        if (Math.Abs(coordPlayer.Y - mapDetectionFromBottom) <= 2f)
        //        {
        //            if ((coordPlayer.X > mapDetectionFromRight) || ((coordPlayer.X + cropWidth) < mapDetectionFromLeft))
        //            {
        //                result = moveSpeedPlayer;
        //            }
        //            else
        //            {
        //                result = 0f;
        //                break;
        //            }

        //        }
        //    }

        //    return result ;
        //}

        //private float ObstacleDetectionWhenGoesLeft(float moveSpeedPlayer)
        //{
        //    float result = moveSpeedPlayer;

        //    foreach (Vector2 coordinates in Map.Obstacles)
        //    {
        //        mapDetectionFromTop = coordinates.Y;
        //        mapDetectionFromBottom = coordinates.Y + 50f;
        //        mapDetectionFromLeft = coordinates.X;//
        //        mapDetectionFromRight = coordinates.X + 50f;

        //        if (Math.Abs(coordPlayer.X - mapDetectionFromRight) <= 2f)
        //        {
        //            if ((coordPlayer.Y > mapDetectionFromBottom) || ((coordPlayer.Y + cropHeight) < mapDetectionFromTop))
        //            {
        //                result = moveSpeedPlayer;
        //            }
        //            else
        //            {
        //                result = 0f;
        //                break;
        //            }

        //        }
        //    }

        //    return result;
        //}

        //private float ObstacleDetectionWhenGoesDown(float moveSpeedPlayer)
        //{

        //    float result = moveSpeedPlayer;

        //    foreach (Vector2 coordinates in Map.Obstacles)
        //    {
        //        mapDetectionFromTop = coordinates.Y;
        //        mapDetectionFromBottom = coordinates.Y + 50f;
        //        mapDetectionFromLeft = coordinates.X;
        //        mapDetectionFromRight = coordinates.X + 50f;

        //        if (Math.Abs((coordPlayer.Y + cropHeight)- mapDetectionFromTop) <= 2f)
        //        {
        //            if ((coordPlayer.X > mapDetectionFromRight) || ((coordPlayer.X + cropWidth) < mapDetectionFromLeft))
        //            {
        //                result = moveSpeedPlayer;
        //            }
        //            else
        //            {
        //                result = 0f;
        //                break;
        //            }

        //        }

        //    }

        //    return result;
        //}

        //private float ObstacleDetectionWhenGoesRight(float moveSpeedPlayer)
        //{

        //    float result = moveSpeedPlayer;

        //    foreach (Vector2 coordinates in Map.Obstacles)
        //    {
        //        mapDetectionFromTop = coordinates.Y;
        //        mapDetectionFromBottom = coordinates.Y + 50f;
        //        mapDetectionFromLeft = coordinates.X;
        //        mapDetectionFromRight = coordinates.X + 50f;

        //        if (Math.Abs((coordPlayer.X + cropWidth) - mapDetectionFromLeft) <= 2f)
        //        {
        //            if ((coordPlayer.Y > mapDetectionFromBottom) || ((coordPlayer.Y + cropHeight) < mapDetectionFromTop))
        //            {
        //                result = moveSpeedPlayer;
        //            }
        //            else
        //            {
        //                result = 0f;
        //                break;
        //            }

        //        }

        //    }

        //    return result;
        //}7

    }
}
