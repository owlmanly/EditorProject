using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ZEditor
{
    public enum CameraActionTypes
    {
        [DisplayNameAttribute("还原")]
        RestoreParam,
        [DisplayNameAttribute("设置")]
        SetParam,
        [DisplayNameAttribute("设置聚焦目标")]
        ChangeTarget,
        [DisplayNameAttribute("还原聚焦目标")]
        ResetTarget,
    }


    [ScenarioCommandAttribute(ScenarioCommandTypes.CAM)]
    [RadioGroupAttribute(typeof(CameraActionTypes))]
    public class CameraCommandModel : BaseCommandModel
    {
        private CameraActionTypes _cameraActionType = CameraActionTypes.RestoreParam;

        [DisplayNameAttribute("CAM子命令")]
        public CameraActionTypes CameraActionType
        {
            get { return _cameraActionType; }
            set { _cameraActionType = value; }
        }

        //RestoreParam
        private float _time = 1000;
        [DisplayNameAttribute("时间ms")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.RestoreParam)]
        public float Time
        {
            get { return _time; }
            set { _time = value; }
        }

        //SetParam
        [DisplayNameAttribute("Radius")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.SetParam)]
        public float Radius { get; set; }

        [DisplayNameAttribute("Y")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.SetParam)]
        public float Y { get; set; }

        private float _timeParam = 0;
        [DisplayNameAttribute("time")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.SetParam)]
        public float TimeParam
        {
            get { return _timeParam; }
            set { _timeParam = value; }
        }

        private float _angle = 0.0f;

        [DisplayNameAttribute("Angle")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.SetParam)]
        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        private float _offset = 0.0f;

        [DisplayNameAttribute("Offset")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.SetParam)]
        public float Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        //ChangeTarget
        [DisplayNameAttribute("阵型")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.ChangeTarget)]
        public int ZhenXingID { get; set; }

        [DisplayNameAttribute("ID")]
        [RadioGroupAttribute(typeof(CameraActionTypes), EnumValue = (int)CameraActionTypes.ChangeTarget)]
        public int ModelID { get; set; }

        //ResetTarget

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            switch (CameraActionType)
            {
                case CameraActionTypes.RestoreParam:
                    {
                        sb.Append((int)CameraActionTypes.RestoreParam);
                        sb.Append(":");
                        sb.Append(Time);
                    }
                    break;
                case CameraActionTypes.SetParam:
                    {
                        sb.Append((int)CameraActionTypes.SetParam);
                        sb.Append(":");
                        sb.Append(Radius);
                        sb.Append(":");
                        sb.Append(Y);
                        sb.Append(":");
                        sb.Append(TimeParam);
                        sb.Append(":");
                        sb.Append(Angle);
                        sb.Append(":");
                        sb.Append(Offset);
                    }
                    break;
                case CameraActionTypes.ChangeTarget:
                    {
                        sb.Append((int)CameraActionTypes.ChangeTarget);
                        sb.Append(":");
                        sb.Append(ZhenXingID);
                        sb.Append(":");
                        sb.Append(ModelID);
                        sb.Append(":");
                    }
                    break;
                case CameraActionTypes.ResetTarget:
                    {
                        sb.Append((int)CameraActionTypes.ResetTarget);
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }
    }
}
