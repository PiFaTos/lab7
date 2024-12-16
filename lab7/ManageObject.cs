using lab7;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lab7
{
    internal class ManageObject : BaseObjeсt
    {
        public ManageObject(Texture2D texture, Vector2 position, Rectangle bound)
            : base(texture, position, bound) { }
        
        public override void Draw(SpriteBatch spriteBatch)// Рисование объекта
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        public override void UdpateObject(GraphicsDevice graphicsDevice, GameTime gameTime, short speed)// Обновление объекта
        {
            KeyManage(gameTime, speed);
        }

        // Метод для управления объектом с клавиатуры
        public void KeyManage(GameTime gameTime, short speed)
        {
            // Получаем текущее состояние клавиатуры
            KeyboardState ks = Keyboard.GetState();

            // Проверяем, какие клавиши нажаты, и изменяем координаты
            if (ks.IsKeyDown(Keys.Left))
                Position = new Vector2(Position.X - speed, Position.Y);
            if (ks.IsKeyDown(Keys.Right))
                Position = new Vector2(Position.X + speed, Position.Y);
            if (ks.IsKeyDown(Keys.Up))
                Position = new Vector2(Position.X, Position.Y - speed);
            if (ks.IsKeyDown(Keys.Down))
                Position = new Vector2(Position.X, Position.Y + speed);
        }

        // Метод для получения направления движения
        public Vector2 GetVelocity()
        {
            return new Vector2(Position.X * 2, Position.Y * 2); // Пример направления
        }

       
        
    }
}
