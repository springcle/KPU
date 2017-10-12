using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Offline.Frame;
using Offline.Utilities;

namespace Offline.Manager
{
    public enum FrameName
    {
        [StringValue("FrameMenu")]
        FrameMenu,
        [StringValue("FrameAnalysisSurvey")]
        FrameAnalysisSurvey,
        [StringValue("GuidLine")]
        GuidLine,
        [StringValue("FrameAnalysisResult")]
        FrameAnalysisResult,
        [StringValue("FrameAnalysis")]
        FrameAnalysis,
        [StringValue("EOGCalibration")]
        EOGCalibration,
        [StringValue("TMT")]
        TMT,
        [StringValue("Meditaion")]
        Meditaion,
        [StringValue("TestGuide")]
        TestGuide,
        [StringValue("ResultLoading")]
        ResultLoading

    }
    //property
    public partial class FrameManager
    {
        private static FrameManager instance;
        public static FrameManager GetInstance
        {
            get
            {
                if (instance == null) instance = new FrameManager();
                return instance;
            }
        }
        private FrameManager() { }
    }

    public partial class FrameManager
    {
        private List<BaseFrame> frameList = new List<BaseFrame>();
        private BaseFrame currentFrame;
        public Grid Frame { get; set; }
        public bool IsOnLoaded = false;
        public void LoadFrame(FrameName name)
        {
          
            if (Frame == null)
            {
                throw new Exception("Frame is null");
            }
            if (IsOnLoaded) return;
            IsOnLoaded = true;
            try
            {
                if (Frame.Children.Count == 0) return;

                var frame = (from temp in frameList
                             where temp.name == StringEnum.GetStringValue(name)
                             select temp
                             ).SingleOrDefault();

                if (currentFrame != null) { currentFrame.OnUnLoaded(); }
                Frame.Children.Remove(currentFrame);
                Frame.Children.Add(frame);
                currentFrame = frame;
                if (currentFrame != null) { currentFrame.OnLoaded(); }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                IsOnLoaded = false;
          
            }
        }

        public void AddeFrame(BaseFrame frame)
        {
            try
            {
                bool isExist = frameList.Exists(item => item.name == frame.name);
                if (isExist) return;
                frameList.Add(frame);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveFrame(BaseFrame frame)
        {
            try
            {
                bool isExist = frameList.Exists(item => item.name == frame.name);
                if (!isExist) return;
                frameList.Remove(frame);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
