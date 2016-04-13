using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Bot;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace BotApp
{


    [LuisModel("", "")]
    [Serializable]
    public class SimpleEmailDialog : LuisDialog<object>
    {

        public const string Entity_send = "sendActivity";
        public const string Entity_delete = "deleteActivity";

      

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Das konnte ich nicht verstehen: " + string.Join(",", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("sendActivity")]
        public async Task SendMail(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Meinst du senden?");
            context.Wait(MessageReceived);

        }

        [LuisIntent("deleteActivity")]
        public async Task DeleteMail(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Meinst du löschen?");
            context.Wait(MessageReceived);

        }

    }
}