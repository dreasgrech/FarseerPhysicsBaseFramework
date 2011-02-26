using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerPhysicsBaseFramework.GameEntities
{
    public sealed class TexturedGameEntity:Entity
    {
        public Texture2D MainTexture { get; set; }
        public float ZIndex { get; set; }

        public TexturedGameEntity(Game game, float angle, string mainTextureImageAssetPath, float zIndex) : this(game,Vector2.Zero,angle,mainTextureImageAssetPath,zIndex){}
        public TexturedGameEntity(Game game, Vector2 position, float angle, string mainTextureImageAssetPath, float zIndex) : base(game)
        {
            Position = position;
            Angle = angle;
            MainTexture = Game.Content.Load<Texture2D>(mainTextureImageAssetPath);
            ZIndex = zIndex;
            Center = new Vector2(Width/2f, Height/2f);
        }

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
            SpriteBatch.Draw(MainTexture, Position, null, Color.White, Angle, Center, 1f, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gametime) {}
    }
}
