using System;
using System.Collections.Generic;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

namespace JollyPirate.model
{
    [Serializable()]
    public class Member
    {
        private string name;
        private string socialSecurityNumber;
        private int uniqueId;
        private List<Boat> boats;

        public Member(string name, string socialSecurityNumber, int uniqueId)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            UniqueId = uniqueId;
            boats = new List<Boat> ();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentOutOfRangeException("The name can not be left empty!");
                }
                else
                {
                    name = value;
                }
            }
        }
        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("The social security number must be 10 characters long, follow the format!");
                }
                else
                {
                    socialSecurityNumber = value;
                }
            }
        }

        public int UniqueId
        {
            get { return uniqueId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The unique id of the member can not be a negative number!");
                }
                else
                {
                    uniqueId = value;
                }
            }
        }

        public void editMemberData(Member updatedMember)
        {
            this.UniqueId = updatedMember.UniqueId;
            this.Name = updatedMember.Name;
        }

        public void addBoat(Boat boat)
        {
            boats.Add(boat);
        }

        public void updateBoatValues(Boat boat, int index)
        {
            this.boats[index].Length = boat.Length;
            this.boats[index].Type = boat.Type;
        }

        public void removeBoat(int indexOfBoat)
        {
            this.boats.RemoveAt(indexOfBoat);
        }
        public int amountOfBoats()
        {
            return boats.Count;
        }

        public IEnumerable<Boat> returnBoatList()
        {
            return this.boats;
        }
    }
}