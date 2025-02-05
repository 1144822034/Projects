﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Engine.Graphics;
using Game;
namespace Mekiasm
{
    public class ItemOreBlock : Block
    {
        public const int Index = 1001;
        public ItemOreBlock() {          
        }
        public virtual Item GetItem(ref int value) {
            int id = Terrain.ExtractData(value);
            if(Terrain.ExtractContents(value) != 1001)return null;
            return MekiasmInit.items_ore.Where(p=>p.itemid==id).FirstOrDefault();  
        }
        public override void DrawBlock(PrimitivesRenderer3D primitivesRenderer, int value, Color color, float size, ref Matrix matrix, DrawBlockEnvironmentData environmentData)
        {
            GetItem(ref value).DrawBlock(primitivesRenderer,value,color,size,ref matrix,environmentData);
        }
        public override IEnumerable<CraftingRecipe> GetProceduralCraftingRecipes()
        {//设置合成谱
            List<CraftingRecipe> rcps = new List<CraftingRecipe>();
            List<string> ins = new List<string>();
            ins.Add("ironingot");ins.Add(""); ins.Add(""); ins.Add(""); ins.Add("");
            ins.Add(""); ins.Add(""); ins.Add(""); ins.Add("");//必须要九个
            CraftingRecipe crafting = new CraftingRecipe();
            crafting.Description = "程序内置合成谱";
            crafting.Ingredients = ins.ToArray();
            crafting.ResultCount = 18;
            crafting.ResultValue = 2;
            crafting.RemainsCount = 0;
            crafting.RemainsValue = 0;
            rcps.Add(crafting);
            return rcps;
        }
        public override float GetIconViewScale(int value, DrawBlockEnvironmentData environmentData)
        {
            return base.GetIconViewScale(value, environmentData);
        }
        public override BoundingBox[] GetCustomInteractionBoxes(SubsystemTerrain terrain, int value)
        {
            return base.GetCustomInteractionBoxes(terrain, value);
        }
        public override BoundingBox[] GetCustomCollisionBoxes(SubsystemTerrain terrain, int value)
        {
            return GetItem(ref value).GetCustomCollisionBoxes(terrain, value);
        }
        public override void GenerateTerrainVertices(BlockGeometryGenerator generator, TerrainGeometrySubsets geometry, int value, int x, int y, int z)
        {
            GetItem(ref value).GenerateTerrainVertices(this,generator,geometry,value,x,y,z);
        }
        public override string GetDisplayName(SubsystemTerrain subsystemTerrain, int value)
        {
            return GetItem(ref value).GetDisplayName(subsystemTerrain,value);
        }
        public override int GetFaceTextureSlot(int face, int value)
        {
            return GetItem(ref value).GetFaceTextureSlot(face,value);
        }
        public override bool IsFaceTransparent(SubsystemTerrain subsystemTerrain, int face, int value)
        {
            return GetItem(ref value).IsFaceTransparent(subsystemTerrain, face, value);
        }
        public override bool IsInteractive(SubsystemTerrain subsystemTerrain, int value)
        {
            return GetItem(ref value).IsInteractive(subsystemTerrain, value);
        }
        public override void GetDropValues(SubsystemTerrain subsystemTerrain, int oldValue, int newValue, int toolLevel, List<BlockDropValue> dropValues, out bool showDebris)
        {
            GetItem(ref oldValue).GetDropValues(subsystemTerrain, oldValue, newValue, toolLevel, dropValues, out showDebris);
        }
        public override string GetCategory(int value)
        {
            return "通用机械-地形";
        }
        public override BlockPlacementData GetDigValue(SubsystemTerrain subsystemTerrain, ComponentMiner componentMiner, int value, int toolValue, TerrainRaycastResult raycastResult)
        {
            return GetItem(ref value).GetDigValue(subsystemTerrain, componentMiner, value, toolValue, raycastResult);
        }
        public override BlockDebrisParticleSystem CreateDebrisParticleSystem(SubsystemTerrain subsystemTerrain, Vector3 position, int value, float strength)
        {
            return GetItem(ref value).CreateDebrisParticleSystem(subsystemTerrain, position, value, strength);
        }
        public override BlockPlacementData GetPlacementValue(SubsystemTerrain subsystemTerrain, ComponentMiner componentMiner, int value, TerrainRaycastResult raycastResult)
        {
            int value2 = value;
            return GetItem(ref value2).GetPlacementValue(subsystemTerrain, componentMiner, value, raycastResult);
        }
        public override IEnumerable<int> GetCreativeValues()
        {
            int[] arr = new int[MekiasmInit.items_ore.Count];
            for (int i = 0; i < MekiasmInit.items_ore.Count; i++)
            {
                arr[i] = Terrain.MakeBlockValue(1001, 0, MekiasmInit.items_ore.Array[i].itemid);
            }
            return arr;
        }

    }
}
