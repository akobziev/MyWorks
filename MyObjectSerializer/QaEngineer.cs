using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyObjectSerializer
{
    public class QaEngineer
    {
        [JsonProperty("Name")]
        public string FirstName { get; set; }
        [JsonProperty("Surname")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
        public Project ManeProject { get; set; }

        public QaEngineer()
        {
            ManeProject = new Project {Client = "UBISOFT", Name = "TLOU" };
        }
    }
}
