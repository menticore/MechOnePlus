using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;

namespace MechPlusOne.Tiles
{
	public class ZeroTimerTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(Type);
			
			drop = mod.ItemType("ZeroTimer");
			AddMapEntry(new Color(144, 148, 144));
		}
		
		public override void HitWire(int i, int j) {
			Tile tile = Main.tile[i, j];
			int leftX = i - tile.frameX / 18 % 2;
			short frameAdjustment = (short)(tile.frameY > 0 ? -18 : 18);
			Main.tile[leftX, j].frameY += frameAdjustment;
			Wiring.SkipWire(leftX, j);
			NetMessage.SendTileSquare(-1, leftX + 1, j, 2, TileChangeType.None);
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			int frameX = Main.tile[i, j].frameX;
			int frameY = Main.tile[i, j].frameY;
			int width = 16;
			int height = 16;
			
			// unclear what this does
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen) {
				zero = Vector2.Zero;
			}

			Main.spriteBatch.Draw(
				mod.GetTexture("Tiles/ZeroTimerActive"),
				new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (width - 16f) / 2f, (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, 
				new Rectangle(frameX, frameY, width, height), 
				new Color(200, 200, 200, 0), 
				0f, 
				default(Vector2), 
				1f, 
				SpriteEffects.None,
				0f
			);
		}
	}
}
