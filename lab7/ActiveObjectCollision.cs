using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace lab7
{
    internal class ActiveObjectCollision : BaseObjeсt
    {
        // Направления движения по осям X и Y
        private int directionX = 1; // 1 - вправо, -1 - влево
        private int directionY = 1; // 1 - вниз, -1 - вверх

        // Конструктор
        public ActiveObjectCollision(Texture2D texture, Vector2 position, Rectangle bounds)
            : base(texture, position, bounds)
        {
        }

        // Метод для перемещения объекта с проверкой границ экрана
        private void Move(GraphicsDevice graphicsDevice, int speed)
        {
            var screenWidth = graphicsDevice.Viewport.Width;
            var screenHeight = graphicsDevice.Viewport.Height;

            // Обновление позиции объекта
            Position += new Vector2(directionX * speed, directionY * speed);

            // Проверка границ экрана по оси X
            if (Position.X + Texture.Width > screenWidth || Position.X < 0)
            {
                directionX *= -1; // Меняем направление по оси X
                Position = new Vector2(
                    Math.Clamp(Position.X, 0, screenWidth - Texture.Width),
                    Position.Y
                );
            }

            // Проверка границ экрана по оси Y
            if (Position.Y + Texture.Height > screenHeight || Position.Y < 0)
            {
                directionY *= -1; // Меняем направление по оси Y
                Position = new Vector2(
                    Position.X,
                    Math.Clamp(Position.Y, 0, screenHeight - Texture.Height)
                );
            }
        }

        // Метод для отрисовки объекта
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        // Метод для обновления состояния объекта
        public override void UdpateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            Move(graphicsDevice, speed); // Перемещаем объект
        }
    }
}
