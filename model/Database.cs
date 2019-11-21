using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace JollyPirate.model
{
    [Serializable()]
    public class Database
    {
        private string fileName = "MembersRegistry.dat";

        public void saveMembersRegistryToDB(IEnumerable<Member> members)
        {
            Stream stream = File.Open(this.fileName, FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, members.ToList());
            stream.Close();
        }

        public List<Member> retrieveFromDatabase()
        {
            Stream stream = File.Open(this.fileName, FileMode.Open);

            if (stream.Length == 0)
            {
                stream.Close();
                return new List<Member>();
            }

            BinaryFormatter bf = new BinaryFormatter();

            List<Member> membersListFromDB = (List<Member>)bf.Deserialize(stream);

            stream.Close();
            return membersListFromDB;
        }
    }
}