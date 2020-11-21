using System;
using System.Collections.Generic;
using System.Web;

namespace HiloGameASPNET
{
    static public class SharedValues
    {
        public const string VIEWSTATE_PLAYERNAME = "vsPlayerName";
        public const string VIEWSTATE_MINGUESS = "vsMinGuess";
        public const string VIEWSTATE_MAXGUESS = "vsMaxGuess";
        public const string VIEWSTATE_TARGETGUESS = "vsTargetGuess";
        public const string VIEWSTATE_PLAYERGUESS = "vsPlayerGuess";
        public const string VIEWSTATE_REPLAY = "vsReplay";
        public const string DEFAULT_PLAYERNAME = "DEFAULT";
        public const int DEFAULT_MINGUESS = 1;
        public const int DEFAULT_MAXGUESS = Int32.MaxValue;
    }
}