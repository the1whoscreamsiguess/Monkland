﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RWCustom;
using UnityEngine;

namespace Monkland.SteamManagement
{
    static class EntityIDHandler
    { 
        public static EntityID Read(EntityID ID, ref BinaryReader reader)
        {
            ID.number = reader.ReadInt32();
            ID.spawner = reader.ReadInt32();
            return ID;
        }
        public static EntityID Read(ref BinaryReader reader)
        {
            EntityID ID = new EntityID(0, 0);
            ID.number = reader.ReadInt32();
            ID.spawner = reader.ReadInt32();
            return ID;
        }

        public static void Write(EntityID ID, ref BinaryWriter writer)
        {
            writer.Write(ID.number);
            writer.Write(ID.spawner);
        }
        
    }
}
