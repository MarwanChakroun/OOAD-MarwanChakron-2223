using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfEscapeGame
{
    public class RandomMessageGenerator
    {
        public enum MessageType {itworks,itdoesntworks, itislocked}

        private static string[] itDOESNTWORKS = { "I'm not seeing any progress with this strategy." , "Fuck !!!, It looks like this method isn't working for us !", "Our current plan doesn't seem to be yielding any results." };
        private static string[] itWORKS = { "Congrats, you broke the game...in a good way!\"", "Wow, you actually did that. Impressive! !!!", "That's it, I'm calling the fun police! You win" };
        private static string[] itISLOCKED = { "still locked", "Access denied! Item is feeling a bit shy today.", "Nope, not today, my friend!" };

        public static string GetRandomMessage(MessageType t)
        {
            Random rnd = new Random();
            int random =  rnd.Next(2);
            string message = null;

            switch (t)
            {
                case MessageType.itworks:
                    message = itWORKS[random];
                    break;
                case MessageType.itdoesntworks:
                    message = itDOESNTWORKS[random];
                    break;
                case MessageType.itislocked:
                    message = itISLOCKED[random];
                    break;
            }
            return message;
        }
    }
}
