﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace lab7
{
    internal class ActiveObject : BaseObjeсt
    {
        // Конструктор
        public ActiveObject(Texture2D texture, Vector2 position, Rectangle bound) : base(texture, position, bound) { }

        // Метод для передвижения фона
        public void MovementBack(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            // Обновляем позицию фона
            Position += new Vector2(-speed, Position.Y);

            // Если фон полностью вышел за левую границу экрана, перемещаем его вправо
            if (Position.X + Texture.Width <= 0)
            {
                Position = new Vector2(Position.X + Texture.Width, Position.Y);
            }
        }

        // Метод для отрисовки объекта
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Рисуем основное изображение
            spriteBatch.Draw(Texture, Position, Color.White);

            // Рисуем второе изображение, следующее за основным, для создания эффекта бесконечного фона
            spriteBatch.Draw(Texture, new Vector2(Position.X + Texture.Width, Position.Y), Color.White);
        }
    }
}