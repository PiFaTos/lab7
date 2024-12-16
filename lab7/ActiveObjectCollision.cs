using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace lab7
{
    internal class ActiveObjectCollision : BaseObjeсt
    {
        // Поля для направления движения
        protected int directionX = 1; // Направление по оси X (1 - вправо, -1 - влево)
        protected int directionY = 1; // Направление по оси Y (1 - вниз, -1 - вверх)

        // Конструктор
        public ActiveObjectCollision(Texture2D texture, Vector2 position, Rectangle bound) : base(texture, position, bound)
        {
        }

        // Метод для перемещения объекта
        public void MoveObj(GraphicsDevice graphicsDevice, int speed)
        {
            int screenWidth = graphicsDevice.Viewport.Width;
            int screenHeight = graphicsDevice.Viewport.Height;

            // Обновляем позицию объекта
            Position += new Vector2(directionX * speed, directionY * speed);

            // Проверяем границы экрана и меняем направление движения
            if (Position.X + Texture.Width > screenWidth || Position.X < 0)
            {
                directionX *= -1; // Инвертируем направление по X
                Position = new Vector2(
                    Math.Clamp(Position.X, 0, screenWidth - Texture.Width),
                    Position.Y
                );
            }

            if (Position.Y + Texture.Height > screenHeight || Position.Y < 0)
            {
                directionY *= -1; // Инвертируем направление по Y
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

        // Метод обновления объекта
        public override void UdpateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            MoveObj(graphicsDevice, speed);
        }
    }
}
