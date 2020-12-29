using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakuPakuOnLine.Model
{
    public class MItemModel
    {
        public long id {get; set;} 
        public string name {get; set;} 
        public long item_group_cd { get; set;} 
        public long price { get; set;} 
        public long value { get; set;} 
        public int rarity { get; set;} 
        public int rarityeffect_type { get; set;} 
    }
}
