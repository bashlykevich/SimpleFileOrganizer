using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFileOrganizer
{
    public enum RuleAction { Move, Copy };

    public class Filter
    {
        public string Extensions = "";
        public string TargetDir = "%EXT%";
        public string FileNameMask = "%DIR% - %FILENAME%";
        public RuleAction Action = RuleAction.Copy;
    }
}
