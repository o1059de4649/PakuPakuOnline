using PakuPakuOnLine.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PakuPakuOnLine.Repository
{
    class MItemRepository
    {
        public List<MItemModel> GetMItemAll(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var resultList = new List<MItemModel>();

                connection.Open();
                var queryString = "SELECT * FROM dbo.m_item";
                SqlCommand command = new SqlCommand(queryString, connection);
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    MItemModel model = new MItemModel();

                    model.id = result.GetInt64(0);
                    model.name = result.GetString(1);
                    model.item_group_cd = result.GetString(2);
                    model.price = result.GetInt64(3);
                    model.value = result.GetInt64(4);
                    model.rarity = result.GetInt32(5);
                    model.rarityeffect_type = result.GetInt32(6);

                    resultList.Add(model);
                }

                return resultList;
            }
        }
    }
}
