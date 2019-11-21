using System;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

namespace JollyPirate.model
{
    [Serializable()]
    public class Boat
    {
        private int length;
        private string type;
        public Boat(int length, string type)
        {
            Length = length;
            Type = type;
        }

        public int Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The length has to be a positive number above 0!");
                }
                else
                {
                    length = value;
                }
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value != "Canoe" && value != "Battle Ship" && value != "Yacht" && value != "Sub-Marine")
                {
                    throw new ArgumentOutOfRangeException("Invalid type was entered!");
                }
                else
                {
                    type = value;
                }
            }
        }
    }
}