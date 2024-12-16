using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace lab7
{
    // GameManager - Менеджер, который управляет игровыми объектами, их отрисовкой и обработкой столкновений
    internal class GameManager
    {
        private List<BaseObjeсt> activeObjects;

        // Создаем делегат и событие для обработки столкновений
        public delegate void CollisionEventHandler(BaseObjeсt obj1, BaseObjeсt obj2);
        public event CollisionEventHandler CollisionDetected;

        public GameManager()
        {
            activeObjects = new List<BaseObjeсt>();
        }

        // Обновление всех объектов
        public void UpdateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            foreach (var obj in activeObjects)
            {
                switch (obj)
                {
                    case ActiveObjectCollision activeCollisObject:
                        activeCollisObject.UdpateObject(graphicsDevice, gameTime, speed);
                        break;
                    case ManageObject manageObject:
                        manageObject.UdpateObject(graphicsDevice, gameTime, speed);
                        break;
                    case ActiveObject activeBackObj:
                        activeBackObj.UdpateObject(graphicsDevice, gameTime, speed);
                        break;
                }
            }

            CheckCollision();
        }

        // Проверка на столкновения
        public void CheckCollision()
        {
            if (activeObjects.Count < 2)
                return; // Не хватает объектов для проверки столкновений

            var obj1 = activeObjects[0]; // Управляемый объект

            for (int i = 1; i < activeObjects.Count; i++)
            {
                var obj2 = activeObjects[i];

                // Проверка пересечения границ объектов
                bool isColliding =
                    obj1.Position.X < obj2.Position.X + obj2.Texture.Width &&
                    obj1.Position.X + obj1.Texture.Width > obj2.Position.X &&
                    obj1.Position.Y < obj2.Position.Y + obj2.Texture.Height &&
                    obj1.Position.Y + obj1.Texture.Height > obj2.Position.Y;

                if (isColliding)
                {
                    // Вызываем событие при столкновении
                    CollisionDetected?.Invoke(obj1, obj2);

                    // Слипаем объекты после столкновения
                    obj2.Position = obj1.Position;
                }
            }
        }

        // Отрисовка всех объектов
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in activeObjects)
            {
                obj.Draw(spriteBatch);
            }
        }

        // Добавление объекта в менеджер
        public void AddObject(BaseObjeсt obj)
        {
            activeObjects.Add(obj);
        }

        // Получение списка объектов
        public List<BaseObjeсt> GetObjects()
        {
            return activeObjects;
        }
    }
}
