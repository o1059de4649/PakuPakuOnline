using System;
using PakuPakuOnLine.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using NEETLibrary;
using System.Collections.Specialized;
using NEETLibrary.Tiba.Com.SqlConnection;
using NEETLibrary.Tiba.Com.Methods;

namespace PakuPakuOnLine.Repository
{
    class MItemRepository
    {
        public List<MItemModel> GetMItemAll(string connectionString)
        {
            var resultList = new List<MItemModel>();

            Handler.URL = connectionString;
            var values = new NameValueCollection();
            values["sql"] = SQLCreater.MasterAllGetSQL("m_item");
            values["table"] = "m_item";
            string result = Handler.DoPost(values);
            var dicList = Handler.ConvertDeserialize(result);
            foreach (var item in dicList)
            {
                MItemModel model = new MItemModel();

                model.id = item[nameof(model.id)].ToString().ToLong().Value;
                model.name = item[nameof(model.name)].ToString();
                model.item_group_cd = item[nameof(model.item_group_cd)].ToString().ToLong().Value;
                model.price = item[nameof(model.price)].ToString().ToLong().Value;
                model.value = item[nameof(model.value)].ToString().ToLong().Value;
                model.rarity = item[nameof(model.rarity)].ToString().ToInt().Value;
                model.rarityeffect_type = item[nameof(model.rarityeffect_type)].ToString().ToInt().Value;
                resultList.Add(model);
            }

            return resultList;

        }
    }
}
