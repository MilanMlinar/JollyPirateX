using System;
using System.Collections.Generic;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

namespace JollyPirate.view
{
    public class View
    {
        public enum ActionTaken
        {
            RegisterMember,
            EditMember,
            DeleteMember,
            RegisterBoat,
            EditBoat,
            DeleteBoat,
            ViewSimpleList,
            ViewDetailedList,
            ViewSpecificMember,
            Quit,
            None
        }
        public void renderLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("X======================X");
            Console.WriteLine("X                      X");
            Console.WriteLine("X   The Jolly Pirate   X");
            Console.WriteLine("X                      X");
            Console.WriteLine("X======================X");
            Console.ResetColor();
        }

        public void renderMainMenu()
        {
            renderLogo();
            Console.WriteLine("1. Register a new member");
            Console.WriteLine("2. Edit a member");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Delete a member");
            Console.ResetColor();
            Console.WriteLine("4. Register a boat to a member");
            Console.WriteLine("5. Edit a members boat");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Delete a members boat");
            Console.ResetColor();
            Console.WriteLine("7. View a simple list of members");
            Console.WriteLine("8. View a detailed list of members");
            Console.WriteLine("9. View a specific members information");
            Console.WriteLine("0. Quit the program");
        }

        public ActionTaken getUsersInput()
        {
            char usersChoice = Console.ReadKey().KeyChar;

            if (usersChoice == '1')
            {
                return ActionTaken.RegisterMember;
            }
            if (usersChoice == '2')
            {
                return ActionTaken.EditMember;
            }
            if (usersChoice == '3')
            {
                return ActionTaken.DeleteMember;
            }
            if (usersChoice == '4')
            {
                return ActionTaken.RegisterBoat;
            }
            if (usersChoice == '5')
            {
                return ActionTaken.EditBoat;
            }
            if (usersChoice == '6')
            {
                return ActionTaken.DeleteBoat;
            }
            if (usersChoice == '7')
            {
                return ActionTaken.ViewSimpleList;
            }
            if (usersChoice == '8')
            {
                return ActionTaken.ViewDetailedList;
            }
            if (usersChoice == '9')
            {
                return ActionTaken.ViewSpecificMember;
            }
            if (usersChoice == '0')
            {
                return ActionTaken.Quit;
            }
            return ActionTaken.None;
        }

