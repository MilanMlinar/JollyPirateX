using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

namespace JollyPirate.model
{
    [Serializable()]
    public class MembersRegistry
    {
        private List<Member> members;
        public MembersRegistry(Database database)
        {
            this.members = database.retrieveFromDatabase();
        }

        public void addMember(Member member)
        {
            member.UniqueId = getUniqueId();
            this.members.Add(member);
        }
        public void deleteMember(int membersId)
        {
            bool userExists = false;

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].UniqueId == membersId)
                {
                    userExists = true;
                    members.RemoveAt(i);
                }
            }

            if (!userExists)
            {
                throw new ArgumentOutOfRangeException($"A member with the id {membersId} does not exist!");
            }
        }
        public Member getMemberById(int membersId)
        {
            foreach (var member in members)
            {
                if (member.UniqueId == membersId)
                {
                    return member;
                }
            }
            throw new ArgumentOutOfRangeException($"A member with the id {membersId} does not exist!");
        }
        public IEnumerable<Member> getMembersList()
        {
            return members;
        }
        private int getUniqueId()
        {
            if (this.members.Count == 0)
            {
                return 1;
            }
            else
            {
                return this.members[members.Count - 1].UniqueId + 1;
            }
        }
    }
}