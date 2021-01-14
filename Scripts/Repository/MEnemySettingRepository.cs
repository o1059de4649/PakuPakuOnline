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
    class MEnemySettingRepository
    {
        public List<MEnemySettingModel> GetMEnemySettingModelAll(string connectionString)
        {
            var resultList = new List<MEnemySettingModel>();

            Handler.URL = connectionString;
            var values = new NameValueCollection();
            var sql = $@"
                        SELECT * FROM m_enemy
                            INNER JOIN m_enemy_animator
                            ON m_enemy.id = m_enemy_animator.enemy_id

                            INNER JOIN m_enemy_character_controller
                            ON m_enemy.id = m_enemy_character_controller.enemy_id

                            INNER JOIN m_enemy_move_controller
                            ON m_enemy.id = m_enemy_move_controller.enemy_id

                            INNER JOIN m_enemy_status
                            ON m_enemy.id = m_enemy_status.id
                        ";
            values["sql"] = sql;
            string result = Handler.DoPost(values);
            var dicList = Handler.ConvertDeserialize(result);
            foreach (var item in dicList)
            {
                MEnemySettingModel model = new MEnemySettingModel();

                model.id = item[nameof(model.id)].ToString().ToLongValue();
                model.modelPath = item[nameof(model.modelPath)].ToString();

                //CharacterController
                var mEnemyCharacterControllerModel = new MEnemyCharacterControllerModel();
                mEnemyCharacterControllerModel.skinWidth = item[nameof(mEnemyCharacterControllerModel.skinWidth)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.slopLimit = item[nameof(mEnemyCharacterControllerModel.slopLimit)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.stepOffset = item[nameof(mEnemyCharacterControllerModel.stepOffset)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.radius = item[nameof(mEnemyCharacterControllerModel.radius)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.height = item[nameof(mEnemyCharacterControllerModel.height)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.center_x = item[nameof(mEnemyCharacterControllerModel.center_x)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.center_y = item[nameof(mEnemyCharacterControllerModel.center_y)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.center_z = item[nameof(mEnemyCharacterControllerModel.center_z)].ToString().ToFloatValue();
                mEnemyCharacterControllerModel.minMoveDistance = item[nameof(mEnemyCharacterControllerModel.minMoveDistance)].ToString().ToFloatValue();
                model.mEnemyCharacterControllerModel = mEnemyCharacterControllerModel;

                //EnemyMoveController
                var mEnemyMoveControllerModel = new MEnemyMoveControllerModel();
                mEnemyMoveControllerModel.walkSpeed = item[nameof(mEnemyMoveControllerModel.walkSpeed)].ToString().ToFloatValue();
                mEnemyMoveControllerModel.cycleMaxTime = item[nameof(mEnemyMoveControllerModel.cycleMaxTime)].ToString().ToFloatValue();
                mEnemyMoveControllerModel.cycleMinTime = item[nameof(mEnemyMoveControllerModel.cycleMinTime)].ToString().ToFloatValue();
                mEnemyMoveControllerModel.isGravity = item[nameof(mEnemyMoveControllerModel.isGravity)].ToString();
                model.mEnemyMoveControllerModel = mEnemyMoveControllerModel;

                //EnemyStatusModel
                var mEnemyStatusModel = new MEnemyStatusModel();
                mEnemyStatusModel.id = item[nameof(mEnemyStatusModel.id)].ToString().ToIntValue();
                mEnemyStatusModel.level = item[nameof(mEnemyStatusModel.level)].ToString().ToIntValue();
                mEnemyStatusModel.hp = item[nameof(mEnemyStatusModel.hp)].ToString().ToLongValue();
                mEnemyStatusModel.mp = item[nameof(mEnemyStatusModel.mp)].ToString().ToLongValue();
                mEnemyStatusModel.name = item[nameof(mEnemyStatusModel.name)].ToString();
                mEnemyStatusModel.exp = item[nameof(mEnemyStatusModel.exp)].ToString().ToLongValue();
                model.mEnemyStatusModel = mEnemyStatusModel;

                resultList.Add(model);
            }
            return resultList;
        }
    }
}
