using System;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

using static JollyPirate.view.View;

namespace JollyPirate.controller
{
    [Serializable()]
    public class Controller
    {
        model.Database db;
        public Controller(model.Database db)
        {
            this.db = db;
        }
        public void run(View v, MembersRegistry m)
        {
            v.renderMainMenu();
            ActionTaken usersInput = v.getUsersInput();

            while (usersInput != ActionTaken.Quit)
            {
                if (usersInput == ActionTaken.RegisterMember)
                {
                    Member member = v.registerMember();
                    m.addMember(member);
                    db.saveMembersRegistryToDB(m.getMembersList());
                }
                
                if (usersInput == ActionTaken.EditMember)
                {
                    try
                    {
                        int membersId = v.selectUserById(m.getMembersList());
 
                        m.getMemberById(membersId).editMemberData(v.editMember(m.getMemberById(membersId).UniqueId));

                        db.saveMembersRegistryToDB(m.getMembersList());
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        v.showInputError(ex.Message);
                        v.renderMainMenu();
                    }
                }

                if (usersInput == ActionTaken.DeleteMember)
                {
                    try
                    {
                        int membersId = v.deleteMember(m.getMembersList());
                        m.deleteMember(membersId);
                        db.saveMembersRegistryToDB(m.getMembersList());
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        v.showInputError(ex.Message);
                        v.renderMainMenu();
                    }
                }

                if (usersInput == ActionTaken.RegisterBoat)
                {
                    try
                    {
                        int usersId = v.selectUserById(m.getMembersList());
                        m.getMemberById(usersId).addBoat(v.registerBoat());
                        db.saveMembersRegistryToDB(m.getMembersList());
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        v.showInputError(ex.Message);
                    }
                }

                if (usersInput == ActionTaken.EditBoat)
                {
                    try
                    {
                        int membersId = v.selectUserById(m.getMembersList());
                        int indexOfBoat = v.getIndexOfBoat(m.getMemberById(membersId).returnBoatList());

                        m.getMemberById(membersId).updateBoatValues(v.editBoat(), indexOfBoat);
                        db.saveMembersRegistryToDB(m.getMembersList());
                    }
                    catch (Exception ex)
                    {
                        v.showInputError(ex.Message);
                    }
                }

                if (usersInput == ActionTaken.DeleteBoat)
                {
                    try 
                    {
                        int membersId = v.selectUserById(m.getMembersList());
                        int indexOfBoat = v.deleteBoat(m.getMemberById(membersId));

                        m.getMemberById(membersId).removeBoat(indexOfBoat);
                        db.saveMembersRegistryToDB(m.getMembersList());
                    }
                    catch (Exception ex)
                    {
                        v.showInputError(ex.Message);
                    }
                }

                if (usersInput == ActionTaken.ViewSimpleList)
                {
                    v.viewSimpleList(m.getMembersList());
                }

                if (usersInput == ActionTaken.ViewDetailedList)
                {
                    v.viewDetailedList(m.getMembersList());
                }

                if (usersInput == ActionTaken.ViewSpecificMember)
                {
                    int membersId = v.selectUserById(m.getMembersList());
                    v.viewSpecificMember(m.getMemberById(membersId));
                }

                v.renderMainMenu();
                usersInput = v.getUsersInput();
            }            
        }
    }
}