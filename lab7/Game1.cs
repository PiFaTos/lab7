using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace lab7
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameManager _gameManager;
        private Texture2D _backgroundTexture;
        private Texture2D _carTexture;
        private Texture2D _evilTexture;
        private ActiveObject _backgroundObject; // Задний фон

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Устанавливаем размер окна
            _graphics.PreferredBackBufferWidth = 1300;
            _graphics.PreferredBackBufferHeight = 950;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _gameManager = new GameManager();

            // Подписка на событие столкновения
            _gameManager.CollisionDetected += GameManager_CollisionDetected;

            base.Initialize();
        }

        // Метод, вызываемый при столкновении объектов
        private void GameManager_CollisionDetected(BaseObjeсt obj1, BaseObjeсt obj2)
        {
            
            Debug.WriteLine($"Слипание между объектами: {obj1.GetType().Name} и {obj2.GetType().Name}");
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Загрузка текстур
            _backgroundTexture = Content.Load<Texture2D>("road");
            _carTexture = Content.Load<Texture2D>("car");
            _evilTexture = Content.Load<Texture2D>("bug");

            // Создание объектов
            _backgroundObject = new ActiveObject(
                _backgroundTexture,
                new Vector2(0, 0),
                new Rectangle(0, 0, _backgroundTexture.Width, _backgroundTexture.Height));

            ManageObject playerObject = new ManageObject(
                _carTexture,
                new Vector2(50, 50),
                new Rectangle(50, 50, _carTexture.Width, _carTexture.Height));

            ActiveObjectCollision enemyObject = new ActiveObjectCollision(
                _evilTexture,
                new Vector2(800, 600),
                new Rectangle(800, 600, _evilTexture.Width, _evilTexture.Height));

            // Добавление объектов в менеджер
            _gameManager.AddObject(playerObject);
            _gameManager.AddObject(enemyObject);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            short speed = 4; // Скорость движения

            // Обновление объектов через менеджер
            _gameManager.UpdateObject(GraphicsDevice, gameTime, speed);

            // Обновление фона
            _backgroundObject.MovementBack(GraphicsDevice, gameTime, speed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Рисование фона
            _backgroundObject.Draw(_spriteBatch);

            // Рисование всех объектов через менеджер
            foreach (var obj in _gameManager.GetObjects())
            {
                obj.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