        public Member registerMember()
        {
            string name;
            string socialSecurityNumber;
            renderLogo();
            Console.WriteLine("Register a new member");
    
            do
            {
                Console.Clear();
                renderLogo();
                Console.WriteLine("Register a new member");
                Console.WriteLine("Type the members name: ");
                name = Console.ReadLine();
            } while (name.Length == 0);

            do
            {
                Console.Clear();
                renderLogo();
                Console.WriteLine("Register a new member");
                Console.WriteLine("Type the members social security number, follow the format yymmddxxxx: ");
                socialSecurityNumber = Console.ReadLine();
            } while (socialSecurityNumber.Length != 10);

            Console.ForegroundColor = ConsoleColor.Green;
            Member member = new Member(name, socialSecurityNumber, 0);
            Console.WriteLine("The member was successfuly registered.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            return member;
        }

        public Member editMember(int membersId)
        {
            string socialSecurityNumber;
            string name;

            renderLogo();
            Console.WriteLine("Edit a member");

            do
            {
                Console.Clear();
                renderLogo();
                Console.WriteLine("Edit a member");
                Console.WriteLine("Type the members name: ");
                name = Console.ReadLine();
            } while (name.Length == 0);

            do
            {
                Console.Clear();
                renderLogo();
                Console.WriteLine("Edit a member");
                Console.WriteLine("Type the members social security number, follow the format yymmddxxxx: ");
                socialSecurityNumber = Console.ReadLine();
            } while (socialSecurityNumber.Length != 10);
            

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            return new Member(name, socialSecurityNumber, membersId);
        }

        public int deleteMember(IEnumerable<Member> membersList)
        {
            renderLogo();
            Console.WriteLine();
            int membersId = this.selectUserById(membersList);

            return membersId;
        }

        public Boat registerBoat()
        {
            int length;
            int typeChoice;

            renderLogo();
            Console.WriteLine("Add a boat to member");
            Console.WriteLine();

            do
            {
                Console.WriteLine("What is the length of the boat?");
            } while (!int.TryParse(Console.ReadLine(), out length));

            do {
                Console.WriteLine("What is the type of the boat?");
                Console.WriteLine("Boat type 1.Canoe 2.Battle Ship 3.Yacht 4.Sub-Marine: ");
                typeChoice = Int32.Parse(Console.ReadLine());
            } while (typeChoice != 1 && typeChoice != 2 && typeChoice != 3 && typeChoice != 4);

            string type = this.convertToType(typeChoice);
            
            Boat boat = new Boat(length, type);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The boat was registered to the selected user.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

            return boat;
        }

        public Boat editBoat()
        {
            int length;
            int typeChoice;

            renderLogo();
            Console.WriteLine("Edit a members boat");

            do
            {
                Console.WriteLine("What is the length of the boat?");
            } while (!int.TryParse(Console.ReadLine(), out length));

            do {
                Console.WriteLine("What is the type of the boat?");
                Console.WriteLine("Boat type 1.Canoe 2.Battle Ship 3.Yacht 4.Sub-Marine: ");
                typeChoice = Int32.Parse(Console.ReadLine());
            } while (typeChoice != 1 && typeChoice != 2 && typeChoice != 3 && typeChoice != 4);

            string type = this.convertToType(typeChoice);
            
            Boat boat = new Boat(length, type);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The members boat was successfuly updated.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

            return boat;
        }

        public int deleteBoat(Member member)
        {
            renderLogo();
            Console.WriteLine("Delete the members boat");
            Console.WriteLine($"Name: {member.Name} Personal Number: {member.SocialSecurityNumber} Id: {member.UniqueId}");

            int index = 0;

            foreach (var boat in member.returnBoatList())
            {
                Console.WriteLine($"Index: {index}, Type: {boat.Type}, Length: {boat.Length}");
                index++;
            }

            Console.WriteLine("Choose the index of the boat you want to remove and press return.");
            Console.ResetColor();

            int indexOfBoat = Int32.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The boat was successfuly removed");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

            return indexOfBoat;
        }

        public void viewSimpleList(IEnumerable<Member> membersList)
        {
            renderLogo();
            Console.WriteLine("You are viewing a simple list of the registered members");
            Console.WriteLine();
            
            foreach(var member in membersList)
            {
                Console.WriteLine($"Name: {member.Name} Social Number: {member.SocialSecurityNumber} Id: {member.UniqueId} Amount of boats: {member.amountOfBoats()}");
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press the return key to return to the main menu.");
            Console.ReadLine();
        }

        public void viewDetailedList(IEnumerable<Member> members)
        {
            renderLogo();
            Console.WriteLine("You are viewing a detailed list of the registered members");
            Console.WriteLine();

            foreach(var member in members)
            {
                Console.WriteLine($"Name: {member.Name} Personal Number: {member.SocialSecurityNumber} Id: {member.UniqueId}");
                Console.WriteLine();
                Console.WriteLine($"{member.Name}'s boats: ");

                foreach (var boat in member.returnBoatList())
                {
                    Console.WriteLine($"Boat type: {boat.Type}, Boat length: {boat.Length}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }

        public void viewSpecificMember(Member member)
        {
            renderLogo();
            Console.WriteLine($"Name: {member.Name} Personal Number: {member.SocialSecurityNumber} Id: {member.UniqueId}");

            foreach (var boat in member.returnBoatList())
            {
                Console.WriteLine($"Type: {boat.Type}, Length: {boat.Length}");
            }
            Console.WriteLine();
            
            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }

        public int selectUserById(IEnumerable<Member> membersList)
        {
            int membersId;

            renderLogo();
            Console.WriteLine("Select the id of the member");
            Console.WriteLine();

            foreach(var member in membersList)
            {
                Console.WriteLine($"Name: {member.Name} Social Number: {member.SocialSecurityNumber} Id: {member.UniqueId}");
            }

            do
            {
                Console.WriteLine("Enter the members ID:");
            } 
            while (!int.TryParse(Console.ReadLine(), out membersId));
            
            Console.WriteLine(membersId);
            return membersId;
        }

        public int getIndexOfBoat(IEnumerable<Boat> boats)
        {
            renderLogo();
            int index = 0;
            foreach (var boat in boats)
            {
                Console.WriteLine($"Index: {index} Type: {boat.Type} Length: {boat.Length}");
                index++;
            }
        
            Console.WriteLine("Enter the index of the boat you would like to edit and then press enter.");
            int indexOfBoat = Int32.Parse(Console.ReadLine());
            return indexOfBoat;
        }

        public void showInputError(string errorMessage)
        {
            Console.Clear();
            renderLogo();

            Console.WriteLine(errorMessage);
            Console.WriteLine("Press the return key to return to the main menu.");
            Console.ReadLine();
        }

        public string convertToType(int typeChoice)
        {
            if (typeChoice == 1)
            {
                return "Canoe";
            }
            else if (typeChoice == 2)
            {
                return "Battle Ship";
            }
            else if (typeChoice == 3)
            {
                return "Yacht";
            }
            else if (typeChoice == 4)
            {
                return "Sub-Marine";
            }
            else
            {
                return null;
            }
        }
    }
}