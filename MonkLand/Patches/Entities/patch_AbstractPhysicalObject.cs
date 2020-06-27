﻿using System;
using System.Collections.Generic;
using System.Text;
using MonoMod;
using Monkland.SteamManagement;
using UnityEngine;

namespace Monkland.Patches
{
    [MonoModPatch("global::AbstractPhysicalObject")]
    class patch_AbstractPhysicalObject : AbstractPhysicalObject
    {
        [MonoModIgnore]
        public patch_AbstractPhysicalObject(World world, AbstractObjectType type, PhysicalObject realizedObject, WorldCoordinate pos, EntityID ID) : base(world, type, realizedObject, pos, ID)
        {
        }

        public int dist
        {
            get
            {
                if (this.ID.number == 0)
                {
                    return this.playerdist;
                }
                return this.ID.number;
            }
        }
        public int playerdist = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        public ulong owner = 0;

        public bool networkObject
        {
            get{
                return (MonklandSteamManager.isInGame && owner != NetworkGameManager.playerID);
            }
        }

        [MonoModIgnore]
        public extern void OriginalConstructor(World world, AbstractObjectType type, PhysicalObject realizedObject, WorldCoordinate pos, EntityID ID);
        [MonoModConstructor, MonoModOriginalName("OriginalConstructor")]
        public void ctor_AbstractPhysicalObject(World world, AbstractObjectType type, PhysicalObject realizedObject, WorldCoordinate pos, EntityID ID)
        {
            OriginalConstructor(world, type, realizedObject, pos, ID);
            if (ID.number != -1 && ID.number != 5 && ID.number != 0 && this.ID.number != 1 && this.ID.number != 2 && this.ID.number == 3)
            {
                while ((this.ID.number >= -1 && this.ID.number <= 15000))
                {
                    this.ID.number = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
                }
            }
            if (ID.number == 0)
            {
                playerdist = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            }
            if (MonklandSteamManager.isInGame)
            {
                owner = NetworkGameManager.playerID;
            }
        }
    }
}
