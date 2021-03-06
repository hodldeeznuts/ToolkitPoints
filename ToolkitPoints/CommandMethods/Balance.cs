﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolkitCore;
using ToolkitCore.Interfaces;
using ToolkitCore.Models;
using ToolkitCore.Utilities;
using TwitchLib.Client.Interfaces;

namespace ToolkitPoints.CommandMethods
{
    public class Balance : CommandMethod
    {
        public Balance(ToolkitChatCommand command) : base (command)
        {

        }

        public override void Execute(ICommand command)
        {
            MessageSender.SendMessage($"@{command.Username()} you have {Points.Balance(command.Username(), command.Service())} {ToolkitPointsSettings.pointsBaseName}", command.Service());
        }
    }
}
