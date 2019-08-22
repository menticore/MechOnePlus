using Terraria.ID;
using Terraria.ModLoader;

namespace MechPlusOne.Items
{
	public class ZeroTimer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("0 Second Timer");
			Tooltip.SetDefault("Activates everytime");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Timer1Second);
			item.createTile = mod.TileType("ZeroTimerTile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldWatch, 1);
			recipe.AddIngredient(ItemID.PlatinumWatch, 1);
			recipe.AddIngredient(ItemID.Wire, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
