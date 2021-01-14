using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PakuPakuOnLine.Model
{
    /// <summary>
    /// 敵の設定値
    /// </summary>
    public class MEnemySettingModel
    {
        public long id {get; set;} 
        public string modelPath {get; set;} 
        public MEnemyCharacterControllerModel mEnemyCharacterControllerModel { get; set;} 
        public MEnemyMoveControllerModel mEnemyMoveControllerModel { get; set;} 
        public MEnemyStatusModel mEnemyStatusModel { get; set;} 
    }

    /// <summary>
    /// キャラクターコントローラーの設定
    /// </summary>
    public class MEnemyCharacterControllerModel
    {
        public float slopLimit { get; set; }
        public float stepOffset { get; set; }
        public float skinWidth { get; set; }
        public float minMoveDistance { get; set; }
        public float center_x { get; set; }
        public float center_y { get; set; }
        public float center_z { get; set; }
        public float radius { get; set; }
        public float height { get; set; }
    }

    /// <summary>
    /// Animatorの設定
    /// </summary>
    public class MEnemyAnimatorControllerModel
    {
        public string animatorController { get; set; }
        public string avatar { get; set; }
    }

    /// <summary>
    /// EnemyMoveControllerの設定
    /// </summary>
    public class MEnemyMoveControllerModel
    {
        public string isGravity { get; set; }
        public float walkSpeed { get; set; }
        public float cycleMaxTime { get; set; }
        public float cycleMinTime { get; set; }
    }
}
