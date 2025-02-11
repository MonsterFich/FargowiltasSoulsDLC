﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class MidgardForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Midgard");
            Tooltip.SetDefault(
@"'Behold the power of Mankind...'
All armor bonuses from Lodestone, Valadium, Illumite, and Shade Master
All armor bonuses from Jester, Thorium, Geode, and Terrarium
Effects of Astro-Beetle Husk, Obsidian Scale, Mirror of the Beholder, and Jazz Music Player
Effects of Crietz, Band of Replenishment, Fan Letter, and Terrarium Surround Sound
Effects of Crystaline Charm and Crystal Spear Tip");
            DisplayName.AddTranslation(GameCulture.Chinese, "米德加德之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'人类的力量'
生命值每下降25%, 增加10%伤害减免
生命值低于50%时达到上限: 30%
按'上'键逆转重力
重力颠倒时增加12%远程伤害
每3次攻击会发射荧光导弹
泰拉瑞亚的能量试图保护你
攻击敌人时偶尔会召唤暂时存在的潜水员
暴击短暂缓慢所有附近敌人
拥有太空甲虫壳和注者之眼的效果
拥有精准项链和界元音箱的效果
召唤宠物粉红史莱姆");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            mod.GetItem("GeodeEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("LodestoneEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("ValadiumEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("IllumiteEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("ShadeMasterEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("TerrariumEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "GeodeEnchant");
            recipe.AddIngredient(null, "LodestoneEnchant");
            recipe.AddIngredient(null, "ValadiumEnchant");
            recipe.AddIngredient(null, "IllumiteEnchant");
            recipe.AddIngredient(null, "ShadeMasterEnchant");
            recipe.AddIngredient(null, "TerrariumEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
