using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace lab7
{
    internal class BaseObjeсt
    {
        // Поля класса
        protected Texture2D texture; // Текстура объекта
        protected Vector2 position; // Позиция объекта
        // Конструктор
        public BaseObjeсt(Texture2D texture, Vector2 position, Rectangle bound)
        {
            Texture = texture;
            Position = position;
            Bound = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        // Свойства
        public Vector2 Position { get; set; } // Позиция объекта
        public Texture2D Texture { get; set; } // Текстура объекта
        public Rectangle Bound
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            set { }
        }
        // Направление движения объекта
        public float DirectionX { get; set; } = 1; // По оси X (1 — вправо, -1 — влево)
        public float DirectionY { get; set; } = 1; // По оси Y (1 — вниз, -1 — вверх)

        // Метод обновления объекта
        public virtual void UdpateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            // Реализация будет у наследников
        }

        // Метод отрисовки объекта
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
