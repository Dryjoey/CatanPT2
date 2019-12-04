using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catan.Models
{
    public class Settingsmodel
    {
        public bool TileIsRandom { get; set; }

        public bool FullyPseudoRandom { get; set; }

        public bool IsSmallBoard { get; set; }

        public ChipState ChipState { get; set; }

        public Settingsmodel() //needed for the default settings in the settings menu
        {
            FullyPseudoRandom = true;
            IsSmallBoard = true;
        }
    }

    public enum ChipState
    {
        Random,
        Fixed,
        Psuedo
    };
}
