using FarseerPhysicsBaseFramework.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public sealed class TexturedGameEntity:Entity
    {
        public Texture2D MainTexture { get; set; }
        public float ZIndex { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        private TexturedGameEntity(Game game, Texture2D texture, Vector2 position, float angle, float zIndex):base(game)
        {
            MainTexture = texture;
            Center = new Vector2(Width/2f, Height/2f);
            Position = position;
            ZIndex = zIndex;
            Angle = angle;
            SpriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            
        }
        public TexturedGameEntity(Game game, float angle, Texture2D texture, float zIndex) : this(game, texture, Vector2.Zero, angle, zIndex) { }
        public TexturedGameEntity(Game game, float angle, string mainTextureImageAssetPath, float zIndex) : this(game, Vector2.Zero,angle,mainTextureImageAssetPath,zIndex){}
        public TexturedGameEntity(Game game, Vector2 position, float angle, Texture2D texture, float zIndex) : this(game, texture, position, angle, zIndex) { }
        public TexturedGameEntity(Game game, Vector2 position, float angle, string mainTextureImageAssetPath, float zIndex) : this(game, game.Content.Load<Texture2D>(mainTextureImageAssetPath), position, angle, zIndex) { }

        public override Vector2 Position { get; set; }

        public int Width
        {
            get { return MainTexture.Width; }
        }

        public int Height
        {
            get { return MainTexture.Height; }
        }

        public override float Angle { get; set; }

        public override void Draw(GameTime gametime)
        {
            SpriteBatch.Draw(MainTexture, Position, null, Color.White, Angle, Center, 1, SpriteEffects.None, ZIndex);
        }

        public override void Update(GameTime gametime) {}
    }
}
