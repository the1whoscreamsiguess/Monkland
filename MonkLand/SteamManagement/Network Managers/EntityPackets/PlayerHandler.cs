﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RWCustom;
using UnityEngine;

namespace Monkland.SteamManagement
{
    class PlayerHandler
    {
        public static Player Read(Player player, ref BinaryReader reader)
        {
            player = CreatureHandler.Read(player, ref reader);
            player.aerobicLevel = reader.ReadSingle();
            player.airInLungs = reader.ReadSingle();
            player.allowRoll = reader.ReadInt32();
            player.animation = (Player.AnimationIndex)reader.ReadInt32();
            player.bodyMode = (Player.BodyModeIndex)reader.ReadInt32();
            player.circuitSwimResistance = reader.ReadSingle();
            player.consistentDownDiagonal = reader.ReadInt32();
            bool corridorDrop = reader.ReadBoolean();
            int corridorTurnCounter = reader.ReadInt32();
            IntVector2? corridorTurnDir = IntVector2NHandler.Read(ref reader);
            int crawlTurnDelay = reader.ReadInt32();
            (player as Patches.patch_Player).Sync(corridorDrop, corridorTurnCounter, corridorTurnDir, crawlTurnDelay);
            player.drown = reader.ReadSingle();
            player.exhausted = reader.ReadBoolean();
            player.glowing = reader.ReadBoolean();
            player.leftFoot = reader.ReadBoolean();
            player.longBellySlide = reader.ReadBoolean();
            player.lungsExhausted = reader.ReadBoolean();
            player.rollCounter = reader.ReadInt32();
            player.rollDirection = reader.ReadInt32();
            player.slideCounter = reader.ReadInt32();
            player.slideDirection = reader.ReadInt32();
            player.slideUpPole = reader.ReadInt32();
            player.standing = reader.ReadBoolean();
            player.swallowAndRegurgitateCounter = reader.ReadInt32();
            player.swimCycle = reader.ReadSingle();
            return player;
        }

        public static void Write(Player player, ref BinaryWriter writer)
        {
            CreatureHandler.Write(player, ref writer);
            writer.Write(player.airInLungs);
            writer.Write(player.allowRoll);
            writer.Write((int)player.animation);
            writer.Write((int)player.bodyMode);
            writer.Write(player.circuitSwimResistance);
            writer.Write(player.consistentDownDiagonal);
            (player as Patches.patch_Player).Write(ref writer);
            writer.Write(player.drown);
            writer.Write(player.exhausted);
            writer.Write(player.glowing);
            writer.Write(player.leftFoot);
            writer.Write(player.longBellySlide);
            writer.Write(player.lungsExhausted);
            writer.Write(player.rollCounter);
            writer.Write(player.rollDirection);
            writer.Write(player.slideCounter);
            writer.Write(player.slideDirection);
            writer.Write(player.slideUpPole);
            writer.Write(player.standing);
            writer.Write(player.swallowAndRegurgitateCounter);
            writer.Write(player.swimCycle);
        }
    }
}
