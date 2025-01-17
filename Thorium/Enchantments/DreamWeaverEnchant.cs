using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.EndofDays.Dream;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DreamWeaverEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dream Weaver Enchantment");
            Tooltip.SetDefault(
@"'Manifest your dearest dreams through your allies, Bind the enemies of your future in temporal agony'
Pressing the 'Special Ability' key will spend 400 mana and place you within the Dream and bend the very fabric of reality
While in the Dream, healed allies will become briefly invulnerable and be cured of all debuffs
Enemies will be heavily slowed and take 15% more damage from all sources
Allies will receive greatly increased movement and attack speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "织梦者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'通过你的盟友显化你甜蜜的美梦, 用时间之苦痛束缚你未来的敌人'
按下'特殊能力'键消耗400法力, 入梦并扭曲现实结构
入梦时, 治疗队友会使其短暂无敌, 并治愈所有Debuff
极大减缓敌人, 并增加15%其所受伤害
队友获得大幅度攻击速度和移动速度加成
召唤宠物女仆");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 400000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 128, 0));
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //all allies invuln hot key
            thoriumPlayer.dreamHoodSet = true;
            //enemies slowed and take more dmg hot key
            thoriumPlayer.dreamSet = true;
        }
        
        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DreamWeaversHelmet>()); //any..
            //recipe.AddIngredient(ModContent.ItemType<DreamWeaversHood>());
            recipe.AddIngredient(ModContent.ItemType<DreamWeaversTabard>());
            recipe.AddIngredient(ModContent.ItemType<DreamWeaversTreads>());
            recipe.AddIngredient(ModContent.ItemType<DragonHeartWand>());
            recipe.AddIngredient(ModContent.ItemType<SnackLantern>());
            recipe.AddIngredient(ModContent.ItemType<ChristmasCheer>());


            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
