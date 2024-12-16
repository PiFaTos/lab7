using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace lab7
{
    // Базовый класс для подвижных и управляемых объектов
    internal class Object
    {
        // Поля
        protected Texture2D _texture; // Текстура объекта
        protected Vector2 _position; // Позиция объекта

        // Конструктор
        public Object(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        // Свойства
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public Rectangle Bound
        {
            get => new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }

        // Виртуальный метод для обновления состояния объекта
        public virtual void UpdateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)
        {
            // Логика обновления будет переопределяться в наследниках
        }
    }
}
