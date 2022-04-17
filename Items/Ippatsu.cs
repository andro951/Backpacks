using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Creative;

namespace Backpacks.Items
{
	public class Ippatsu : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ippatsu"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults()
		{
			Item.damage = 1000000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 10;
			Item.crit = 96;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.DirtBlock, 10);
			//recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}

	public class IppatsuPrism : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ippatsu"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			//Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.reuseDelay = 0;
			Item.shootSpeed = 30f;
			Item.knockBack = 0f;
			Item.width = 16;
			Item.height = 16;
			Item.damage = 1000000;
			Item.UseSound = null;
			Item.shoot = 633;
			Item.mana = 0;
			Item.rare = 10;
			Item.value = 10000;
			Item.crit = 96;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Magic;
			Item.channel = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.DirtBlock, 10);
			//recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			//Edit Vanilla recipies
			/* Works
			Main.recipe[278].requiredItem[0].SetDefaults(ItemID.WoodPlatform);
			Main.recipe[278].requiredItem[0].stack = 1;
			Main.recipe[278].createItem.SetDefaults(ItemID.Wood, false);
			Main.recipe[278].createItem.stack = 1;
			*/

			/*  //For finding recipie number
			for (int i = 0; i < Main.recipe.Length; i++)
			{
				if (Main.recipe[i].createItem.type == ItemID.Wood)
				{
					Main.recipe[i].requiredItem[0].SetDefaults(ItemID.WoodPlatform, false);
					Main.recipe[i].requiredItem[0].stack = 1;
					Main.recipe[i].createItem.SetDefaults(i, false);
					Main.recipe[i].createItem.stack = 1;
					break;
				}
			}
			*/
		}
	}

	public class Backpack : ModItem
    {
		public static bool oneForOne = false;
        public override void UpdateInventory(Player player)
        {
            player.accWatch = 3;


			// Works to toggle on, no way to toggle off   START WORKING ON MODS INSTEAD!
			if (!oneForOne)
            {
				ToggleRecipie(278, 94, 1, 9, 1);
				oneForOne = true;
            }
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.DirtBlock, 10);
			//recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		/*
		bool found = false;
		public static void OnCreate()
        {
			found = false;
			for (int i = 0; i < Player.inventory.Length; i++)
            {
				if(Player.inventory[i] == Backpack)
                {
					found = true;
					break;
                }
				ToggleRecipie(278);
            }
        }
		*/

			//public static bool toggleRecipie;
		public static bool defaultRecipieSet = false;
		public static int requiredItemDefault;
		public static int requiredItemStackDefault;
		public static int createItemDefault;
		public static int createItemStackDefault;
		public void ToggleRecipie(int recipieNum, int requiredItem = -1, int requiredItemStack = -1, int createItem = -1, int createItemStack = -1)
        {
			if (!defaultRecipieSet)
			{
				requiredItemDefault = requiredItem;
				requiredItemStackDefault = requiredItemStack;
				createItemDefault = createItem;
				createItemStackDefault = createItemStack;
				defaultRecipieSet = true;
			}

			//if (toggleRecipie)
			if (requiredItem == -1 || requiredItemStack == -1 || createItem == -1 || createItemStack == -1)
			{
				Main.recipe[recipieNum].requiredItem[0].SetDefaults(requiredItemDefault);
				Main.recipe[recipieNum].requiredItem[0].stack = requiredItemStackDefault;
				Main.recipe[recipieNum].createItem.SetDefaults(createItemDefault);
				Main.recipe[recipieNum].createItem.stack = createItemStackDefault;
				//toggleRecipie = false;
			}
			else
			{
				Main.recipe[recipieNum].requiredItem[0].SetDefaults(requiredItem);
				Main.recipe[recipieNum].requiredItem[0].stack = requiredItemStack;
				Main.recipe[recipieNum].createItem.SetDefaults(createItem);
				Main.recipe[recipieNum].createItem.stack = createItemStack;
				//toggleRecipie = true;
			}
		}
    }

	internal class Sanguine_essence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TSE");
			Tooltip.SetDefault("This blade finds you worthy of its use.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.autoReuse = true;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 2100;
			Item.knockBack = 5.0f;
			Item.crit = 50;

			Item.value = Item.buyPrice(copper: 50, silver: 29, gold: 55);
			Item.rare = ItemRarityID.Purple;

			Item.UseSound = SoundID.Item1;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(3508)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}