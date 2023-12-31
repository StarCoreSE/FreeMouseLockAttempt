﻿using System;
using System.Reflection;
using HarmonyLib;
using Sandbox.Graphics.GUI;
using VRage.Plugins;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using Sandbox.Game.World;

namespace ClientPlugin
{
    // ReSharper disable once UnusedType.Global
    public class Plugin : IPlugin, IDisposable
    {
        public const string Name = "FreeMouseLock";
        public static Plugin Instance { get; private set; }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void Init(object gameInstance)
        {
            Instance = this;

            // TODO: Put your one time initialization code here.
            Harmony harmony = new Harmony(Name);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void Dispose()
        {
            // TODO: Save state and close resources here, called when the game exits (not guaranteed!)
            // IMPORTANT: Do NOT call harmony.UnpatchAll() here! It may break other plugins.

            Instance = null;
        }

        public void Update()
        {
            if (MySession.Static != null && MyAPIGateway.Input.IsNewKeyPressed(VRage.Input.MyKeys.T))
            {
                MyAPIGateway.Utilities.ShowNotification("T key pressed!", 5000); // Show a notification

                // Make cursor visible and change its position
                MyGuiSandbox.SetMouseCursorVisibility(true);

            }

            // TODO: Put your other update code here. It is called on every simulation frame!
        }



        // TODO: Uncomment and use this method to create a plugin configuration dialog
        // ReSharper disable once UnusedMember.Global
        /*public void OpenConfigDialog()
        {
            MyGuiSandbox.AddScreen(new MyPluginConfigDialog());
        }*/
    }
}
