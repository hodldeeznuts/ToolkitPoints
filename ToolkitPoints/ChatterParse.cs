﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolkitCore.Controllers;
using ToolkitCore.Models;
using ToolkitPoints.SimpleJson;
using Verse;
using static ToolkitCore.Models.Services;

namespace ToolkitPoints
{
    public class ChatterParse
    {
        public static List<Viewer> FindViewersInChatterWrapper()
        {
            ChatterWrapper chatterWrapper = JsonConvert.DeserializeObject<ChatterWrapper>(TwitchAPI.lastChatterDownload);

            List<Viewer> chatterNames = new List<Viewer>();

            List<string[]> chatterGroups = new List<string[]>()
            {
                chatterWrapper.chatters.admins,
                chatterWrapper.chatters.broadcaster,
                chatterWrapper.chatters.global_mods,
                chatterWrapper.chatters.moderators,
                chatterWrapper.chatters.staff,
                chatterWrapper.chatters.viewers,
                chatterWrapper.chatters.vips
            };

            foreach(string[] list in chatterGroups)
            {
                foreach(string username in list)
                {
                    if (ViewerController.ViewerExists(Service.Twitch, username))
                    {
                        chatterNames.Add(ViewerController.GetViewer(Service.Twitch, username));
                    }
                    else
                    {
                        chatterNames.Add(ViewerController.CreateViewer(Service.Twitch, username, 0));
                    }
                }
            }

            return chatterNames;
        }
    }
}
