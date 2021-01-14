using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakuPakuOnLine.Model
{
    public class MEnemyStatusModel
    {
        public long id {get; set;} 
        public string name {get; set;} 
        public int level { get; set;} 
        public long hp { get; set;} 
        public long mp { get; set;} 
        public long exp { get; set;} 
        public long enemy_group_cd { get; set;} 
    }
}
